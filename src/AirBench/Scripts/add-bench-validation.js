(function () {
    const form = document.getElementById('AddBenchForm');
    const description = document.getElementById('Description');
    const seats = document.getElementById('NumberSeats');
    const latitude = document.getElementById('Latitude');
    const longitude = document.getElementById('Longitude');
    const submit = document.getElementById('Submit');

    form.addEventListener('input', () => {
        if (description.validity.valid && latitude.validity.valid &&
            longitude.validity.valid && seats.validity.valid) {
            submit.setAttribute('class', 'btn btn-primary');
            submit.removeAttribute('disabled');
        } else {
            submit.setAttribute('class', 'btn btn-primary disabled');
            submit.setAttribute('disabled', 'disabled');
        }
    });
})()