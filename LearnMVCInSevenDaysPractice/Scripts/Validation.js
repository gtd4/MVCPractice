var isFirstNameEmpty = function () {
    if (document.getElementById('TxtFName').value == "") {
        return 'First Name Should Not Be Empty';
    }

    return "";
}

var isFirstNameInValid = function () {
    if (document.getElementById('TxtFName').value.indexOf("@") != -1) {
        return 'First Name Should Not Contain @';
    }

    return "";
}

var isLastNameInValid = function () {
    var lName = document.getElementById('TxtLName').value;
    if (lName.length < 3 || lName.length >= 10) {
        return 'Last Name should be between 3 and 10 letters long';
    }

    return "";
}

var isSalaryEmpty = function () {
    if (document.getElementById('TxtSalary').value == "") {
        return 'Salary should not be empty';
    }

    return "";
}

var isSalaryInValid = function () {
    if (isNaN(document.getElementById('TxtSalary').value)) {
        return 'Enter valid salary';
    }
    else { return ""; }
}

var isValid = function () {
    var FirstNameEmptyMessage = isFirstNameEmpty();
    var FirstNameInValidMessage = isFirstNameInValid();
    var LastNameInValidMessage = isLastNameInValid();
    var SalaryEmptyMessage = isSalaryEmpty();
    var SalaryInvalidMessage = isSalaryInValid();

    var FinalErrorMessage = "Errors:";
    if (FirstNameEmptyMessage != "") {
        FinalErrorMessage += "\n" + FirstNameEmptyMessage;
    }
    if (FirstNameInValidMessage != "") {
        FinalErrorMessage += "\n" + FirstNameInValidMessage;
    }
    if (LastNameInValidMessage != "") {
        FinalErrorMessage += "\n" + LastNameInValidMessage;
    }
    if (SalaryEmptyMessage != "") {
        FinalErrorMessage += "\n" + SalaryEmptyMessage;
    }
    if (SalaryInvalidMessage != "") {
        FinalErrorMessage += "\n" + SalaryInvalidMessage;
    }

    if (FinalErrorMessage != "Errors:") {
        alert(FinalErrorMessage);
        return false;
    }
    else {
        return true;
    }
}

