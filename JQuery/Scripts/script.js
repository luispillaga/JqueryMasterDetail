function empezar() {
    alert("Hey! I am ready ");
}
function addNewOrder() {
    $("#newOrderModal").modal();
}
$("#save").click(function (e) {
    e.preventDefault();
    if ($.trim($("#placa").val()) == "" || $.trim($("#modelo").val()) == "" || $.trim($("#color").val()) == "") return;
    var placa = $("#placa").val(),
        modelo = $("#modelo").val(),
        color = $("#color").val(),
        detailsTableBody = $("table tbody");
    var nFilas = $("table >tbody >tr").length;
    var num = 0;
    var num = nFilas + 1;
    var productItem = '<tr><td>' + num + '</td><td>' + placa + '</td><td>' + modelo + '</td><td>' + color + '</td><td>' + '</td></tr>';
    detailsTableBody.append(productItem);
    $('#newOrderModal').modal('toggle');
});