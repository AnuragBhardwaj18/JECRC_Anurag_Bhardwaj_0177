import React, { useEffect, useState } from "react";
import "./App.css";
import API from "./services/api";

import Header from "./components/Header";
import CatalogSwitcher from "./components/CatalogSwitcher";
import CatalogList from "./components/CatalogList";
import BillItemsTable from "./components/BillItemsTable";
import BillSummary from "./components/BillSummary";
import PastBills from "./components/PastBills";
import DailySummary from "./components/DailySummary";
import CustomItemForm from "./components/CustomItemForm";

import {
  saveDraftBill,
  loadDraftBill,
  savePastBillToLocal,
  getPastBillsFromLocal
} from "./utils/localStorage";

import { exportBillToPDF, exportBillsToCSV } from "./utils/exportHelpers";

function App() {
  const [catalogType, setCatalogType] = useState("EntranceFee");
  const [catalogItems, setCatalogItems] = useState([]);
  const [billItems, setBillItems] = useState([]);

  const [discountType, setDiscountType] = useState("none");
  const [discountValue, setDiscountValue] = useState(0);
  const [taxPercent, setTaxPercent] = useState(18);

  const [summary, setSummary] = useState({
    subTotal: 0,
    discountAmount: 0,
    taxAmount: 0,
    grandTotal: 0
  });

  const [pastBills, setPastBills] = useState([]);
  const [searchText, setSearchText] = useState("");
  const [dailySummary, setDailySummary] = useState(null);

  const [showCustomItemForm, setShowCustomItemForm] = useState(false);

  useEffect(() => {
    fetchCatalogItems(catalogType);
    fetchBills();
    fetchDailySummary();

    const draft = loadDraftBill();
    if (draft) {
      setBillItems(draft.items || []);
      setDiscountType(draft.discountType || "none");
      setDiscountValue(draft.discountValue || 0);
      setTaxPercent(draft.taxPercent || 18);
      setSummary({
        subTotal: draft.subTotal || 0,
        discountAmount: draft.discountAmount || 0,
        taxAmount: draft.taxAmount || 0,
        grandTotal: draft.grandTotal || 0
      });
    }
  }, []);

  useEffect(() => {
    fetchCatalogItems(catalogType);
  }, [catalogType]);

  useEffect(() => {
    calculateBill();
  }, [billItems, discountType, discountValue, taxPercent]);

  const fetchCatalogItems = async (type) => {
    try {
      const res = await API.get(`/Catalog/${type}`);
      setCatalogItems(res.data);
    } catch (error) {
      console.error("Fetch Catalog Error:", error.response?.data || error.message);
    }
  };

  const calculateBill = async () => {
    try {
      if (!billItems.length) {
        setSummary({
          subTotal: 0,
          discountAmount: 0,
          taxAmount: 0,
          grandTotal: 0
        });
        return;
      }

      const payload = {
        items: billItems.map((item) => ({
          itemName: item.itemName,
          catalogType: Number(item.catalogType),
          unitPrice: Number(item.unitPrice),
          quantity: Number(item.quantity)
        })),
        discountType: discountType || "none",
        discountValue: Number(discountValue) || 0,
        taxPercent: Number(taxPercent) || 0
      };

      const res = await API.post("/Bill/calculate", payload);

      setSummary({
        subTotal: res.data.subTotal,
        discountAmount: res.data.discountAmount,
        taxAmount: res.data.taxAmount,
        grandTotal: res.data.grandTotal
      });
    } catch (error) {
      console.error("Calculate Bill Error:", error.response?.data || error.message);
    }
  };

  const addToBill = (item) => {
    let price = Number(item.price);

    if (item.isVariablePrice) {
      const entered = prompt(`Enter price for ${item.name}`, item.price);
      if (entered === null) return;

      price = Number(entered);
      if (isNaN(price) || price < 0) {
        alert("Please enter a valid price.");
        return;
      }
    }

    const existing = billItems.find((x) => x.itemName === item.name);

    if (existing) {
      setBillItems(
        billItems.map((x) =>
          x.itemName === item.name
            ? { ...x, quantity: Number(x.quantity) + 1 }
            : x
        )
      );
    } else {
      setBillItems([
        ...billItems,
        {
          id: Date.now(),
          itemName: item.name,
          catalogType: Number(item.catalogType),
          unitPrice: Number(price),
          quantity: 1
        }
      ]);
    }
  };

  const addCustomItem = (customItem) => {
    setBillItems([
      ...billItems,
      {
        id: Date.now(),
        itemName: customItem.itemName,
        catalogType: 4,
        unitPrice: Number(customItem.unitPrice),
        quantity: Number(customItem.quantity)
      }
    ]);
  };

  const updateItem = (id, field, value) => {
    setBillItems(
      billItems.map((item) =>
        item.id === id
          ? {
              ...item,
              [field]:
                field === "unitPrice" || field === "quantity"
                  ? Number(value)
                  : value
            }
          : item
      )
    );
  };

  const removeItem = (id) => {
    setBillItems(billItems.filter((item) => item.id !== id));
  };

  const saveDraft = () => {
    saveDraftBill({
      items: billItems,
      discountType,
      discountValue,
      taxPercent,
      ...summary
    });
    alert("Draft saved successfully.");
  };

  const saveBill = async () => {
    try {
      if (!billItems.length) {
        alert("Please add at least one item.");
        return;
      }

      const payload = {
        items: billItems.map((item) => ({
          itemName: item.itemName,
          catalogType: Number(item.catalogType),
          unitPrice: Number(item.unitPrice),
          quantity: Number(item.quantity)
        })),
        discountType: discountType || "none",
        discountValue: Number(discountValue) || 0,
        taxPercent: Number(taxPercent) || 0
      };

      const res = await API.post("/Bill", payload);

      savePastBillToLocal(res.data);
      alert(`Bill saved successfully: ${res.data.invoiceNumber}`);

      fetchBills();
      fetchDailySummary();

      setBillItems([]);
      setDiscountType("none");
      setDiscountValue(0);
      setTaxPercent(18);

      localStorage.removeItem("draftBill");
    } catch (error) {
      console.error("Save Bill Error:", error.response?.data || error.message);
      alert("Error saving bill.");
    }
  };

  const fetchBills = async () => {
    try {
      const res = await API.get("/Bill");
      const localBills = getPastBillsFromLocal();

      const mergedBills = [...res.data, ...localBills];
      setPastBills(mergedBills);
    } catch (error) {
      console.error("Fetch Bills Error:", error.response?.data || error.message);
    }
  };

  const fetchDailySummary = async () => {
    try {
      const res = await API.get("/Bill/daily-summary");
      setDailySummary(res.data);
    } catch (error) {
      console.error("Fetch Daily Summary Error:", error.response?.data || error.message);
    }
  };

  const filteredBills = pastBills.filter(
    (bill) =>
      bill.invoiceNumber?.toLowerCase().includes(searchText.toLowerCase()) ||
      bill.items?.some((item) =>
        item.itemName?.toLowerCase().includes(searchText.toLowerCase())
      )
  );

  const currentBill = {
    invoiceNumber: "Preview",
    createdAt: new Date().toLocaleString(),
    items: billItems.map((item) => ({
      ...item,
      lineTotal: Number(item.unitPrice) * Number(item.quantity)
    })),
    ...summary
  };

  return (
    <div className="app">
      <Header />

      <div className="container">
        <div className="left-panel">
          <CatalogSwitcher
            setCatalogType={setCatalogType}
            onOpenCustomItemForm={() => setShowCustomItemForm(true)}
          />

          <CatalogList
            catalogType={catalogType}
            catalogItems={catalogItems}
            addToBill={addToBill}
          />

          <BillItemsTable
            billItems={billItems}
            updateItem={updateItem}
            removeItem={removeItem}
          />
        </div>

        <div className="right-panel">
          <BillSummary
            discountType={discountType}
            setDiscountType={setDiscountType}
            discountValue={discountValue}
            setDiscountValue={setDiscountValue}
            taxPercent={taxPercent}
            setTaxPercent={setTaxPercent}
            summary={summary}
            saveDraft={saveDraft}
            saveBill={saveBill}
            exportPdf={() => exportBillToPDF(currentBill)}
            exportCsv={() => exportBillsToCSV(pastBills)}
            printBill={() => window.print()}
          />

          <DailySummary dailySummary={dailySummary} />

          <PastBills
            searchText={searchText}
            setSearchText={setSearchText}
            filteredBills={filteredBills}
          />
        </div>
      </div>

      <CustomItemForm
        show={showCustomItemForm}
        onClose={() => setShowCustomItemForm(false)}
        onAddCustomItem={addCustomItem}
      />
    </div>
  );
}

export default App;