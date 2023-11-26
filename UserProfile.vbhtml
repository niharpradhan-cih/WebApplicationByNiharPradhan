@Code
    Dim firstName As String = Request.QueryString("ufname")
    Dim lastName As String = Request.QueryString("ulname")
    Dim dob As Date = Date.Parse(Request.QueryString("userdob"))

    Dim newPerson As PersonManagement.Person
    Dim runUptoBirthDay As PersonManagement.PersonDaysRunUptoBirthDay

    newPerson = New PersonManagement.Person(firstName, lastName, dob)

End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <link href="~/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="container-fluid py-4">
    <div Class="card-header">
        <h6><span style="font-size:1.5em;" class="fa fa-user"></span>@newPerson.PersonWelcomeMessage</h6>
    </div>
    <div Class="card-header">
        <h6><span style="font-size:1.5em;" class="fa fa-user"></span>@newPerson.VowelsInName</h6>
    </div>
    <div Class="card-header">
        <h6><span style="font-size:1.5em;" class="fa fa-user"></span>@newPerson.PersonAge</h6>
    </div>
    <div Class="card-header">
        <h6><span style="font-size:1.5em;" class="fa fa-user"></span>@newPerson.PersonDaysBeforeNextBDay</h6>
    </div>
    <div Class="card-header">
        <h6><span style="font-size:1.5em;" class="fa fa-user"></span>@newPerson.RunUptoCaption</h6>
    </div>
    <div>
        <table class="table table-bordered my-4">
            <thead class="thead-dark">
                <tr class="d-print-table-row">
                    <th>Date</th>
                    <th>Day of Week</th>
                </tr>
            </thead>
            <tbody>
                @For Each runUptoBirthDay In newPerson.PersonRunUptoDOBs
                    @<tr class="d-xl-table-row">
                        <td><a href=@runUptoBirthDay.RunDateLink target="_blank">@runUptoBirthDay.RunDate</a></td>
                        <td>@runUptoBirthDay.RunDateDayOfWeek</td>
                    </tr>
                Next
            </tbody>
        </table>
    </div>
    <div class="form-group">
        <a href="~/UserInput.vbhtml">
            <button type="button"
                    id="btn_ViewHome"
                    class="btn btn-outline-primary">
                <span></span> Home Page
            </button>
        </a>
    </div>

</body>
</html>
