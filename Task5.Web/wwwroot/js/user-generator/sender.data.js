let counter = 1;
let counterLoad = 0;

let seed = 0;
let threshold;

let tableContainer = document.querySelector('.table-container');
let tableBody = tableContainer.querySelector('.table tbody');
let seedInput = document.getElementById('input-seed');
let select = document.querySelector('.form-select');
let inputErrorValue = document.getElementById('input-error-value');

window.onload = async function () {
    await GetPersonData(true, 20);
    seed = 20;
}

async function GetPersonData(reset = false, countLoadRecord = 10) {
    let response = await sendData(countLoadRecord);
    setDataTable(response);

    if (reset) {
        resetAll();
    } else {
        seedInput.value = +seedInput.value + countLoadRecord;
        seed = seed + countLoadRecord;
    }
}

async function checkPosition() {
    const height = tableBody.offsetHeight;
    const screenHeight = tableContainer.offsetHeight;

    const scrolled = tableContainer.scrollTop;
    threshold = height - screenHeight / 10000;
    console.log(threshold)
    if (threshold <= 200)
        return;

    const position = scrolled + screenHeight;

    if (position >= threshold && counter !== counterLoad) {
        counterLoad = counter;

        await GetPersonData();
    }
}

async function sendData(countLoadRecord) {
    console.log(seed)

    let region = select.options[select.selectedIndex].value;
    let errorValue = +inputErrorValue.value;

    return await fetch(`UserGenerator/Index?region=${region}`, {
        method: 'POST',
        body: JSON.stringify({
            seed: seed, errorValue: errorValue,
            countLoadRecord: countLoadRecord
        }),
        headers: {
            "Content-Type": "application/json"
        }
    });
}