$(document).ready(function () {
    //initialisasi sekali saat HTML selesai di load
    $('#assignmentTable').DataTable({
        dom: 'Bfrtip',
        buttons: [
            //'copy',
            //'csv',
            //'excel',
            //'pdf',
            //'print'
            {
                text: '<i class="fa fa-plus"></i>',
                titleAttr: 'Add Employee',
                action: function (e, dt, node, config) {
                    $('#modalAddAssignment').modal('show');
                }
            },
            {
                extend: 'excel',
                className: 'btn btn-success',
                text: '<i class="fa fa-file-excel-o"></i>',
                title: 'Employee Data',
                titleAttr: 'Excel',
                exportOptions: {
                    columns: 'th:not(:last-child)'
                }
            },
            {
                extend: 'pdf',
                className: 'btn btn-danger',
                text: '<i class="fas fa-file-pdf"></i>',
                title: 'Employee Data',
                titleAttr: 'PDF',

                exportOptions: {
                    columns: 'th:not(:last-child)'
                }
            },
            {
                extend: 'print',
                className: 'btn btn-dark',
                text: '<i class="fa fa-print"></i>',
                title: 'Employee Data',
                titleAttr: 'Print',

                exportOptions: {
                    columns: 'th:not(:last-child)'
                }
            },
            {
                extend: 'csv',
                className: 'btn btn-warning',
                text: '<i class="fas fa-file-csv"></i>',
                title: 'Employee Data',
                titleAttr: 'CSV',

                exportOptions: {
                    columns: 'th:not(:last-child)'
                }
            },
            {
                extend: 'copy',
                className: 'btn btn-info',
                text: '<i class="fas fa-copy"></i>',
                titleAttr: 'Copy',
                exportOptions: {
                    columns: 'th:not(:last-child)'
                }
            },
            {
                extend: 'colvis',
                className: 'btn btn-secondary',
                text: '<i class= "fa fa-filter" ></i >',
                titleAttr: 'Column Visibility',
            }

        ],
        ajax: {
            url: "https://localhost:7024/api/Students",
            dataSrc: "data"
        },
        columns: [
            { data: "nim" },
            {
                data: null,
                render: function (data, type, row) {
                    return data.firstName + ' ' + data.lastName
                }
            },
            { data: "birthDate" },
            { data: "gender" },
            { data: "phoneNumber" },
            { data: "address" },
            { data: "email" },
            { data: "majorCode" },
            { data: "courseCode" },
            {
                data: "",
                render: function (data, type, row) {
                    return `<button class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#modalEmployee"><i class="fa fa-edit"></i></button>
                            <button class="btn btn-danger" onclick="Delete('https://localhost:7024/api/Students/${row['nim']}')"><i class="fa fa-trash" aria-hidden="true"></i></button>`;

                }
            },
        ]
    });
    document.getElementById("employeeTable_wrapper").style.paddingTop = "20px";

});


//modal insert
function Insert() {
    var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
    //ini ngambil value dari tiap inputan di form nya
    //obj.Id = $("#id").val();
    obj.Name = $("#name").val();
    obj.UploadDate = $("#uploadDate").val();
    obj.Score = parseInt($("#score").val());
    obj.CourseCode = $("#courseCode").val();
    obj.StudentNim = $("#studentNim").val();
    obj.LecturerNik = $("#lecturerNik").val();
    obj.AttachmentFileId = $("#attachmentFileId").val();
    if (obj.Score === "") {
        obj.Score = null;
    }
    if (obj.AttachmentFileId === "") {
        obj.AttachmentFileId = null;
    }

    //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
    $.ajax({
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json;charset=utf-8',
            'Access-Control-Allow-Origin': "*",
            "crossDomain": true,
        },
        url: "https://localhost:7024/api/Assignments",
        type: "POST",
        data: JSON.stringify(obj), //jika terkena 415 unsupported media type (tambahkan headertype Json & JSON.Stringify();)
        dataType: 'json',
        //contentType: "application/json;charset=utf-8",
    }).done((result) => {
        //buat alert pemberitahuan jika success
        //alert('success' + JSON.stringify(result));
        $('#modalAddAssignment').modal('hide');
        $('#assignmentTable').DataTable().ajax.reload();
    }).fail((error) => {
        console.log(obj);
        //alert pemberitahuan jika gagal   
        alert('fail' + JSON.stringify(error));
        $('#modalAddAssignment').modal('hide');
        $('#assignmentTable').DataTable().ajax.reload();
        console.log(JSON.stringify(error))
    })
    e.preventDefault();
    xhr.abort()
}

function Delete(stringUrl) {
    $.ajax({
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json;charset=utf-8',
        },
        url: stringUrl,
        type: "DELETE",
        dataType: 'json',
    }).done((result) => {
        //buat alert pemberitahuan jika success
        $('#modalAddAssignment').modal('hide');
        $('#assignmentTable').DataTable().ajax.reload();
    }).fail((error) => {
        //alert pemberitahuan jika gagal   
        alert('fail' + JSON.stringify(error));
        $('#modalAddAssignment').modal('hide');
        $('#assignmentTable').DataTable().ajax.reload();
    })
}