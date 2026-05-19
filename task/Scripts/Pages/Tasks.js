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

                location.reload();
            },

            error: function (error) {

                alert(error)

            }

        });
    })

    $('.btn-edit').click(function () {
        const id = $(this).attr('edit-id')

        $.ajax({
            url: `/Task/Edit`,
            type: "GET",
            data: {
                taskId : id
            },
            success: function (response) {
                const data = response.data

                const myModal = new bootstrap.Modal('#AddTaskModal', {
                    keyboard: false
                })

                myModal.show()


                $("#idTask").val(data.Id)


                $("#titleTasks").val(data.Title)

                $("#desciptionTasks").val(data.Description)
                console.log(data)

                if (data.DueDate) {
                    $("#dueDateTasks").val(parseMvcDate(data.DueDate))

                } else {
                    $("#dueDateTasks").val("")
                }

                $("#stateTasks").prop("selectedIndex", data.State);

            }
        })

    })

    $('.btn-delete').click(function () {
        const id = $(this).attr('deleted-id')

        $.ajax({
            url: `/Task/Delete`,
            type: "GET",
            data: {
                taskId: id
            },
            success: function (response) {

                location.reload();
            },

            error: function (error) {

                alert(error)

            }
        })
    });


    function parseMvcDate(value) {

        const timestamp =
            parseInt(
                value.match(/\d+/)[0]
            );

        const date =
            new Date(timestamp);

        return date.getFullYear() + "-" +
            String(date.getMonth() + 1)
                .padStart(2, '0') + "-" +
            String(date.getDate())
                .padStart(2, '0') + "T" +
            String(date.getHours())
                .padStart(2, '0') + ":" +
            String(date.getMinutes())
                .padStart(2, '0');
    }
})