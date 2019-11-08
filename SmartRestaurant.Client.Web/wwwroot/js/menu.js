function InitRestaurantEvent() {
    $("#MenuModel_RestaurantId").off("change").on("change", function (e) {
        e.preventDefault();
        var restaurantId = $(this).val();
        target = $("#MenuModel_ChefId");
        var emptyOptionText = target.find("option:first-child").text();
        target.empty().append('<option value="">' + emptyOptionText + '</option>');

        $.ajax({
            cache: false,
            type: "GET",
            data: { "restaurantId": restaurantId },
            url: "/admin/menus/GetChefsByRestaurantId",
            success: function (result) {
                $.each(result, function (i, item) {
                    target.append('<option value="' + item.value + '">' + item.text + '</option>');
                });                
            },
            error: function (xhr, ajaxOptions, thrownError) {

            }
        });
    });

    $("#add-ingredient").off("click").on("click", function (e) {
        e.preventDefault();
        var url = composeUrl($(this));
        var index = $("#IngredientIndex").val();
        $.ajax({
            cache: false,
            type: "GET",
            url: url,
            data: { "index": index },
            success: function (result) {
                index++;
                $("#dishes-ingredients").append(result);
                $("#IngredientIndex").val(index);
                InitIngredientEvents();
                InitValidationUnobtrusive("#dish-form");
            },
            error: function (xhr, ajaxoptions, throanError) {

            }
        });
    });

    $("#add-accompaniment").off("click").on("click", function (e) {
        e.preventDefault();
        var url = composeUrl($(this));
        var dishId = $("#Id").val();
        var index = $("#AccompanyingIndex").val();
        var restaurantId = $("#DishModel_RestaurantId").val();
        var type = $("#DishModel_Type").val();
        $.ajax({
            cache: false,
            type: "GET",
            url: url,
            data: { "index": index, "restaurantId": restaurantId, "dishId": dishId, "type": type},
            success: function (result) {
                index++;
                $("#dishes-accompaniments").append(result);
                $("#AccompanyingIndex").val(index); 
                InitAccompanimentEvents();
                InitValidationUnobtrusive("#dish-form");
            },
            error: function (xhr, ajaxoptions, throanError) {

            }
        });
    });

    $("#add-gallery-picture").off("click").on("click", function (e) {
        e.preventDefault();
        var url = composeUrl($(this));
        var index = $("#GalleryPictureIndex").val();
        $.ajax({
            cache: false,
            type: "GET",
            url: url,
            data: { "index": index },
            success: function (result) {
                index++;
                $("#gallery-pictures").append(result);
                $("#GalleryPictureIndex").val(index);
                InitGalleryPictureEvents();
                InitUploadPicture();
                InitValidationUnobtrusive("#dish-form");
            },
            error: function (xhr, ajaxoptions, throanError) {

            }
        });
    });
}


function InitIngredientEvents() {
    $(".load-category-foods").off("change").on("change", function (e) {
        e.preventDefault();
        console.log("load foods");
        var index = $(this).data("index");
        //Ingredients_0__Ingredient
        var target = $(`#Ingredients_${index}__Ingredient_FoodId`);
        if (target.length) console.log(target.attr("id"));
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

    $(".load-food-details").off("change").on("change", function (e) {
        e.preventDefault();
        console.log("load food details");
        var index = $(this).data("index");
        var url = composeUrl($(this));
        var foodId = $(this).val();
        
        var targetName = $(`#Ingredients_${index}__Ingredient_Name`);
        var targetQtUnits = $(`#Ingredients_${index}__Ingredient_Quantity_UnitId`);
        var targetOtValue = $(`#Ingredients_${index}__Ingredient_Quantity_Value`);
        if (targetName.length) {
            console.log("ok");
        }
        targetOtValue.val("");

        if (foodId === "") {

            targetName.val("");
            targetQtUnits.val("");
            return;
        }        
        
        $.ajax({
            cache: false,
            type: "GET",
            url: url,
            data: { "foodId": foodId },
            success: function (result) {
                console.log(result);
                targetName.val(result.name);
                targetQtUnits.val(result.unitId);

            },
            error: function (xhr, ajaxoptions, thrownError) {

            }
        });
    });

    $(".delete-ingredient").off("click").on("click", function (e) {
        e.preventDefault();
        console.log("delete ingredient");
        var url = composeUrl($(this));
        var index = $(this).data("index");
        //$("#IngredientToDeleteIndex").val(index);
        var $form = $("#dish-form");
        jQuery.post(url, $form.serialize())
            .done(function (result) {
                $("#dishes-ingredients").html(result);
                InitValidationUnobtrusive("#dish-form");
                InitIngredientEvents();
                var newIndex = $("#IngredientIndex").val();
                newIndex--;
                $("#IngredientIndex").val(newIndex); 
            })
            .fail(function (xhr, textStatus, errorThrown) {
                //console.log(xhr.responseText);            
            });
    });
}

function InitAccompanimentEvents() {

    $(".delete-accompaniment").off("click").on("click", function (e) {
        e.preventDefault();  
        console.log("delete accompaniment");
        var url = composeUrl($(this));
        var index = $(this).data("index");
        
        var $form = $("#dish-form");
        jQuery.post(url, $form.serialize())
            .done(function (result) {
                $("#dishes-accompaniments").html(result);
                InitValidationUnobtrusive("#dish-form");
                InitAccompanimentEvents();
                var newIndex = $("#AccompanyingIndex").val();
                newIndex--;
                $("#AccompanyingIndex").val(newIndex); 
            })
            .fail(function (xhr, textStatus, errorThrown) {
                //console.log(xhr.responseText);            
            });
    });
}

function InitGalleryPictureEvents() {

    $(".delete-picture").off("click").on("click", function (e) {
        e.preventDefault();
        console.log("delete ingredient");
        var url = composeUrl($(this));
        var index = $(this).data("index");
        $("#GalleryPictureToDeleteIndex").val(index);
        var $form = $("#dish-form");
        jQuery.post(url, $form.serialize())
            .done(function (result) {
                $("#gallery-pictures").html(result);
                InitValidationUnobtrusive("#dish-form");
                InitGalleryPictureEvents();
            })
            .fail(function (xhr, textStatus, errorThrown) {
                //console.log(xhr.responseText);            
            });
    });
}




InitRestaurantEvent();
InitIngredientEvents();