// Get a reference to all file input elements on the page
const inputElements = document.querySelectorAll('input[type="file"]');
// Loop through each input element and create a FilePond instance
inputElements.forEach(inputElement => {
    const pond = FilePond.create(inputElement);
    pond.setOptions({
        storeAsFile: true
    });
});