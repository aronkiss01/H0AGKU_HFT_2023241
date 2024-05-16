let AverageSalary = 0;
let YoungerThan = [];
let YoungestPlayerAge = 0;
let YoungsterSalaryinfo = "";
let JuniorLeagueInfo = [];
getData();


async function getData() {
    let url1 = "http://localhost:62823/Info/AverageSalary/";
    let response1 = await fetch(url1);
    let data1 = await response1.json();

    AverageSalary = data1;


    let url2 = "http://localhost:62823/Info/GetPlayersYoungerThanX/";
    let response2 = await fetch(url2);
    let data2 = await response2.json();

    YoungerThan = data2;


    let url3 = "http://localhost:62823/Info/GetYoungestPlayerAge/";
    let response3 = await fetch(url3);
    let data3 = await response3.json();
    YoungestPlayerAge = data3;


    let url4 = "http://localhost:62823/Info/GetYoungsterSalaryInfo/";
    let response4 = await fetch(url4);
    let data4 = await response4.text();
    YoungsterSalaryinfo = data4;

    let url5 = "http://localhost:62823/JuniorLeague/GetJuniorLeagueInfo/";
    let response5 = await fetch(url5);
    let data5 = await response5.json();
    JuniorLeagueInfo = data5;





    display1();
    display2();
    display3();
    display4();
    display5();



}

function display1() {
    document.querySelector("#averageSalary").innerHTML += "<ul><li>" + AverageSalary + "</li>";
    document.querySelector("#averageSalary").innerHTML += "</ul>";
}

function display2() {
    document.querySelector("#youngerthan").innerHTML += "<ul>";
    YoungerThan.forEach(t => {
        document.querySelector("#youngerthan").innerHTML += "<li>" + t.name + "</li>";
    })
    document.querySelector("#youngerthan").innerHTML += "</ul>";
}

function display3() {
    document.querySelector("#youngestPlayerAge").innerHTML += "<ul>";
    YoungestPlayerAge.forEach(t => {
        document.querySelector("#youngestPlayerAger").innerHTML += "<li>" + t.age + "</li>";
    })
    document.querySelector("#youngestPlayerAge").innerHTML += "</ul>";
}

function display4() {
    document.querySelector("#youngsterSalaryinfo").innerHTML += "<ul><li> " + t + "</li>";
    document.querySelector("#youngsterSalaryinfo").innerHTML += "</ul>";
}
function display5()
{
    document.querySelector("#juniorLeagueInfo").innerHTML += "<ul><li> " + t.getData + "</li>";
    document.querySelector("#juniorLeagueInfo").innerHTML += "</ul>";
}