window.saveAsFile = (filename, byteBase64) => {
    const link = document.createElement('a');
    link.href = 'data:application/pdf;base64,' + byteBase64;
    link.download = filename;
    link.click();
};
function waitForTitleAndChange(newTitle) {
    const checkExist = setInterval(() => {
        const titleElement = document.querySelector('#title');
        if (titleElement) {
            titleElement.textContent = newTitle;
            clearInterval(checkExist); 
        }
    }, 100);
}
