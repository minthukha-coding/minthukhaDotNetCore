function sucessMessage(message) {
    Swal.fire({
        position: "top-end",
        icon: "success",
        title: message,
        showConfirmButton: false,
        timer: 1500
      });
}
function confirmMessage(message) {
    return new Promise(function (myResolve, myReject) {
      Swal.fire({
        title: "Confirm",
        text: message,
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "Yes"
      }).then((result) => {
        myResolve(result.isConfirmed);
      });
    });
  }