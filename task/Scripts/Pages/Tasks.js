$(document).ready(function () {

    let timeout;

    console.log(resources);


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

   events() 

    $('#search-task').on('input', function () {
        clearTimeout(timeout);

        let value = $(this).val();

        timeout = setTimeout(function () {

                $.ajax({
                    url: `/Task/SearchTask`,
                    type: "GET",
                    data: {
                        search: value
                    },
                    success: function (response) {

                        const { data } = response

                      

                        $('.card-task').html("")

                        setListCards(data)

                        events()
                    }
                });
            }

            , 500);

    })


    function events() {


        $('.btn-edit').click(function () {
            const id = $(this).attr('edit-id')

            $.ajax({
                url: `/Task/Edit`,
                type: "GET",
                data: {
                    taskId: id
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
    }

    function setListCards(listCard) {


        const stateText = {
            1: "Pending",
            2: "InProgress",
            3: "Finished",
            4: "Cancelled"
        }

        const stateView = {
            1: "text-bg-warning",
            2: "text-bg-primary",
            3: "text-bg-success",
            4: "text-bg-secondary"
        }

        

        const cardTask = $('.card-task')

        listCard.forEach((x) => {
            const classe = $('.card').first().clone()
            classe.removeClass('d-none')
            classe.find(".card-title").text(x.Title)
            classe.find(".card-text").text(x.Description)
            classe.find(".btn-edit").attr("edit-id", x.Id)
            classe.find(".btn-delete").attr("deleted-id", x.Id)

            classe.find('.badge').removeClass().addClass(`badge ${stateView[x.State]} badge-title`)
            classe.find('.badge-title').html(resources[stateText[x.State]]);
            


            if (x.IsExpired) {
                classe.find('.icon').removeClass('d-none')
            }


            cardTask.append(classe)
        })



    }

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