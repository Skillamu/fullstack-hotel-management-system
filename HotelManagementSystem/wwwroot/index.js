const app = document.getElementById("app")
const guestId = ""
const jwt = ""

homePageView()
function homePageView() {
    app.innerHTML = `
    <h1 onclick="hotelRoomView()">Hotel room</h1>
    <h1 onclick="findReservationsView()">My reservations</h1>
    `
}

async function hotelRoomView() {
    const response = await fetch("https://localhost:7235/api/RoomType")
    const roomTypes = await response.json()

    roomTypes.sort(sortRoomTypesAscending)

    app.innerHTML = `
    <h1>Hotel room</h1>
    `

    for (let i = 0; i < roomTypes.length; i++) {
        app.innerHTML += `
        <div>
            <h3>${roomTypes[i].type}</h3>

            <ul class="${roomTypes[i].type.toLowerCase()}">
                <li>No smoking</li>
            </ul>
        </div>
        `

        if (roomTypes[i].hasCityView) {
            document.querySelector(`.${roomTypes[i].type.toLowerCase()}`)
                .innerHTML += `<li>City view</li>`
        }

        if (roomTypes[i].hasBathtub) {
            document.querySelector(`.${roomTypes[i].type.toLowerCase()}`)
                .innerHTML += `<li>Bathtub</li>`
        }
    }
}

function sortRoomTypesAscending(a, b) {
    const roomTypeOrder = ["Standard", "Superior", "Deluxe"]

    return roomTypeOrder.indexOf(a.type) - roomTypeOrder.indexOf(b.type)
}

async function findReservationsView() {
    const response = await fetch(`https://localhost:7235/api/Guest/${guestId}/reservations`, {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
            "Authorization": `Bearer ${jwt}`
        }
    })

    if (response.status == 404 || response.status == 401) {
        app.innerHTML = `
        <h1>Find your reservations</h1>

        <p>To find your reservations, please enter your phone number and click “Send”. <br>
        We’ll use this phone number to verify your identity and retrieve your reservations.</p>

        <h2>Phone number</h2>
        <input type="text"> <br>
        <button onclick="sendVerificationCode()">Send</button> <br> <br>
        `
        return
    }

    app.innerHTML = `
    <h1>Your reservations</h1>
    <p>Coming soon...</p>
    `
}

async function sendVerificationCode() {
    app.innerHTML = `
    <h1>Find your reservations</h1>
    <p>Coming soon...</p>
    `
}