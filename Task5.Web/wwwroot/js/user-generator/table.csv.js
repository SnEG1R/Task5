function tableToCSV() {
    let csvData = [];
    const rows = document.getElementsByTagName('tr');

    for (let i = 0; i < rows.length; i++) {
        const cols = rows[i].querySelectorAll('td,th');
        const csvrow = [];

        for (let j = 0; j < cols.length; j++) {
            csvrow.push(cols[j].innerHTML.trim().normalize());
        }

        if (csvrow.length !== 0) {
            csvData.push(csvrow.join(":"));
        }
    }

    csvData = csvData.join('\n');

    downloadCSVFile(csvData);

}

function downloadCSVFile(csv_data) {
    let csvFile = new Blob([csv_data], {
        type: "text/csv"
    });

    const tempLink = document.createElement('a');

    tempLink.download = "scv.csv";
    tempLink.href = window.URL.createObjectURL(csvFile);

    tempLink.style.display = "none";
    document.body.appendChild(tempLink);

    tempLink.click();
    document.body.removeChild(tempLink);
}