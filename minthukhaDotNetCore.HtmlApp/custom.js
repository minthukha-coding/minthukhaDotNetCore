function successMessage(message) {
  // sweetalert
  // Swal.fire({
  //     title: "Success",
  //     text: message,
  //     icon: "success"
  // });

  // alert(message);

  Notiflix.Report.success(
      "Notiflix Success",
      message
    );
}

function confirmMessage(message) {
  //notiflix
  return new Promise(function (myResolve,myReject){
   Notiflix.Confirm.show(
       "Confirm",
       message,
       'Yes',
       'No',
       function okCb(){
           myResolve(true);
       },
       function cancelCb(){
           myResolve(false);
       }
     );
})

    //sweetalert
    // return new Promise(function (myResolve, myReject) {
    //     Swal.fire({
    //         title: "Confirm",
    //         text: message,
    //         icon: "warning",
    //         showCancelButton: true,
    //         confirmButtonText: "Yes"
    //     }).then((result) => {
    //         myResolve(result.isConfirmed);
    //     });
    // });

    // return new Promise(function (myResolve, myReject) {
    //     const result = confirm(message);
    //     myResolve(result);
    // });
  }