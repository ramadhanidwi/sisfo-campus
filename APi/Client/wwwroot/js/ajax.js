/*$.ajax({
    url: "https://harry-potter-api-en.onrender.com/characters"
}).done((result) => {

    //let text = "<li>" + result.results[3].name +"</li>"
    //console.log(result.characters);

    let text = "";
    $.each(result, function (key, val) {
        text += `<tr>
                    <td>${key + 1}</td>
                    <td>${val.character}</td>
                    <td><button class="btn btn-primary" onclick="detail('https://harry-potter-api-en.onrender.com/characters/${val.id}')" data-bs-toggle="modal" data-bs-target="#modalPoke">Detail</button></td>
                </tr>`;
    })
    $("#tbodyPoke").html(text)

});*/

//datatable harry potter
$(document).ready(function () {
    //initialisasi sekali saat HTML selesai di load
    $('#myTable').DataTable({
        dom: 'Bfrtip',
        buttons: [
            //'copy',
            //'csv',
            //'excel',
            //'pdf',
            //'print'
            {
                extend: 'excel',
                className: 'btn btn-success',
                title: 'Harry Potter Characters',
                exportOptions: {
                    columns: 'th:not(:last-child)'
                }
            },
            {
                extend: 'pdf',
                className: 'btn btn-danger',
                title: 'Harry Potter Characters',
                exportOptions: {
                    columns: 'th:not(:last-child)'
                }
            },
            {
                extend: 'print',
                className: 'btn btn-primary',
                title: 'Harry Potter Characters',
                exportOptions: {
                    columns: [1, 2, 3]
                }
            },
            {
                extend: 'csv',
                className: 'btn btn-warning',
                title: 'Harry Potter Characters',
                exportOptions: {
                    columns: 'th:not(:last-child)'
                }
            },

            {
                extend: 'copy',
                className: 'btn btn-info',
                exportOptions: {
                    columns: 'th:not(:last-child)'
                }
            },
            'colvis'
        ],
        ajax: {
            url: "https://harry-potter-api-en.onrender.com/characters",
            dataSrc: ""
        },
        columns: [
            {
                data: null,
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            { data: "character" },
            { data: "hogwartsHouse" },
            {
                data: "",
                render: function (data, type, row) {
                    return `<button class="btn btn-primary" onclick="detail('https://harry-potter-api-en.onrender.com/characters/${row['id']}')" data-bs-toggle="modal" data-bs-target="#modalPoke">Detail</button>`;
                }
            },
        ]
    });
    document.getElementById("myTable_wrapper").style.paddingTop = "20px";

});

/*data: "",
    render: function (data, type, row) {
        return `<button class="btn btn-primary" onclick="detail('${row['hero_id']}', 
                    '${row['localized_name']}',
                    '${row['primary_attr']}',
                    '${row['attack_type']}', 
                    '${row['roles']}',
                    'https://api.opendota.com${row['img']}')"
                    data-bs-toggle="modal" data-bs-target="#modalDota">Detail</button>`;
    }
            }*/

//modal harry potter
function detail(stringUrl) {
    $.ajax({
        url: stringUrl
    }).done((result) => {
        let text = "";
        $("h1#exampleModalLabel.modal-title").html(result.character);
        $("div.modal-body img.img-fluid").attr("src", result.image);
        $("#nickname").html(result.nickname);
        $("#house").html(result.hogwartsHouse);
        $("#played").html(result.interpretedBy);
        $.each(result.child, function (key, val) {
            text += `
                    <li>${val}</li>
                    `;
        })
        if (result.child.length == 0) {
            $("#hide").hide();
        }
        else {
            $("#hide").show();
            $("#child").html(text);
        }
    });
}

//datatable exmployee
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
            url: "https://localhost:7024/api/Assignments",
            dataSrc: "data"
        },
        columns: [
            { data: "id" },
            { data: "name" },
            { data: "uploadDate" },
            { data: "score" },
            { data: "courseCode" },
            { data: "studentNim" },
            { data: "lecturerNik" },
            { data: "attachmentFileId" },
            {
                data: "",
                render: function (data, type, row) {
                    return `<button class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#modalEmployee"><i class="fa fa-edit"></i></button>
                            <button class="btn btn-danger" onclick="Delete('https://localhost:7024/api/Assignments/${row['id']}')"><i class="fa fa-trash" aria-hidden="true"></i></button>`;

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

//modal update
function Update() {
    var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
    //ini ngambil value dari tiap inputan di form nya
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
        type: "PUT",
        data: JSON.stringify(obj), //jika terkena 415 unsupported media type (tambahkan headertype Json & JSON.Stringify();)
        dataType: 'json',
        //contentType: "application/json;charset=utf-8",
    }).done((result) => {
        //buat alert pemberitahuan jika success
        //alert('success' + JSON.stringify(result));
        $('#modalEmployee').modal('hide');
        $('#employeeTable').DataTable().ajax.reload();
    }).fail((error) => {
        console.log(obj);
        //alert pemberitahuan jika gagal   
        alert('fail' + JSON.stringify(error));
        $('#modalEmployee').modal('hide');
        $('#employeeTable').DataTable().ajax.reload();
    })
}

$(document).ready(function () {
    $('#univTable').DataTable();
});