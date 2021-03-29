// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const uri = 'http://localhost:56664/api/hotel';
let hotelist = [];



function getHotels() {
    
    fetch(uri, {
        method: 'GET',
        mode: 'cors',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json; charset=utf-8',
            'Access-Control-Allow-Origin': '*'
        },
    })
        .then(response => response.json())
        .then(data => _displayHotelList(data))
        .catch(error => console.error('Unable to get items.', error));
}

function addHotel() {

    const hotel = {
        HotelName: document.getElementById('HotelName').value,
        HotelType: document.getElementById('HotelType').value,
        Comments: document.getElementById('Comments').value
    };
    //Fetch API
    //axios
    //jquery ajax
    //angular http service
    fetch(uri, {
        method: 'POST',
        mode: 'cors',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json; charset=utf-8',
            'Access-Control-Allow-Origin': '*'
        },
        body: JSON.stringify(hotel)
    })
        .then(response => response.json())
        .then(() => {
            getHotels();
            ///addNameTextbox.value = '';
        })
        .catch(error => console.error('Unable to add item.', error));
}

function deleteItem(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getHotels())
        .catch(error => console.error('Unable to delete item.', error));
}

function displayEditForm(id) {
    
    const item = hotelist.find(item => item.hotelId === id);

    document.getElementById('editHotelId').value = item.hotelId;
    document.getElementById('editHotelName').value = item.hotelName;
    document.getElementById('editHotelType').value = item.hotelType;
    document.getElementById('editComments').value = item.comments;
    document.getElementById('editForm').style.display = 'block';
}

function updateItem() {
    const hotelId = document.getElementById('editHotelId').value;
    const hotel = {
        HotelName: document.getElementById('editHotelName').value,
        HotelType: document.getElementById('editHotelType').value,
        Comments: document.getElementById('editComments').value
    };

    fetch(`${uri}/${hotelId}`, {
        method: 'PUT',
        mode: 'cors',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json; charset=utf-8',
            'Access-Control-Allow-Origin': '*'
        },
        body: JSON.stringify(hotel)
    })
        .then(() => getHotels())
        .catch(error => console.error('Unable to update item.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}

function _displayCount(itemCount) {
    const name = (itemCount === 1) ? 'to-do' : 'to-dos';

    document.getElementById('counter').innerText = `${itemCount} ${name}`;
}

function _displayHotelList(data) {
    
    const tBody = document.getElementById('hotellist');
    tBody.innerHTML = '';

    _displayCount(data.length);

    const button = document.createElement('button');

    data.forEach(item => {
        let lableforId = document.createElement('label');
        lableforId.innerHTML = item.hotelId;

        let lableforHotelName = document.createElement('label');
        lableforHotelName.innerHTML = item.hotelName;

        let lableforHotelType = document.createElement('label');
        lableforHotelType.innerHTML = item.hotelType;

        let lableforComments = document.createElement('label');
        lableforComments.innerHTML = item.comments;

        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${item.hotelId})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteItem(${item.hotelId})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        td1.appendChild(lableforId);

        let td2 = tr.insertCell(1);
        td2.appendChild(lableforHotelName);

        let td3 = tr.insertCell(2);
        td3.appendChild(lableforHotelType);

        let td4 = tr.insertCell(3);
        td4.appendChild(lableforComments);

        //let td2 = tr.insertCell(1);
        //let textNode = document.createTextNode(item.name);
        //td2.appendChild(textNode);

        let td5 = tr.insertCell(4);
        td5.appendChild(editButton);

        let td6 = tr.insertCell(5);
        td6.appendChild(deleteButton);
    });

    hotelist = data;
}