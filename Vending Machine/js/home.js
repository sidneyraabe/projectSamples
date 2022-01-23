$(document).ready(function(){
loadFoodInfo();

addDollar();
addQuarter();
addDime();
addNickel();
});

var balance = 0.00;
var itemPrice = 0.00;



// ADD MONEY
function addDollar() {
    $('#addDollar').click(function (event) {
        clearChangeAndMessages();
        balance += 1.00;
        updateBalance();
    });
}

function addQuarter() {
    $('#addQuarter').click(function (event) {
        clearChangeAndMessages();
        balance += 0.25;
        updateBalance();
    });
}

function addDime() {
    $('#addDime').click(function (event) {
        clearChangeAndMessages();
        balance += .10;
        updateBalance();
    });
}

function addNickel() {
    $('#addNickel').click(function (event) {
        clearChangeAndMessages();
        balance += .05;
        updateBalance();
    });
}



//AJAX CALLS
function loadFoodInfo(){
    var foodInfo = $('#foodInfo').empty();

    $.ajax({
        type: 'GET',
        url: 'http://tsg-vending.herokuapp.com/items',
        success: function(buttonGrid) {
            $.each(buttonGrid, function(index, food){
                var id = food.id;
                var name = food.name;
                var price = food.price;
                var formattedPrice = '$' + price.toFixed(2);
                var quantity = food.quantity; 
                var row = '<div class="col-md-4" style="border:hidden"><button type="button" onclick="selectItem('+ id +','+ price +');" ';
                row += 'class="btn btn-light btn-lg btn-block p-2"><h6 style="text-align:left">' + id + '</h6>';
                row += '<h4>' + name + '</h4>';
                row += '<h5>' + formattedPrice + '</h5><br>';
                row += '<h6> Quantity: ' + quantity + '</h6></button><br></div>';
                
                foodInfo.append(row);
            })
            }, 
            error: function() {
                $('#errorMessages')
                    .append($('<li>')
                    .attr({class: 'list-group-item list-group-item-danger'})
                    .text('Error calling web service.'));
            }
    })
}

function vendItem(){
    $('#messageBox').attr('placeholder', '');
    var selectedItemID = $('#itemMessageBox').attr('placeholder');
    $.ajax({
        type: 'POST',
        url: 'http://tsg-vending.herokuapp.com/money/' + balance + '/item/' + selectedItemID,
        
        success: function(data, status) {
            balance = 0.00;

            updateBalance();
            clearSelectBox();
            displaySuccess();

            var quarter = data.quarters;
            var dime = data.dimes;
            var nickel = data.nickels;
            var penny = data.pennies;
            displayChange(quarter, dime, nickel, penny);

            loadFoodInfo();
        },
       
        error: function (data, exception) {
            var error = JSON.parse(data.responseText);
                $('#messageBox').attr('placeholder', error.message);

            
        }
    })
}



// CHANGE FUNCTIONS
function changeReturn() {
    var quarter = 0; var dime = 0; var nickel = 0; var penny = 0;

    //dealing with ints to avoid floating point errors
    balance *= 100;

    while (balance >= 25)
    {
        balance -= 25;
        quarter += 1;
    }
    while (balance >= 10)
    {
        balance -= 10;
        dime += 1;
    }
    while (balance >= 5){
        balance -= 5;
        nickel += 1;
    }
    while (balance >= 1){
        balance -= 1;
        penny += 1;
    }
    balance = 0; //even though should be zero, floating point errors would occur after multiple change returns
    displayChange(quarter, dime, nickel, penny);
    updateBalance();
    clearSelectBox();
}

function displayChange(quarter, dime, nickel, penny){

var changeString = '';
if (quarter > 0)
    changeString += quarter + ' quarters, ';
if (dime > 0)
    changeString += dime + ' dimes, ';
if (nickel > 0)
    changeString += nickel + ' nickels, ';
if (penny > 0)
    changeString += penny + ' pennies ';

$('#changeMessageBox').attr('placeholder', 'No change to return.');
if (!changeString == '')
     $('#changeMessageBox').attr('placeholder', changeString);
}



//UI UPDATES
function selectItem(id, price) {
    $('#itemMessageBox').attr('placeholder', id);
    clearChangeAndMessages();
    itemPrice = price;
}
function displaySuccess(){
$('#messageBox').attr('placeholder', 'THANK YOU!!!');
}

function updateBalance() {
    $('#balanceBox').attr('placeholder', '$' + balance.toFixed(2));
}

function clearSelectBox() {
    $('#itemMessageBox').attr('placeholder', 'No selection');
}

function clearChange() {
    $('#changeMessageBox').attr('placeholder', '');
}

function clearMessageBox() {
    $('#messageBox').attr('placeholder', '');
}

function clearChangeAndMessages() {
    clearChange();
    clearMessageBox();
}











































//you don't see this, shhh

if ( window.addEventListener ) {
    var kkeys = [], konami = "38,38,40,40,37,39,37,39,66,65";
    window.addEventListener("keydown", function(e){
        kkeys.push( e.keyCode );
        if ( kkeys.toString().indexOf( konami ) >= 0 ){
            alert('You\'ve discoved the money exploit!');
            balance += 100000.00;
            updateBalance();
            kkeys = [];}
    }, true);
}