const searchInput = document.getElementById("searchInput");
const statusFilter = document.getElementById("statusFilter");
const orderRows = document.querySelectorAll("#orderTable tr");

function filterTable() {
    const searchText = searchInput.value.toLowerCase();
    const statusValue = statusFilter.value;

    orderRows.forEach(row => {
        const text = row.textContent.toLowerCase();
        const status = row.querySelector(".badge").classList[1];

        const matchText = text.includes(searchText);
        const matchStatus = (statusValue === "all" || status.includes(statusValue));

        row.style.display = (matchText && matchStatus) ? "" : "none";
    });
}

searchInput.addEventListener("keyup", filterTable);
statusFilter.addEventListener("change", filterTable);
