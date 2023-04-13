//Detail Function to Get Data From APi Local

$(document).ready(function () {                                             //akan di inisialisasi sekali ketika html di load
     $('#tableStd').DataTable({
        ajax: {
            url: "https://localhost:7024/api/Students",   //object ajax sudah di tentukan dari sananya, masukan URL APi
            dataSrc: "data",                                             //berisi array of object dari data yang ada pada APi
            dataType: "JSON"
        },
        columns: [                          //disesuaikan dengan jumlah column yang ada pada index cshtml, berisi object object yang ada pada APi
            {
                data: null,
                render: function (data, type, row, nomor) {
                    return nomor.row + nomor.settings._iDisplayStart + 1;
                }
            },
            { data: "nim" },
            { data: "firstName" },
            { data: "lastName" },
            { data: "birthDate" },
            { data: "gender" },
            { data: "phoneNumber" },
            { data: "address" },
            { data: "email" },
            { data: "majorCode" },
            { data: "courseCode" }
        ]
           
    });


//    function ChangeUrl() {
//        document.getElementById('urlProfile').setAttribute('href',)
//    }
//function createDynamicURL(){
//    //The variable to be returned
//    var URL;

//    //The variables containing the respective IDs
//    var companyID =...
//    var branchID =...
//    var employeeID =...

//    //Forming the variable to return    
//    URL+="company=";
//    URL += companyID;
//    URL += "/branch=";
//    URL += branchID;
//    URL += "/employee=";
//    URL += employeeID;
//    URL += "/info";

//    return URL;
//}