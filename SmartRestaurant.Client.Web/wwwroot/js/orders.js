"use strict";
/// connection to Main Hub
var connection = new signalR.HubConnectionBuilder()
    .withUrl("/restaurants/ordershub").build();

connection.start().then(function () {
    console.log("connected");
    /// invoke for hub server  
    connection.invoke("JoinGroup", "R01");
    if (document.getElementById("clientsOrder") !== null)
        RefreshClientsOrders();
    else if (document.getElementById("signedOrders") !== null)
        RefreshSignedOrders();
    else if (document.getElementById("readyOrders") !== null)
        RefreshReadyOrders();
    else if (document.getElementById("deliveredOrders") !== null)
        RefreshDeliveredOrders();
});


//// add items to orders pannel 
///// in Client Side
function Additem(value) {

    var ul = document.getElementById("ordermenu");
    var li = document.createElement("li");
    li.className = "list-group-item";
    //alert(value);
    li.appendChild(document.createTextNode(value));
    ul.appendChild(li);
}


//// read through ul element (Dishes and Product Items) 
///   & getting data within it
///// Composite an Order
function validateOrder() {
  
    var arr = document.getElementById("ordermenu").getElementsByTagName("li");
    var clientOrder = [];
    for (var i = 0; i < arr.length; i++) {
     
        clientOrder[i] = arr[i].innerText;
    }

    var seat = document.getElementById("seat").value;
    var floor = document.getElementById("floor").value;
    var area = document.getElementById("area").value;
    /// invoke for hub server  
    connection.invoke("PushOrder", orderItem);

}

//// Add Client's orders to the Staff Monitor 
//order=OrderModel

// click functions
function AsignClick(btn,orderItem, cooker,ul) {

    btn.addEventListener("click", function () {   
        console.log("Asign clicked");
        AssignOrderToCooker(orderItem, cooker); 
        ul.removeChild(btn);
    }, false);
}
function ReadyClick(btn, orderItem, ul) {

    btn.addEventListener("click", function () {
        console.log("Ready clicked");
        NextOrderItem(orderItem);
        ul.removeChild(btn);
    }, false);
}
function DeliveredClick(btn, orderItem, ul) {

    btn.addEventListener("click", function () {
        console.log("Ready clicked");
        NextOrderItem(orderItem);
        ul.removeChild(btn);
    }, false);
}

// invocing 
function AssignOrderToCooker(orderItem,cooker) {
    connection.invoke("AssignOrderItem", orderItem, cooker);
};
function NextOrderItem(orderItem) {
    connection.invoke("ReadyToServe", orderItem);
};
function DeliveredOrderItem(orderItem) {
    connection.invoke("DelivredOrder", orderItem);
};
function RefreshClientsOrders() {
    connection.invoke("RefreshClientsOrders");
};
function RefreshSignedOrders() {
    connection.invoke("RefreshSignedOrders");
};
function RefreshReadyOrders() {
    connection.invoke("RefreshReadyOrders");
};
function RefreshDeliveredOrders() {
    connection.invoke("RefreshDeliveredOrders");
};
// on
connection.on("newOrder", function (order) {

    var ul = document.getElementById("clientsOrder");
    
    //$("#orderName").prop('value', order.orderNumber);

    if (ul === null) return;
    ul.innerHTML = "";
    for (var i = 0; i < order.orderItems.length; i++) {
       

        var orderItem = order.orderItems[i];
        var btn = document.createElement("button");
        btn.id = orderItem.id;
        btn.innerHTML = orderItem.name;
   
        var cooker =  
        {
            "id" :  ""+i,
            "userName" :"UserName"+i,
            "firstName":"FirstName"+i,
            "lastName" :"LastName"+i
        };

        AsignClick(btn, orderItem, cooker,ul);
        ul.appendChild(btn);
    }
});
connection.on("newCookerTask", function (orderItem) {
    var ul = document.getElementById("signedOrders");

    if (ul === null) return;
    
    var btn = document.createElement("button");

    btn.innerHTML = orderItem.name;
    ReadyClick(btn, orderItem, ul);
    ul.appendChild(btn);

});  
connection.on("orderItemReady", function (orderItem) {
    var ul = document.getElementById("readyOrders");
    
    if (ul === null) return;
    ul.innerHTML = "";

    var btn = document.createElement("button");

    btn.innerHTML = orderItem.name;
    DeliveredClick(btn, orderItem, ul);
    ul.appendChild(btn);

});    
connection.on("orderItemDelivred", function (orderItem) {
    var ul = document.getElementById("deliveredOrders");
    
    if (ul === null) return;
    ul.innerHTML = "";

    var btn = document.createElement("button");

    btn.innerHTML = orderItem.name;
    
    ul.appendChild(btn);

});   
//remove the canceled item from cheff page
connection.on("orderItemCanceled", function (canceledorderItem) {
    var ul = document.getElementById("clientsOrder");
 
    if (ul === null) return;
  
    var btn = document.getElementById(canceledorderItem.itemModel.id);
    ul.removeChild(btn);

});
connection.on("orderCanceled", function (canceledorder) {

});
connection.on("paidOrderItem", function (paidOrderItem) {

});
connection.on("paidOrder", function (paidOrder) {

});

//refreshing 
connection.on("ClientsOrdersRefreshed", function (orders) {
    var ul = document.getElementById("clientsOrder");
 
    if (ul === null) return;
    ul.innerHTML = "";
    for (var j = 0; j < orders.length; j++) {
        var order = orders[j];
        for (var i = 0; i < order.orderItems.length; i++) {
            var orderItem = order.orderItems[i];
            var btn = document.createElement("button");
            btn.id = orderItem.id;
            btn.innerHTML = orderItem.name;
        }
    }
});
connection.on("SignedOrdersRefreshed", function (orders) {
    var ul = document.getElementById("signedOrders");

    if (ul === null) return;
    ul.innerHTML = "";
    for (var j = 0; j < orders.length; j++) {
        var order = orders[j];
        for (var i = 0; i < order.orderItems.length; i++) {
            var orderItem = order.orderItems[i];
            var btn = document.createElement("button");
            btn.id = orderItem.id;
            btn.innerHTML = orderItem.name;
        }
    }
});
connection.on("ReadyOrdersRefreshed", function (orders) {
    var ul = document.getElementById("readyOrders");

    if (ul === null) return;
    ul.innerHTML = "";
    for (var j = 0; j < orders.length; j++) {
        var order = orders[j];
        for (var i = 0; i < order.orderItems.length; i++) {
            var orderItem = order.orderItems[i];
            var btn = document.createElement("button");
            btn.id = orderItem.id;
            btn.innerHTML = orderItem.name;
        }
    }
});
connection.on("DeliveredOrdersRefreshed", function (orders) {
    var ul = document.getElementById("deliveredOrders");

    if (ul === null) return;
    ul.innerHTML = "";
    for (var j = 0; j < orders.length; j++) {
        var order = orders[j];
        for (var i = 0; i < order.orderItems.length; i++) {
            var orderItem = order.orderItems[i];
            var btn = document.createElement("button");
            btn.id = orderItem.id;
            btn.innerHTML = orderItem.name;
        }
    }
    
});

function ToJson(form) {

}




