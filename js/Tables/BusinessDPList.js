var datatables;

$(document).ready(function () {
    datatables = $('#businessDPTable').DataTable({
        "ajax": {
            "url": "/BusinessDailyPayment/BusinessDPList",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "customerName",
                "width": "20%",

            },

            {
                "data": "businessName",
                "width": "20%",

            },
            {
                "data": "busAmount",
                "width": "20%",

            },
            {
                "data": "businessDailyPaymentDate",
                "width": "20%",
                "render": function (data) {
                    var date = new Date(data);
                    return (date.toLocaleDateString())
                }

            },

            {
                "data": "busPaymentId",
                "width": "20%",
                "render": function (data) {
                    return `<div class='text-center'>
                        
                        <a class='btn btn-secondary'   href='/BusinessDailyPayment/Details?id=${data}' title='Details'><span class='fas fa-money'></span></a>

                        
                   
                        </div>`

                }
            }

        ],
        "language": {
            "processing": '<div class="spinner-border text-primary"></div>',
            zeroRecords: "No record found"
        },
        "width": "100%",
        "lengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "All"]],
        responsive: true,


    });


});

function Delete(path) {
    swal({
        title: "Are you sure you want to delete?",
        text: "deletion cannot be undone",
        icon: "warning",
        buttons: true,
        dangermode: true

    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                url: path,
                type: "DELETE",
                success: function (data) {
                    if (data.success) {
                        //toastr.success(data.message, "Congratulations");
                        swal("Congratulation!", data.message, "success");
                        datatables.ajax.reload();
                    } else {
                        //toastr.error(data.message, "Error");
                        swal("Sorry!", data.message, "Error");
                    }
                }
            })
        }

    })
}