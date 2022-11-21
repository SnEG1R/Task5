let generateSeedBtn = document.querySelector('.generate-seed');

generateSeedBtn.addEventListener('click',  async () => {
    seedGenerate();
    await GetPersonData(true, 20);
});

seedInput.addEventListener('change',  async () => {
    await GetPersonData(true, 20);
});

function seedGenerate() {
    let low = 0;
    let high = 999999

    seedInput.value = Math.round(low + Math.random() * (high - low));
}