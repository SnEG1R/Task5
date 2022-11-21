let counter = 1;
let counterLoad = 0;

let tableContainer = document.querySelector('.table-container');
let tableBody = tableContainer.querySelector('.table tbody');
let seedInput = document.getElementById('input-seed');
let select = document.querySelector('.form-select');

window.onload = async function () {
    await GetPersonData();
}

tableContainer.addEventListener('scroll', async () => {
    await checkPosition();
});

async function GetPersonData(reset) {
    let response = await sendData();
    setDataTable(response);

    if (reset) {
        resetAll();
    }
}

async function checkPosition() {
    const height = tableBody.offsetHeight;
    const screenHeight = tableContainer.offsetHeight;

    const scrolled = tableContainer.scrollTop;
    const threshold = height - screenHeight / 8
    const position = scrolled + screenHeight;

    if (position >= threshold && counter !== counterLoad) {
        counterLoad = counter;

        await GetPersonData();

        counterLoad = counter;
    }
}

async function sendData() {
    seedInput.value = +seedInput.value + 20;
    let seed = +seedInput.value;

    let region = select.options[select.selectedIndex].value;

    return await fetch(`UserGenerator/Index?region=${region}`, {
        method: 'POST',
        body: JSON.stringify(seed),
        headers: {
            "Content-Type": "application/json"
        }
    });
}

function setDataTable(response) {
    let tr = document.createElement('tr');

    function generateRandomValue(low, high) {
        return low + Math.random() * (high - low);
    }

    response.json().then(data => {
        data.forEach((item) => {
            let html = `<tr>
                            <td>${counter++}</td>
                            <td>${generateRandomValue(1000000000000000000, 1999999999999999999)}</td>
                            <td>${item.fullName}</td>
                            <td>${item.address}</td>
                            <td>${item.phoneNumber}</td>
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