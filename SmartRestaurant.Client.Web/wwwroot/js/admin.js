//import { stringify } from "querystring";

var progress = "<div class=\"loader\"></div>";

function InitValidationUnobtrusive(id) {
    var $form = $(id);    
    if ($form.length) {
        $form.removeData("validator") /* added by the raw jquery.validate plugin */
            .removeData("unobtrusiveValidation");
        /* added by the jquery unobtrusive plugin */
        $.validator.unobtrusive.parse($form);
        // $.validator.unobtrusive.
    }
}

function composeUrl(item) {
    //return `${item.data("area")}/${item.data("controller")}/${item.data("action")}`;
    return `${item.data("action-url")}`;
}

var displayPreview = function readURL(input, target) {
    var img = $(`#${target}`);
    //console.log(img);
    var uniqueId = img.data("id");
    var url = input.value;
    var ext = url.substring(url.lastIndexOf('.') + 1).toLowerCase();
    if (input.files && input.files[0] && (ext === "gif" || ext === "png" || ext === "jpeg" || ext === "jpg")) {
        var reader = new FileReader();

        reader.onload = function (e) {
            img.removeClass("hidden");
            img.attr('src', e.target.result);
            img.removeClass("hidden");
            $(`#btn-file-post-${uniqueId}`).addClass("hidden");
            $(`#btns-commands-${uniqueId}`).removeClass("hidden");
        };
        reader.readAsDataURL(input.files[0]);
    } else {
        //$('.imagepreview').attr('src', '/assets/no_preview.png');
    }
};

function attachClickEventDeleteEntityInModal() {
    $("#do-action-delete-entity-modal").off("click").on("click", function (e) {
        e.preventDefault();

        $("#do-action-delete-entity-modal").prop('disabled', true);
        $("#delete-entity-modal").find("#progress-job").removeClass("hidden");

        var url = $("#Url").val();
        var id = $("#Id").val();
        //la référence de la ligne à supprimer
        var prefix = $("#Prefix").val();

        $.ajax({
            cache: false,
            type: 'POST',
            url: url,
            data: { "id": id },
            success: function (result) {
                if (result.hasError !== true) {//pas d'erreur l'enregistrement est bien supprimé
                    $(`#${prefix}-${id}`).remove();
                    $("#delete-entity-modal-body").html("");
                    $('#delete-entity-modal').modal('hide');
                    notify(result.title, result.message, notifyType.success);
                } else {
                    $("#delete-entity-modal-body").html(result.error.message);
                    $("#delete-entity-modal").find("#progress-job").addClass("hidden");
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {

            }
        });
    });
}

function InitListJsCommands() {
    $(".action-delete").off("click").on("click", function (e) {
        e.preventDefault();

        var id = $(this).data("id");
        var url = composeUrl($(this));

        var modal = "#delete-entity-modal";

        $(modal).modal({ backdrop: 'static', keyboard: false, show: true });
        //désactivation du button en attente de chargement du message
        $("#do-action-delete-entity-modal").prop('disabled', true);
        $("#delete-entity-modal").find("#progress-job").removeClass("hidden");


        $.ajax({
            cache: false,
            type: 'GET',
            url: url,
            data: { "id": id },
            success: function (result) {//DeleteEntityViewModel
                console.log(result.hasError);
                console.log(result);
                $("#delete-entity-modal").find("#progress-job").addClass("hidden");
                $("#delete-entity-modal-title").html(result.title);

                if (result.hasError === false) {
                    $("#Id").val(result.args[0]);
                    $("#Url").val(result.args[1]);
                    $("#Prefix").val(result.args[2]);

                    $("#delete-entity-modal-body").html(result.message);
                    //Réactivation du button
                    $("#do-action-delete-entity-modal").prop('disabled', false);
                    attachClickEventDeleteEntityInModal();

                } else {//Error
                    $("#delete-entity-modal-body").html(result.error.message);
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {

            }
        });
    });

    $(".load-childs").off("click").on("click", function (e) {
        e.preventDefault();
        var target = $($(this).data("target"));
        var css = $(this).find("i").attr("class");
        if (css === "fa fa-plus") {
            target.removeClass("hidden");
            $(this).find("i").removeClass('fa fa-plus').addClass('fa fa-minus');
            var id = $(this).data("id");
            var url = composeUrl($(this));
            $.ajax({
                cache: false,
                type: 'GET',
                url: url,
                data: { "parentId": id },
                success: function (result) {
                    progress = target.children('td:last').html();
                    target.children('td:last').html(result);
                    InitListJsCommands();
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    //
                }
            });
        } else {
            target.children('td:last').html(progress);
            target.addClass("hidden");
            $(this).find("i").removeClass('fa fa-minus').addClass('fa fa-plus');
        }
    });
}

function InitCascadingSelectList() {

    $(".dynamic-load-childs").off("change").on("change", function (e) {
        e.preventDefault();

        var value = $(this).val();
        //le contrôle Cible 
        var target = $($(this).data("target"));
        //affectation de la valeur
        target.val(value);
        //Cible pour les enfants
        var childs = $($(this).data("childs-container"));
        childs.html("");

        if (value !== "") {
            childs.html(progress);
            var url = $(this).data("action-url");
            console.log(url);
            $.ajax({
                cache: false,
                type: 'GET',
                url: url,
                data: { "id": value },
                success: function (result) {
                    childs.html(result);
                    InitCascadingSelectList();
                },
                error: function (xhr, ajaxOptions, thrownError) {

                }
            });
        }
    });
}

$("#add-partial-food-composition").on("click", function (e) {
    e.preventDefault();
    console.log("adding food composition");
    var url = composeUrl($(this));
    var index = $("#Index").val();
    console.log(index);
    var target = $("#food-compositions");
    $.ajax({
        cache: false,
        type: "GET",
        url: url,
        data: { "index": index },
        success: function (result) {
            target.append(result);
            index++;
            $("#Index").val(index);
            InitValidationUnobtrusive("#food-form");
            InitAddPartialFoodCompositionCommands();
            console.log($("#Index").val());
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr);
        }
    }
    );
});

function InitAddPartialFoodCompositionCommands() {
    $(".delete-partial-food-composition").off("click").on("click", function (e) {
        e.preventDefault();
        var url = composeUrl($(this));
        $("#IndexToDelete").val($(this).data("index"));
        var $form = $("#food-form");
        var target = $("#food-compositions");

        jQuery.post(url, $form.serialize())
            .done(function (result) {
                target.html(result);
                InitValidationUnobtrusive("#food-form");
                InitAddPartialFoodCompositionCommands();
            })
            .fail(function (xhr, textStatus, errorThrown) {
                //console.log(xhr.responseText);            
            });
    });

    $(".get-foods").off("change").on("change", function (e) {
        e.preventDefault();
        //console.log("load foods");
        var index = $(this).data("index");

        var target = $(`#Compositions_${index}__Composition_FoodId`);
        var emptyOptionText = target.find("option:first-child").text();

        target.empty().append('<option value="">' + emptyOptionText + '</option>');

        var url = composeUrl($(this));
        var categoryId = $(this).val();

        if (categoryId === "") {
            return;
        }
        $.ajax({
            cache: false,
            type: "GET",
            url: url,
            data: { "categoryId": categoryId },
            success: function (result) {
                //console.log(result);
                $.each(result, function (i, item) {
                    target.append('<option value="' + item.value + '">' + item.text + '</option>');
                });
            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr);
            }
        }
        );
    });
}

//args like param1:value1, param2:value2, ....
function ToJson(args) {
    var properties = args.split(', ');
    var obj = {};
    properties.forEach(function (property) {
        var tup = property.split(':');
        obj[tup[0]] = tup[1];
    });
    return obj;
}

var notifyType = {
    success: "success",
    info: "info",
    warning: "warning",
    error: "error"
};

//var notifyPosition = {
//    topleft: "toast-top-left",
//    topcenter: "toast-top-center",
//    topright: "toast-top-right",
//    topfull: "toast-top-full",
//    bottomleft: "toast-bottom-left",
//    bottomcenter: "toast-bottom-center",
//    bottomright: "toast-bottom-right",
//    bottomfull: "toast-bottom-full"
//};

function notify(title, message, notifyType) {//type:{success,info,warning,danger}    
    switch (notifyType) {
        case "success":
            toastr.success(title, message,
                {
                    "closeButton": true
                });
            break;
        case "info":
            toastr.info(title, message,
                {
                    "closeButton": true
                });
            break;
        case "warning":
            toastr.warning(title, message,
                {
                    "closeButton": true
                });
            break;
        case "error":
            toastr.error(title, message,
                {
                    "closeButton": true
                });
            break;
    }
}

function Validate(target) {
    //console.log(target);
    var anyError = false;
    target.find("input,select,textarea").each(function () {
        try {
            if (!$(this).valid()) {
                anyError = true;
            }
        }
        catch (ex) {
            //
        }
    });
    return anyError;
}


function AjaxCall(url, data, type) {
    return $.ajax({
        url: url,
        type: type ? type : 'GET',
        data: data,
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    });
}
function RefrechChild(parentId, childId, url) {
    $(parentId).on("change", function () {

        var parentVal = $(parentId).val();//parent id
        var obj = { parentVal: parentVal };
        if (parentVal === null) return;
        AjaxCall(url, obj, 'GET')
            .done(function (response) {
                if (response.list !== null) {
                    $(childId).empty();
                    var options = '';
                    if (response.title !== null)
                        options += '<option value="">--' + response.title + '--</option>';
                    for (var i = 0; i < response.list.length; i++) {
                        options += '<option value="' + response.list[i].value + '">' + response.list[i].text + '</option>';
                    }
                    $(childId).append(options);

                }
            }).fail(function (error) {
                alert(error.StatusText);
            });
    });
}

$(function () {
    RefrechChild('#restaurantsList', '#floorsList', '/admin/restaurants/areas/getFloorsByRestId');
});
$(function () {
    RefrechChild('#floorsList', '#areasList', '/admin/tables/getAreasByFloorId');
});
$(function () {
    RefrechChild('#areasList', '#tablesList', '/admin/places/getTablesByAreaId');
});
$(function () {
    RefrechChild('#countriesList', '#statesList', '/admin/cities/getStatesByCountryId');
});
$(function () {
    RefrechChild('#statesList', '#citiesList', '/admin/cities/getCitiesByStateId');
});
$(function () {
    RefrechChild('#restaurantsList', '#productFamiliesList', '/admin/products/getProductFamiliesByRestId');
});
$(function () {
    RefrechChild('#productFamiliesList', '#productsList', '/admin/products/getProductsByFamiliesId');
});
InitListJsCommands();
InitCascadingSelectList();

// Write your JavaScript code.

$(function () {


    $('#countryDropDownList').on("change", function () {
        var countryid = $('#countryDropDownList').val();
        var obj = { "countryid": countryid };
        ///console.log(JSON.stringify(obj));
        AjaxCall('/admin/cities/getstates', obj, 'GET').done(function (response) {
            if (response.length > 0) {
                $('#stateDropDownList').html('');

                var options = '';
                options += '<option value="Select">Select</option>';
                for (var i = 0; i < response.length; i++) {
                    options += '<option value="' + response[i].value + '">' + response[i].text + '</option>';
                    console.log(response);
                }
                $('#stateDropDownList').append(options);

            }
        }).fail(function (error) {
            alert(error.StatusText);
        });
    });

});
function SelectListTransfer(sourceId, distinationId) {
    var selectedTexts = [];
    var existingVals = [];
    var selectedVals = $(sourceId).val();
    var distSelect = $(distinationId);
    // get selected text
    $(sourceId + " option:selected").each(function () {
        var $this = $(this);
        if ($this.length) {
            selectedTexts.push($this.text());
        }
    });
    // get existing vals
    $(distinationId + " option").each(function () {
        var $this = $(this);
        if ($this.length) {
            existingVals.push($this.val());
        }
    });

    if (selectedVals === null || selectedVals.length === 0) return;

    var valsExist = existingVals !== null && existingVals.length > 0;

    for (var i = 0; i < selectedVals.length; i++) {

        var value = selectedVals[i];
        var upper = value.toUpperCase();
        if (valsExist && existingVals.includes(upper))
            continue;
        var text = selectedTexts[i];

        distSelect.append($("<option></option>")
            .attr("value", value)
            .text(text));
    }
}
function SelectListTransferAll(sourceId, distinationId) {

    SelectAllItems(sourceId);
    SelectListTransfer(sourceId, distinationId);
}
function AddFoodClick() {
    var selectedTexts = [];
    var existingVals = [];
    var selectedVals = $("#foodsList").val();
    var distSelect = $("#selectedFoodsList");
    // get selected text
    $("#foodsList option:selected").each(function () {
        var $this = $(this);
        if ($this.length) {
            selectedTexts.push($this.text());
        }
    });
    // get existing vals
    $("#selectedFoodsList option").each(function () {
        var $this = $(this);
        if ($this.length) {
            existingVals.push($this.val());
        }
    });

    if (selectedVals === null || selectedVals.length=== 0) return;

    var valsExist = existingVals != null && existingVals.length > 0;
    var items = $("#SelectedItems").val();
    for (var i = 0; i < selectedVals.length; i++) {

        var value = selectedVals[i];
        var upper = value.toUpperCase();
        if (valsExist && existingVals.includes(upper))
            continue;
        var text = selectedTexts[i];

        $("#SelectedItems").val(items + ";" + upper);

        distSelect.append($("<option></option>")
            .attr("value", value)
            .text(text));
    }
}
function RemoveFoodClick() {
    $("#selectedFoodsList option:selected").remove();
}
function RemoveSelectListItem(id) {
    $(id + " option:selected").remove();
}
function RemoveAllSelectListItem(id) {
    $(id + " option").remove();
}
$('#foodForm').submit(function () {
    SelectAllItems("#selectedFoodsList");
});
$('#selectAllForm').submit(function () {
    SelectAllItems("#distList");
});
function SelectAllItems(listId) {
    $(listId + " option").prop('selected', true);
}

function RefrechPurchaceTTC() {
    purchasePriceHT = $('#purchasePriceHT').val();
    tva = $('#tva').val();
    var result = (purchasePriceHT * (1 + tva / 100)).toFixed(2);
    $('#purchasePriceTTC').val(result);
}
function RefrechAll() {
    purchasePriceHT = $('#purchasePriceHT').val();
    tva = $('#tva').val();
    gain = $('#gain').val();
    percentage = $('#percentage').val();

    var result = (htval * (1 + tvaval / 100)).toFixed(2);
    $('#ttcPrice').val(result);
}
function RefrechSaleHT() {
    purchasePriceHT = $('#purchasePriceHT').val();
    gain = $('#gain').val();

    percentage = $('#percentage').is(":checked");

    var result = percentage ? (purchasePriceHT * (1 + gain / 100)).toFixed(2) :
        (parseFloat(purchasePriceHT) + parseFloat(gain)).toFixed(2);
    $('#salePriceHT').val(result);
    RefrechSaleTTC();
}
function RefrechSaleTTC() {
    salePriceHT = $('#salePriceHT').val();
    tva = $('#tva').val();
    var result = (salePriceHT * (1 + tva / 100)).toFixed(2);
    $('#salePriceTTC').val(result);
}

function getFormData($form) {
    var unindexed_array = $form.serializeArray();
    var indexed_array = {};

    $.map(unindexed_array, function (n, i) {
        indexed_array[n['name']] = n['value'];
    });

    return indexed_array;
}
$(".form-translate").on("submit", function (e) {
    e.preventDefault();
    //var $form = $(this);
    //$form.post("/translate/Translates/save")
    //    .done(function (result) {
    //        console.log("done please wait");
    //    })
    //    .fail(function (result) {
    //        console.log("fail please wait");
    //    });
});

$(".btn-translate").on("click", function (e) {
    e.preventDefault();
  
    $(this).attr("disabled", true);
    var index = $(this).data("index");
    var $form = $(`#translate-${index}`);
    var request = $form.serialize();
    
    var $logger = $(`#result-${index}`);
    console.log(request);

    $logger.html("<div id =\"circle\"><div class=\"loader2\"><div class=\"loader2\"><div class=\"loader2\"> </div></div></div></div>");
    
    $.post("/translate/Translates/save", request)
        .done(function (result) {
            $logger.html("Saved");
        })
        .fail(function (result) {
            $logger.html(result.message);
        });
    $(this).attr("disabled", false);

   
    setTimeout(function () { $logger.html("");}, 3005);

   
    //return;
});
