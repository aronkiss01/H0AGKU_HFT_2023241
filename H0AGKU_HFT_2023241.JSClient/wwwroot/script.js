let players = [];

//fetch('http://localhost:62823/Player')
//    .then(x => x.json())
//    .then(y => console.log(y));

let connection = null;
let playerIdToUpdate = -1;
getdata();
setupSignalR();
function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:62823/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("PlayerCreated", (user, message) => {
        getdata();
    });
    connection.on("PlayerDeleted", (user, message) => {
        getdata();
    });
    connection.on("PlayerUpdated", (user, message) => {
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
    await fetch('http://localhost:62823/Player')
        .then(x => x.json())
        .then(y => {
            authors = y;
            //console.log(players);
            display();
        });
}
function display() {
    document.getElementById('resultarea').innerHTML = "";
    authors.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.name + "</td><td>" + t.age
            + "</td><td>" + t.playerSalary + "</td><td>" +
            `<button type="button" onclick="remove(${t.id})">Delete</button>`
            + `<button type="button" onclick="showupdate(${t.id})">Update</button>` + "</td></tr>";
    });
}
function remove(id) {
    fetch('http://localhost:62823/Player' + id, {
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

function showupdate(id) {
    document.getElementById('playernameupdate').value = authors.find(t => t['id'] == id)['name'];
    document.getElementById('ageupdate').value = authors.find(t => t['id'] == id)['age'];  
    document.getElementById('playersupdate').value = authors.find(t => t['id'] == id)['playerSalary'];
    document.getElementById('updateformdiv').style.display = 'flex';
    playerIdToUpdate = id;
}
function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let Pname = document.getElementById('playernameupdate').value;
    let PAge = document.getElementById('ageupdate').value;
    let Psalary = document.getElementById('playersupdate').value;  
    fetch('http://localhost:62823/Player/', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(
            { Id: playerIdToUpdate,name:Pname,age:PAge,playerSalary:Psalary}),
    })
        .then(response => response.json())
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.log('Error:', error); });
}
function create() {
    let CPname = document.getElementById('playername').value;
    let CPage = document.getElementById('age').value;
    let CPsalary = document.getElementById('playersalary').value;   
    fetch('http://localhost:62823/Player/', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {  name:CPname,age:CPage,playerSalary:CPsalary}),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}