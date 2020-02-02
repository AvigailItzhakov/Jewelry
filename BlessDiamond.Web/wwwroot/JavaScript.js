$(() => {
    $("#editbtn").on('click', function () {
        $("#editmodal").modal('show');
    });
    $("#closeedit").on('click', function () {
        $("#editmodal").modal('hide');
    });

    $("#submitPaymentBtn").on('click', function () {
        let amount = $("#amount").val();
        $("#amount").val('Add a Payment');
        let id = $("#buyerid").val();
        console.log(id);
        $.post('/home/addPayment', { id, amount }, function (dateTime) {

            $(".table").append("<tr><td>" + dateTime + "</td> <td>" + amount + "</td> <td>amount </td></tr>");
            <tr>
                <td>@h.Date</td>
                <td>@h.Amount</td>
                <td>@Model.ProductId</td>
            </tr>
        })
    });


});