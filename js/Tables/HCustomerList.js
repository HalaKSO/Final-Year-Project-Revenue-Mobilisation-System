var datatables;

$(document).ready(function () {
    datatables = $('#houseCustomerTable').DataTable({
        "ajax": {
            "url": "/House/CustomersListTable",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "base64stringpic",
                "width": "20%",
                "render": function (data) {

                    return `<div  >
                        
                        <img src='data:image/jpg;base64,${data}' alt='customer photo' width='50px' height='50px' class='rounded-circle'/>
                        
                   
                        </div>`

                }

            },

            {
                "data": "fullName",
                "width": "30%",

            },
            {
                "data": "genderType",
                "width": "15%",

            },
            {
                "data": "customerContact",
                "width": "15%",

            },

            {
                "data": "customerId",
                "width": "20%",
                "render": function (data) {
                    return `<div class='text-center'>
                        
                        <a class='btn btn-secondary'   href='/House/AddHouse/${data}' title='Register House'><span class='fas fa-house'></span></a>
                        <a class='btn btn-success'   href='/House/Details?id=${data}' title='Detail'><span class='fas fa-detail'></span></a>
                   
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