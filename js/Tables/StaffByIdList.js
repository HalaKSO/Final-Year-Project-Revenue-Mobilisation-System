var datatables;

$(document).ready(function () {
    datatables = $('#staffTable').DataTable({
        "ajax": {
            "url": "/OfficerAdmin/StaffList",
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
                "data": "sFullName",
                "width": "30%",

            },
            {
                "data": "genderType",
                "width": "10%",

            },
            {
                "data": "officerContact",
                "width": "10%",
                
            },
            {
                "data": "rankName",
                "width": "10%",
                
            },

            {
                "data": "staffId",
                "width": "20%",
                "render": function (data) {
                    return `<div class='text-center'>
                        
                        <a class='btn btn-secondary'   href='/OfficerAdmin/UpdateStaff?id=${data}' title='Edit'><span class='fas fa-edit'></span></a>
                        <a class='btn btn-success text-white'  href='/OfficerAdmin/StaffDetails?id=${data}' title='Delete' style='cursor:pointer' ><span class='fas fa-trash-alt'></span></a>
                   
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