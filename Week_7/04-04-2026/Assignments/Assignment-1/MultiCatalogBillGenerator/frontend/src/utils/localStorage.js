export const saveDraftBill = (bill) => {
  localStorage.setItem("draftBill", JSON.stringify(bill));
};

export const loadDraftBill = () => {
  const data = localStorage.getItem("draftBill");
  return data ? JSON.parse(data) : null;
};

export const savePastBillToLocal = (bill) => {
  const existing = JSON.parse(localStorage.getItem("pastBills")) || [];
  existing.unshift(bill);
  localStorage.setItem("pastBills", JSON.stringify(existing));
};

export const getPastBillsFromLocal = () => {
  return JSON.parse(localStorage.getItem("pastBills")) || [];
};