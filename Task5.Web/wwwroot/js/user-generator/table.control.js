function setDataTable(response) {
    let tr = document.createElement('tr');

    function generateRandomValue(low, high) {
        return Math.round(low + Math.random() * (high - low));
    }

    response.json().then(data => {
        data.forEach((item) => {
            let html = `<tr>
                            <td>${counter++}</td>
                            <td>${generateRandomValue(100000000, 999999999)}</td>
                            <td>${item.fullName.slice(-40)}</td>
                            <td>${item.address.slice(-90)}</td>
                            <td>${item.phoneNumber.slice(-30)}</td>
                        </tr>`;

            htmlToTable(html, tableBody);
        });

        tableBody.appendChild(tr);
    });
}

function resetAll() {
    $(tableBody).find('tr').remove();
    counter = 1;
    tableContainer.scrollTo(0, 0);
}

function htmlToTable(html, parent) {
    let tr = document.createElement('tr');
    html = html.trim();
    tr.innerHTML = html;
    return parent.appendChild(tr);
}