let teams = [];
let connection = null;

let teamIdToUpdate = -1;

getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:62823/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("TeamCreated", (user, message) => {
        getdata();
    });

    connection.on("TeamDeleted", (user, message) => {
        getdata();
    });

    connection.on("TeamUpdated", (user, message) => {
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
        console.log("SignalR Connected.")
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
}

async function getdata() {
    await fetch('http://localhost:62823/team')
        .then(x => x.json())
        .then(y => {
            teams = y;
            
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    teams.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>" + t.name +
            "</td><td>" + `<button type="button"
            onclick="remove(${t.id})">Delete</button>` + `<button type="button"
            onclick="showupdate(${t.id})">Update</button>` + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:62823/team/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.log('Error:', error); });
}

function showupdate(id) {
    document.getElementById('teamnametoupdate').value = teams.find(t => t['id'] == id)['name'];             
    document.getElementById('updateformdiv').style.display = 'flex';
    teamIdToUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let Tname = document.getElementById('teamnametoupdate').value;     
    fetch('http://localhost:62823/team', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: Tname, id:teamIdToUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.log('Error:', error); });
}

function create() {
    let Tname = document.getElementById('teamname').value;             
    fetch('http://localhost:62823/team', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: Tname})
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.log('Error:', error); });
}