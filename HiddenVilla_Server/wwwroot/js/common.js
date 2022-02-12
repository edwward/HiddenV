/*js funkce k toastr notifikacim*/

window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Operation Successful", { timeOut: 10000 });
    }
    if (type === "error") {
        toastr.error(message, "Operation Failed", { timeOut: 10000 });
    }
}

window.ShowSwal = (type, message) => {
    if (type === "success") {
        Swal.fire(
            'Success!',
            message,
            'success'
        )
    }
    if (type === "error") {
        Swal.fire(
            'Error!',
            message,
            'error'
        )
    }
}

function ShowDeleteconfirmationModal() {
    $('#deleteConfirmationModal').modal('show');
}

function HideDeleteconfirmationModal() {
    $('#deleteConfirmationModal').modal('hide');
}