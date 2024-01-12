const tblName = "Tbl_name";

$("#btn-save").click(function () {
  let lst = [];
  if (localStorage.getItem(tblName) != null) {
    lst = JSON.parse(localStorage.getItem(tblName));
  }

  const name = $("#textvalue").val();
  const data = {
    Name: name,
  };

  lst.push(data);
  console.log({ lst });
  localStorage.setItem(tblName, JSON.stringify(lst));
});
