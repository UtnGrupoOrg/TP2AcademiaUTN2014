function CloseError_Click() {
    var div = document.getElementById('PageContent_ErrorBox');
    if (div) {
        div.parentNode.removeChild(div);
    }
    var div = document.getElementById('PageContent_MessageBox');
    if (div) {
        div.parentNode.removeChild(div);
    }
}