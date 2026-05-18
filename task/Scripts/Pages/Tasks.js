$(document).ready(function () {
    $("#add-task").click(function () {
        $("#idTask").val("")
        $("#titleTasks").val("")

        $("#desciptionTasks").val("")

        $("#dueDateTasks").val("")

        $("#stateTasks").prop("selectedIndex", 0);
    })

    $("#SaveTask").click(function () {



        const token = $('input[name="__RequestVerificationToken"]').val()

        const Id = $("#idTask").val()

        const UserId = $("#userId").val()

        const Title = $("#titleTasks").val()

        const Description = $("#desciptionTasks").val()

        const DueDate = $("#dueDateTasks").val()

        const State = $("#stateTasks").val()

        const body = {
            __RequestVerificationToken: token,
            Id,
            Title,
            State,
            Description,
            DueDate,
            UserId
        }


        $.ajax({

            url: "/Task/RegisterTask",

            type: "POST",

            data: body,

            success: function (response) {

                $(".btn-close").click()

            },

            error: function (error) {

                console.log(error);

            }

        });
    })
})