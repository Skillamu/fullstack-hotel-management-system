const app = document.getElementById("app")

homePageView()
function homePageView() {
    app.innerHTML = `
    <h1 onclick="hotelRoomView()">Hotel room</h1>
    <h1>My reservations</h1>
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