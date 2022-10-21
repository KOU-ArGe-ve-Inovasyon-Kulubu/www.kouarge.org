jQuery(document).ready(function () {
    $(function () {
        $("#faculty").change(function () {
            var id = $("#faculty").val();
            if (id > 0) {
                var row = "<option value=''>Seçim Yapınız</option>";
                $.getJSON("/Account/GetDepartment", { id: $("#faculty").val() }, function (d) {
                    $("#department").empty();
                    $("#department").prop("disabled", false);
                    $.each(d, function (i, v) {
                        row += "<option value=" + v.id + ">" + v.name + "</option>";
                    });
                    $("#department").html(row);
                })
            }
            var row = "<option value=''>Seçim Yapınız</option>";
            $("#department").html(row);
            $("#department").prop("disabled", true);
        })
    })


    $(function () {
        $("#submit").click(function () {
            if ($("#kvkk").is(':checked') == false) {
                $('#kvkkModal').modal('show');
            }
        })

        //$('#kvkkModal').modal({ backdrop: 'static', keyboard: false });
        $('#kvkkModal').modal({ backdrop: 'static', keyboard: false, show: false });
        //$('#kvkkModal').data('bs.modal').options.backdrop = 'static';

        $("#kvkk").click(function () {
            if ($("#kvkk").is(':checked') == true)
                $('#kvkkModal').modal('show');

        })

        $("#kvkkModal").on("click", "#ok", function () {
            $("#kvkk").prop('checked', true);
            $('#kvkkModal').modal('hide');
        });

        $("#kvkkModal").on("click", "#cancel", function () {
            $("#kvkk").prop('checked', false);
        });

        $('#kvkkModal').on('show.bs.modal', function (e) {
            $("html").css("overflow-y", "hidden");
        })
        $('#kvkkModal').on('hide.bs.modal', function (e) {
            $("html").css("overflow-y", "visible");
        })

    })

});




