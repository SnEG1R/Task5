let counter = 1;
let counterLoad = 0;

let tableContainer = document.querySelector('.table-container');
let tableBody = tableContainer.querySelector('.table tbody');
let seedInput = document.getElementById('input-seed');
let select = document.querySelector('.form-select');
let inputErrorValue = document.getElementById('input-error-value');

window.onload = async function () {
    await GetPersonData(false, 20);
}

tableContainer.addEventListener('scroll', async () => {
    await checkPosition();
});

async function GetPersonData(reset = false, countLoadRecord = 10) {
    let response = await sendData(countLoadRecord);
    setDataTable(response);

    if (reset) {
        resetAll();
    } else {
        seedInput.value = +seedInput.value + countLoadRecord;
    }
}

async function checkPosition() {
    const height = tableBody.offsetHeight;
    const screenHeight = tableContainer.offsetHeight;

    const scrolled = tableContainer.scrollTop;
    const threshold = height - screenHeight / 20
    const position = scrolled + screenHeight;

    if (position >= threshold && counter !== counterLoad) {
        counterLoad = counter;
        
        await GetPersonData();

        counterLoad = counter;
    }
}

async function sendData(countLoadRecord) {
    let seed = +seedInput.value;

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