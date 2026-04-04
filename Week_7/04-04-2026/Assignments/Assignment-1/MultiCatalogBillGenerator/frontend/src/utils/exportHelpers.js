import jsPDF from "jspdf";
import autoTable from "jspdf-autotable";

export const exportBillToPDF = (bill) => {
  const doc = new jsPDF();

  doc.setFontSize(16);
  doc.text("Invoice", 14, 15);

  doc.setFontSize(11);
  doc.text(`Invoice No: ${bill.invoiceNumber || "Draft"}`, 14, 25);
  doc.text(`Date: ${bill.createdAt || new Date().toLocaleString()}`, 14, 32);

  autoTable(doc, {
    startY: 40,
    head: [["Item", "Qty", "Price", "Total"]],
    body: bill.items.map((item) => [
      item.itemName,
      item.quantity,
      item.unitPrice,
      item.lineTotal || item.unitPrice * item.quantity
    ])
  });

  let y = doc.lastAutoTable.finalY + 10;
  doc.text(`Subtotal: ${bill.subTotal}`, 14, y);
  doc.text(`Discount: ${bill.discountAmount}`, 14, y + 7);
  doc.text(`Tax: ${bill.taxAmount}`, 14, y + 14);
  doc.text(`Grand Total: ${bill.grandTotal}`, 14, y + 21);

  doc.save(`${bill.invoiceNumber || "invoice"}.pdf`);
};

export const exportBillsToCSV = (bills) => {
  let rows = [["Invoice No", "Date", "Total"]];

  bills.forEach((bill) => {
    rows.push([bill.invoiceNumber, bill.createdAt, bill.grandTotal]);
  });

  const csvContent = rows.map((r) => r.join(",")).join("\n");
  const blob = new Blob([csvContent], { type: "text/csv;charset=utf-8;" });
  const url = window.URL.createObjectURL(blob);

  const link = document.createElement("a");
  link.href = url;
  link.setAttribute("download", "bills.csv");
  document.body.appendChild(link);
  link.click();
  document.body.removeChild(link);
};