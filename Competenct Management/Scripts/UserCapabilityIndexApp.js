$(document).ready(function () {

    getSubSystemsAndPopulateDropDown($("#SystemsListItems").find(":selected").val());

    $("#SystemsListItems").change(function (data) {
        // find the selected, and alert it.
        getSubSystemsAndPopulateDropDown($("#SystemsListItems").find(":selected").val());
        
    });

    $("#SubSystemsDd").change(function (data) {
        // find the selected, and alert it.
        getComponentsAndPopulateDropDown($("#SubSystemsDd").find(":selected").val());
    });

    $("#ComponentsDd").change(function (data) {
        // find the selected, and alert it.
        //alert($("#ComponentsDd").find(":selected").val());
        getDescriptionAndPopulateDropDown($("#ComponentsDd").find(":selected").val());
        //getDescriptionAndPopulateDropDown("DAVE");
    });


    function getDescriptionAndPopulateDropDown(CompKey) {
        //alert(CompKey);
        $.ajax({
            url: '/UserCapability/GetDescriptionList/',
            type: 'POST',
            data: { compName: CompKey },
            dataType: 'json',
            success: function (data) {
                var s = $("#DescriptionDd");
                s.empty();
                $.each(data, function () {
                    s.append('<option>' + this.description + '</option>')
                });          
            }// ajax callback

        });
    }
    

    // getComponentList and populate dd
    function getComponentsAndPopulateDropDown(sysSubSysKey) {
        $.ajax({
            url: '/UserCapability/GetComponentList/',
            type: 'POST',
            data: { subsystName: sysSubSysKey },
            dataType: 'json',
            success: function (data) {
                var s = $("#ComponentsDd");
                s.empty();
                $.each(data, function () {
                    s.append('<option value= \"' + this.componentId + '-' + this.component + '\">' + this.component + '</option>')
                });
                getDescriptionAndPopulateDropDown($("#ComponentsDd").find(":selected").val());

            }// ajax callback

        });
    }

    // getSubsystemList, then populate dd.  then populate componentlist dd.
    function getSubSystemsAndPopulateDropDown(systemKey) {

        //get subsystemlist
        $.ajax({
            url: '/UserCapability/GetSubSystemsList/',
            type: 'POST',
            data: { systemName: systemKey },
            dataType: 'json',
            success: function (data) {
                var s = $("#SubSystemsDd");
                s.empty();
                $.each(data, function () { //populate dropdown with subsystemlist
                    s.append('<option value= \"' + this.System + '-' + this.SubSystem + '\">' + this.SubSystem + '</option>')
                });
                getComponentsAndPopulateDropDown($("#SubSystemsDd").find(":selected").val());
            }
        });

    }

})