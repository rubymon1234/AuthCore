$((() => {
    calculateQuantity()
}));
function calculateQuantity(quantity) {

    if (quantity !=undefined) {
        let productPrice = $("#ProductPrice").val();
        totalPrice = (productPrice * quantity);
        $("#totalPrice").text(totalPrice);
        $("#quantity").text(quantity);
        $("#individualPrice").text(totalPrice);
    }
}
