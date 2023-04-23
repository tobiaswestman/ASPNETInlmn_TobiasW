const toggleBtn = document.querySelector('[data-option="toggle"]')
toggleBtn.addEventListener('click', function () {
    const element = document.querySelector(toggleBtn.getAttribute('data-target'))

    if (!element.classList.contains('hide')) {
        element.classList.add('hide')
    }

    else {
        element.classList.remove('hide')
    }
})

document.querySelector("#header").addEventListener("click", () => {
    document.querySelector("#menu").classList.toggle("hide");
});
