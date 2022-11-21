let generateSeedBtn = document.querySelector('.generate-seed');

generateSeedBtn.addEventListener('click',  async () => {
    seedGenerate();
    await GetPersonData(true);
});

seedInput.addEventListener('change',  async () => {
    seedInput.value = seedInput.value - 20;
    await GetPersonData(true);
});

function seedGenerate() {
    let low = 0;
    let high = 999999

    seedInput.value = Math.round(low + Math.random() * (high - low));
}