$(document).ready(function () {
  let $listProductHTML = $(".listProduct");
  let $listCartHTML = $(".listCart");
  let $iconCart = $(".icon-cart");
  let $iconCartSpan = $(".icon-cart span");
  let $body = $("body");
  let $closeCart = $(".close");
  let products = [];
  let cart = [];

  //show card togle
  $iconCart.click(function () {
    $body.toggleClass("showCart");
  });
  $closeCart.click(function () {
    $body.toggleClass("showCart");
  });

  const addDataToHTML = () => {
    // add new datas
    if (products.length > 0) {
      products.forEach((product) => {
        let $newProduct = $("<div>", {
          "data-id": product.id,
          class: "item",
          html: `<img src="${product.image}" alt="">
                            <h2>${product.name}</h2>
                            <div class="price">$${product.price}</div>
                            <button class="addCart">Add To Cart</button>`,
        });
        $listProductHTML.append($newProduct);
      });
    }
  };

  //eveentlistenner for addtocart id
  $listProductHTML.on("click", ".addCart", function () {
    let $positionClick = $(this).closest(".item");
    let id_product = $positionClick.data("id");
    addToCart(id_product);
  });

  const addToCart = (product_id) => {
    let positionThisProductInCart = cart.findIndex(
      (value) => value.product_id == product_id
    );
    if (cart.length <= 0) {
      cart = [
        {
          product_id: product_id,
          quantity: 1,
        },
      ];
    } else if (positionThisProductInCart < 0) {
      cart.push({
        product_id: product_id,
        quantity: 1,
      });
    } else {
      cart[positionThisProductInCart].quantity =
        cart[positionThisProductInCart].quantity + 1;
    }
    sucessMessage("Complete Add Cart");
    addCartToHTML();
    addCartToMemory();
  };

  const addCartToMemory = () => {
    localStorage.setItem("cart", JSON.stringify(cart));
  };

  //show total quantity & add cart show
  const addCartToHTML = () => {
    $listCartHTML.empty();
    let totalQuantity = 0;
    if (cart.length > 0) {
      cart.forEach((item) => {
        totalQuantity = totalQuantity + item.quantity;
        let $newItem = $("<div>", {
          class: "item",
          "data-id": item.product_id,
          html: `<div class="image">
                                    <img src="${
                                      products.find(
                                        (p) => p.id == item.product_id
                                      ).image
                                    }">
                                </div>
                                <div class="name">${
                                  products.find((p) => p.id == item.product_id)
                                    .name
                                }</div>
                                <div class="totalPrice">$${
                                  products.find((p) => p.id == item.product_id)
                                    .price * item.quantity
                                }</div>
                                <div class="quantity">
                                    <span class="minus"><</span>
                                    <span>${item.quantity}</span>
                                    <span class="plus">></span>
                                </div>`,
        });
        $listCartHTML.append($newItem);
      });
    }
    $iconCartSpan.text(totalQuantity);
  };

  $listCartHTML.on("click", ".minus, .plus", function () {
    let $positionClick = $(this).closest(".item");
    let product_id = $positionClick.data("id");
    let type = $(this).hasClass("plus") ? "plus" : "minus";
    changeQuantityCart(product_id, type);
  });

  const changeQuantityCart = (product_id, type) => {
    let positionItemInCart = cart.findIndex(
      (value) => value.product_id == product_id
    );

    if (positionItemInCart >= 0) {
      let info = cart[positionItemInCart];
      switch (type) {
        case "plus":
          confirmMessage(
            "Are you sure want to increase product quantity?"
          ).then(function (result) {
            if (result) {
              cart[positionItemInCart].quantity =
                cart[positionItemInCart].quantity + 1;
              console.log(cart[positionItemInCart]);
              addCartToHTML();
              addCartToMemory();
            }
          });
          break;

        default:
          let changeQuantity = cart[positionItemInCart].quantity - 1;
          if (changeQuantity > 0) {
            confirmMessage("Are you sure want to decrease the quantity?").then(
              function (result) {
                if (result) {
                  cart[positionItemInCart].quantity = changeQuantity;
                  addCartToHTML();
                  addCartToMemory();
                }
              }
            );
          } else {
            confirmMessage(
              "Are you sure want to remove this item from the cart?"
            ).then(function (result) {
              if (result) {
                cart.splice(positionItemInCart, 1);
                addCartToHTML();
                addCartToMemory();
              }
            });
          }
          break;
      }
    }
  };

  const initApp = () => {
    // get data product
    $.getJSON("products.json", function (data) {
      products = data;
      addDataToHTML();

      // get data cart from memory
      if (localStorage.getItem("cart")) {
        cart = JSON.parse(localStorage.getItem("cart"));
        addCartToHTML();
      }
    });
  };

  initApp();
});
