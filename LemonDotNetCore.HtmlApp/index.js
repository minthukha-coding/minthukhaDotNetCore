const tblName = "Tbl_name";

$("#btn-save").click(function () {
    createData();
});

function createData() {
  let lst = [];

  if (localStorage.getItem(tblName) != null) {
    lst = JSON.parse(localStorage.getItem(tblName));
  }

  const name = $("#textvalue").val();
  const data = {
    ID: uuidv4(),
    Name: name,
  };

  lst.push(data);
  console.log({ lst });
  localStorage.setItem(tblName, JSON.stringify(lst));
}

function readData() {
  if (localStorage.getItem(tblName) == null) return;

    var jsonStr = localStorage.getItem(tblName);
    var lst = JSON.parse(jsonStr);
    let trRows = '';
    let count = 0;
    console.log(lst);
    lst.forEach(item => {
        // console.log({item});
        trRows +=  ` 
      <tr>
        <td></td>
        <td>${++count}</td>
        <td>${item.Name}</td>
      </tr>`;
    });
    console.log(trRows);

    $('#table_data').html(trRows);
}

function uuidv4() {
  return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, (c) =>
    (
      c ^
      (crypto.getRandomValues(new Uint8Array(1))[0] & (15 >> (c / 4)))
    ).toString(16)
  );
}

read();