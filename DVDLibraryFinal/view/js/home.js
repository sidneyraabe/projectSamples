$(document).ready(function () {
    loadDVDs();
    addDVD();
    updateDVD();
    ObtainUrlString();

});

// retrieve and display

var setUrl = 'https://localhost:44345';
// SG API location: http://dvd-library.us-east-1.elasticbeanstalk.com

function loadDVDs() {
    clearDVDTable();
    $('#navDiv').show();
    var contentRows = $('#contentRows');
    $('#dvdTableDiv').show();

    $.ajax({
        type: 'GET',
        url: setUrl + '/dvds',
        success: function (dvdArray) {
            $.each(dvdArray, function (index, dvd) {
                var title = dvd.title;
                var releaseYear = dvd.releaseYear;
                var director = dvd.director;
                var rating = dvd.rating;
                var dvdId = dvd.id;

                var row = '<tr>';
                row += '<td><a href="#" onclick="showDvdDetails(' + dvdId + ')">' + title + '</td>';
                row += '<td>' + releaseYear + '</td>';
                row += '<td>' + director + '</td>';
                row += '<td>' + rating + '</td>';
                row += '<td><a href="#" onclick="showEditForm(' + dvdId + ')">Edit</a>' + ' | ' + '<a href="#" onclick="deleteDVD(' + dvdId + ')">Delete</a></td>';
                row += '</tr>';

                contentRows.append(row);
            })

        },
        error: function () {
            $('#errorMessages')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling web service. Is the URL wrong?'));
        }
    })
}

function showDvdDetails(dvdId) {
    $('#navDiv').hide();
    $('#dvdTableDiv').hide();
    $('#dvdDetailsDiv').show();
    $.ajax({
        type: 'GET',
        url: setUrl + '/dvd/' + dvdId,
        success: function (data, status) {
            $('#dvdId').text(dvdId)
            $('#dvdTitle').text(data.title);
            $('#dvdReleaseYear').text(data.releaseYear);
            $('#dvdDirector').text(data.director);
            $('#dvdRating').text(data.rating);
            $('#dvdNotes').text(data.notes);
        },
        error: function () {
            $('#errorMessages')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling web service. Please try again later.'));
        }
    })
}

// edit

function showEditForm(dvdId) {
    $('#navDiv').hide();
    $('#errorMessages').empty();
    $('#dvdTableDiv').hide();


    $.ajax({
        type: 'GET',
        url: setUrl +'/dvd/' + dvdId,
        success: function (data, status) {
            $('#editDVDId').val(data.id);
            $('#editTitle').val(data.title);
            $('#editReleaseYear').val(data.releaseYear);
            $('#editDirector').val(data.director);
            $('#editRating').val(data.rating);
            $('#editNotes').val(data.notes);
        },
        error: function () {
            $('#errorMessages')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling web service. Please try again later.'));
        }
    })
    $('#editFormDiv').show();

}

function updateDVD(dvdId) {
    $('#updateButton').click(function (event) {
        $.ajax({
            type: 'PUT',
            url: setUrl + '/dvd/' + $('#editDVDId').val(),
            data: JSON.stringify({
                id: $('#editDVDId').val(),
                title: $('#editTitle').val(),
                releaseYear: $('#editReleaseYear').val(),
                director: $('#editDirector').val(),
                rating: $('#editRating').val(),
                notes: $('#editNotes').val()
            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            'dataType': 'json',
            success: function () {
                $('#errorMessages').empty();

                hideEditForm();
                loadDVDs();

            },
            error: function () {
                $('#errorMessages')
                    .append($('<li>')
                        .attr({ class: 'list-group-item list-group-item-danger' })
                        .text('Error calling web service. Please try again later.'));
            }
        })
    })
}


// add

function addDVD() {
    $('#createAddButton').click(function (event) {
        var haveValidationErrors = checkAndDisplayValidationErrors($('#createFormDiv').find('input'));

        if (haveValidationErrors) {
            return false;
        }
        $.ajax({
            type: 'POST',
            url: setUrl + '/dvd',
            data: JSON.stringify({
                title: $('#addTitle').val(),
                releaseYear: $('#addReleaseYear').val(),
                director: $('#addDirector').val(),
                rating: $('#addRating').val(),
                notes: $('#addNotes').val()
            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            'dataType': 'json',
            success: function () {
                $('#errorMessages').empty();
                $('#addTitle').val('');
                $('#addReleaseYear').val('');
                $('#addDirector').val('');
                $('#addRating').val('G');
                $('#addNotes').val('');
                hideAddForm();
                loadDVDs();
            },
            error: function () {
                $('#errorMessages')
                    .append($('<li>')
                        .attr({ class: 'list-group-item list-group-item-danger' })
                        .text('Error calling web service. Please try again later.'));
            }
        })
    });
}

// delete



function deleteDVD(dvdId) {
    if (confirm('Are you sure you wish to delete this DVD?')) {
        $.ajax({
            type: 'DELETE',
            url: setUrl + '/dvd/' + dvdId,
            success: function () {
                loadDVDs();
            },
            error: function () {
alert("Looks like there's a boo boo.");
            }
        })
    }
}

// Search

function ObtainUrlString() {
    $('#searchButton').click(function (event) {
        
        var category = $('#dropdownMenu').val();
        var dvdString = $('#addSearchTerm').val();
        var urlString = category + '/' + dvdString;

        loadDVDsByCategory(urlString);
    })
}

function loadDVDsByCategory(urlString) {

    clearDVDTable();
    $('#navDiv').show();
    var contentRows = $('#contentRows');
    $('#dvdTableDiv').show();

    $.ajax({
        type: 'GET',
        url: setUrl + '/dvds/' + urlString,
        success: function (dvdArray) {
            $.each(dvdArray, function (index, dvd) {
                var title = dvd.title;
                var releaseYear = dvd.releaseYear;
                var director = dvd.director;
                var rating = dvd.rating;
                var dvdId = dvd.id;

                var row = '<tr>';
                row += '<td><a href="#" onclick="showDvdDetails(' + dvdId + ')">' + title + '</td>';
                row += '<td>' + releaseYear + '</td>';
                row += '<td>' + director + '</td>';
                row += '<td>' + rating + '</td>';
                row += '<td><a href="#" onclick="showEditForm(' + dvdId + ')">Edit</a>' + ' | ' + '<a href="#" onclick="deleteDVD(' + dvdId + ')">Delete</a></td>';
                row += '</tr>';

                contentRows.append(row);
            })

        },
        error: function () {
            $('#errorMessages')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling web service. Is the URL wrong?' + urlString));
        }
    })
}

//validate 

function checkAndDisplayValidationErrors(input) {
    $('#errorMessages').empty();

    var errorMessages = [];

    input.each(function () {
        if (!this.validity.valid) {
            var errorField = $('label[for=' + this.id + ']').text();
            errorMessages.push(errorField + ' ' + this.validationMessage);
        }
    });

    if (errorMessages.length > 0) {
        $.each(errorMessages, function (index, message) {
            $('#errorMessages').append($('<li>').attr({ class: 'list-group-item list-group-item-danger' }).text(message));
        });

        return true;
    } else {
    
        return false;
    }
}

// UI helpers

function hideDvdDetailsForm() {

    $('#dvdDetailsDiv').hide();
}
function clearDVDTable() {
    $('#contentRows').empty();
}

function openAddForm() {
    $('#createFormDiv').show();
    $('#dvdTableDiv').hide();
    $('#navDiv').hide();

    $('#errorMessages').empty();
    $('#addTitle').val('');
    $('#addReleaseYear').val('');
    $('#addDirector').val('');
    $('#addRating').val('G');
    $('#addNotes').val('');

}
function hideAddForm() {
    $('#createFormDiv').hide();
}
function hideEditForm() {
    $('#errorMessages').empty();

    $('#editTitle').val('');
    $('#editReleaseYear').val('');
    $('#editDirector').val('');
    $('#editRating').val('');
    $('#editNotes').val('');

    $('#editFormDiv').hide();
}
