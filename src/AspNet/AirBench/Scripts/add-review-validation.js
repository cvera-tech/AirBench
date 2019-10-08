(function () {
    const form = document.getElementById('AddReviewForm')
    const description = document.getElementById('Description');
    const rating = document.getElementById('Rating');
    const submit = document.getElementById('Submit');

    form.addEventListener('input', () => {
        if (description.validity.valid && rating.validity.valid) {
            submit.setAttribute('class', 'btn btn-primary');
            submit.removeAttribute('disabled');
        } else {
            submit.setAttribute('class', 'btn btn-primary disabled');
            submit.setAttribute('disabled', 'disabled');
        }
    });
})()