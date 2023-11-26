@Code
End Code
<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <link href="~/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="container-fluid py-4">
    <div Class="card-header">
        <h6><span style="font-size:1.5em;" class="fa fa-user"></span>Input your profile data</h6>
    </div>

    <form name="uinput" method="get" action="~/UserProfile.vbhtml">
        <div class="card-deck">
            <div class="col-md-6">
                <div class="form-group">
                    <div>
                        <Label for="ufname">First Name</Label>
                        <input type="text" id="ufname" placeholder="Your First Name" name="ufname" class="form-control" value="">
                        
                    </div>
                </div>
                <div class="form-group">
                    <label for="ulname">Last Name</label>
                    <input type="text" id="ulname" placeholder="Your Last Name" name="ulname" class="form-control" value="">
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label for="DOB">Date of Birth <span>(MM/DD/YYYY)</span></label>
                    <input type="date" id="userdob" placeholder="Enter Date of Brith" name="userdob" class="form-control" value="">
                </div>
                <div class="form-group">
                    <button type="submit"
                            id="btn_ViewProfile"
                            class="btn btn-outline-primary"
                            onclick="return ValidateInput()">
                        <span></span> View Profile
                    </button>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
<script>
    function ValidateInput() {
        var fname = document.getElementById('ufname').value;
        var lname = document.getElementById('ulname').value;
        var udob = document.getElementById('userdob').value;

        if (fname.trim() === '') {
            alert('First Name cannot be empty.');
            return false;
        }
        if (lname.trim() === '') {
            alert('Last Name cannot be empty.');
            return false;
        }
        if (udob.trim() === '') {
            alert('Date of birth cannot be empty.');
            return false;
        }

        return true;
    }
</script>