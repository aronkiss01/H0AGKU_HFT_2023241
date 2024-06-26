﻿let leagues = [];
let connection = null;
let leagueIdToUpdate = -1;
getdata();
setupSignalR();

//fetch('http://localhost:62823/League')
//    .then(x => x.json())
//    .then(y => console.log(y));

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:62823/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("LeagueCreated", (user, message) => {
        getdata();
    });

    connection.on("LeagueDeleted", (user, message) => {
        getdata();
    });
    connection.on("LeagueUpdated", (user, message) => {
        getdata();
    });
    connection.onclose(async () => {
        await start();
    });
    start();


}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:62823/League')
        .then(x => x.json())
        .then(y => {
            leagues = y;
            //console.log(leagues);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    leagues.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>" + t.name + "</td ><td>"
            + t.country + "</td><td>" +
            `<button type="button" onclick="remove(${t.id})">Delete</button>` + `<button type="button"
            onclick="showupdate(${t.id})">Update</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:62823/League/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function create() {
    let Lname = document.getElementById('lname').value;   
    let Lcountry = document.getElementById('country').value;
    fetch('http://localhost:62823/League/', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: Lname, country: Lcountry })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}
function showupdate(id) {
    document.getElementById('lnameupdate').value = leagues.find(t => t['id'] == id)['name'];
    document.getElementById('countryupdate').value = leagues.find(t => t['id'] == id)['country'];
    document.getElementById('updateformdiv').style.display = 'flex';
    leagueIdToUpdate = id;

}
function update() {
    document.getElementById('updateformdiv').style.display = 'none';   
    let name = document.getElementById('lnameupdate').value;
    let country = document.getElementById('countryupdate').value; 
    fetch('http://localhost:62823/League/', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Id: leagueIdToUpdate,name:name,country:country}),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.log('Error:', error); });
}