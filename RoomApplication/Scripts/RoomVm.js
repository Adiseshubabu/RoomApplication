require([
    'jquery',
    'bootstrap',
    'kendo.all.min',
],
    function () {
        debugger
        RoomVm = kendo.observable({
            schedulerStatusTypeDataSource: new kendo.data.DataSource({
                data: [
                    { Name: "Bulli babu", Id: 1 },
                    { Name: "Mahesh babu", Id: 2 },
                    { Name: "Subhani", Id: 3 },
                    { Name: "Seshu", Id: 4 },
                    { Name: "Yesu", Id: 5 },
                    { Name: "Pavan", Id: 6 },
                    { Name: "Somu", Id: 7 },
                ]
            }),


            initialize: function () {
                debugger
                RoomVm.setUpNotifier();                

            },

            onCloseMultiSelectClick: function (e) {
                var kItemId = $($(e).closest('ul'))[0].id,
                    id = kItemId.substr(0, kItemId.length - 8);

                $('#' + id).data('kendoMultiSelect').close();
                RoomVm.isPreventSelection = true;
            },

            setUpNotifier: function () {
                debugger
                var $globalNotifierDiv = $('<div id="globalNotifier"/>').appendTo('body');

                $globalNotifierDiv.kendoNotification({

                    position: {
                        top: 30,
                        left: Math.floor($(window).width() / 4 - 10)
                    },

                    templates: [
                        {
                            type: "warning",
                            template: "<div class='error-indicator'><b>Warning</b>: <p><span>#= message #</span></p></div>"
                        },
                        {
                            type: "success",
                            template: "<div class='success-indicator'>#= message #</div>"
                        },
                        {
                            type: "info",
                            template: "<div class='info-indicator'>Info: #= message #</div>"
                        }],
                });

                RoomVm.notifier = $globalNotifierDiv.data("kendoNotification");

            },

            notifySuccess: function (msg) {
                debugger
                RoomVm.notifier.show({
                    message: msg
                }, "success");
            },

            notifyWarning: function (msg) {
                debugger
                RoomVm.notifier.warning({
                    message: msg
                });
            },

            notifyInfo: function (msg) {
                debugger
                RoomVm.notifier.info({
                    message: msg
                }, "info");
            },

            setUpMultiSelect: function (elementId, multiSelectId, dataSource, varName, multiSelectType, isAllItemsSelected) {
                debugger
                var multiselect = elementId.kendoMultiSelect({
                    itemTemplate: "<div><input type='checkbox' id=" + multiSelectId + " value='#=data.Name#' class='chkFields float-left'/> <label class='float-left'>#:data.Name# </label> # if (data.Id == 0) { # <input type='button' class='save btn-xs' style='float:right;line-height: normal;' onclick='RoomVm.onCloseMultiSelectClick(this)' value='Close'> # } # </div>",
                    dataSource: dataSource,
                    dataTextField: "Name",
                    dataValueField: "Id",
                    autoClose: false,
                });
            },

           
           


        });
        RoomVm.initialize();
    });