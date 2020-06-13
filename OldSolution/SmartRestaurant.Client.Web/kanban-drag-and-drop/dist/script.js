var oldParent;
var orders = document.getElementById("orders");
var progress = document.getElementById("in-progress");
var readyToServe = document.getElementById("ready-to-serve");
var delivred = document.getElementById("delivred");

var drake = dragula([
    document.getElementById('orders'),
    document.getElementById('cooker-1'),
    document.getElementById('cooker-2'),
    document.getElementById('cooker-3'),
    document.getElementById('ready-to-serve'),
    document.getElementById('delivred'),
    document.getElementById('canceled')
], {
        isContainer: function (el) {
            return false; // only elements in drake.containers will be taken into account
        },
        moves: function (el, source, handle, sibling) {
            if (el.dataset.draggable==="false") return false;
            return true; // elements are always draggable by default
        },
        accepts: function (el, target, source, sibling) { 
            if (el.dataset.state === "waitting") {
                return list.isTheFirst(el) & canDrag.From(source).To(target).Check();
            } else {
                return canDrag.From(source).To(target).Check();
            }
                      
            //return true; // elements can be dropped in any of the `containers` by default
        },
        invalid: function (el, handle) {
            return false; // don't prevent any drags from initiating by default
        },
        direction: 'vertical',             // Y axis is considered when determining where an element would be dropped
        copy: false,                       // elements are moved by default, not copied
        copySortSource: false,             // elements in copy-source containers can be reordered
        revertOnSpill: true,              // spilling will put the element back where it was dragged from, if this is true
        removeOnSpill: false,              // spilling will `.remove` the element, if this is true
        mirrorContainer: document.body,    // set the element that gets mirror elements appended
        ignoreInputTextSelection: true     // allows users to select input text, see details below

    })

    .on('drag', function (el) {
        // add 'is-moving' class to element being dragged
        
        el.classList.add('is-moving');
    })

    .on('dragend', function (el) {        
        // remove 'is-moving' class from element after dragging has stopped
        el.classList.remove('is-moving');

        // add the 'is-moved' class for 600ms then remove it
        window.setTimeout(function () {
            el.classList.add('is-moved');
            window.setTimeout(function () {
                el.classList.remove('is-moved');
            }, 600);
        }, 100);

        var newParent = el.parentElement; 
        var currentState = newParent.dataset.addState; 

        if (currentState === "in-progress") {            
            var items = newParent.getElementsByTagName("li");
            for (var i = 0; i < items.length; ++i) {
                if (items[i].dataset.id !== el.dataset.id) {
                    var li = items[i];
                    newParent.removeChild(li);
                    readyToServe.append(li);
                }
            }            
        }
        el.dataset.state = currentState;  
    })

    .on('over', function (el) {        
        oldParent = el.parentElement;        
    });

var canDrag = (function () {
    var _check;
    var _oldParent;
    var _newParent;
    function From(oldParent) {
        _oldParent = oldParent;
        return this;
    }
    function To(newParent) {
        _newParent = newParent;
        return this;
    }    
    function Check() {
        switch (_oldParent.dataset.addState) {
            case "waitting":
                switch (_newParent.dataset.addState) {
                    case "waitting":
                        _check = true;
                        break;
                    case "in-progress":
                        _check = true;
                        break;
                    case "ready-to-serve":
                    case "delivred":
                        _check = false;
                        break;
                }
                break;
            case "in-progress":
                switch (_newParent.dataset.addState) {
                    case "waitting":
                        _check = false;
                        break;
                    case "in-progress":
                        _check = true;
                        break;
                    case "ready-to-serve":
                        _check = true;
                        break;
                    case "delivred":
                        _check = false;
                        break;
                }
                break;
            case "delivred":
                switch (_newParent.dataset.addState) {
                    case "waitting":
                        _check = false;
                        break;
                    case "in-progress":
                        _check = false;
                        break;
                    case "ready-to-serve":
                        _check = false;
                        break;
                    case "delivred":
                        _check = false;
                        break;
                }
                break;

        }
        return _check;
    }
    return {        
        From: From,
        To: To,
        Check:Check
    };
    
}());

var createOptions = (function() {
	var dragOptions = document.querySelectorAll('.drag-options');
	
	// these strings are used for the checkbox labels
	var options = ['Research', 'Strategy', 'Inspiration', 'Execution'];
	
	// create the checkbox and labels here, just to keep the html clean. append the <label> to '.drag-options'
	function create() {
		for (var i = 0; i < dragOptions.length; i++) {

			options.forEach(function(item) {
				var checkbox = document.createElement('input');
				var label = document.createElement('label');
				var span = document.createElement('span');
				checkbox.setAttribute('type', 'checkbox');
				span.innerHTML = item;
				label.appendChild(span);
				label.insertBefore(checkbox, label.firstChild);
				label.classList.add('drag-options-label');
				dragOptions[i].appendChild(label);
			});

		}
	}
	
    return {
        create: create
    };
	
	
}());

var showOptions = (function () {
	
	// the 3 dot icon
	var more = document.querySelectorAll('.drag-header-more');
	
	function show() {
		// show 'drag-options' div when the more icon is clicked
		var target = this.getAttribute('data-target');
		var options = document.getElementById(target);
		options.classList.toggle('active');
	}
	
	
	function init() {
		for (i = 0; i < more.length; i++) {
			more[i].addEventListener('click', show, false);
		}
	}
	
    return {
        init: init
    };
}());

var list = (function () {
    function isTheLast(el) {
        if (el.nextElementSibling) {
            return false;
        } else {
            return true;
        }
    }
    function isTheFirst(el) {
        if (el.previousElementSibling) {  
            return false;
        } else {
            return true;
        }
    }
    return {
        isTheFirst: isTheFirst,
        isTheLast: isTheLast
    };
}());


createOptions.create();
showOptions.init();

var counter = 1;
function CreateInWaitting() {
    var li = document.createElement("li"); 
    li.setAttribute("class", "drag-item waitting"); 
    li.setAttribute("data-state", "waitting"); 
    li.setAttribute("data-id", "order-"+counter); 
    var textnode = document.createTextNode("<h1>" + counter + "</h1>");   

    var h1 = document.createElement("h1");
    h1.innerHTML = counter;
    li.appendChild(h1);
    document.getElementById("orders").append(li); 
    document.getElementById("orders-header").innerHTML="Orders "+ counter; 
    counter++;
    return li;
}


var t;
var timer_is_on = 0;

function timedCount() {
    CreateInWaitting();    
    t = setTimeout(timedCount, 5000);
}

function startAdding() {
    if (!timer_is_on) {
        timer_is_on = 1;
        timedCount();
    }
}
startAdding();
//function stopAdding() {
//    clearTimeout(t);
//    timer_is_on = 0;
//}
