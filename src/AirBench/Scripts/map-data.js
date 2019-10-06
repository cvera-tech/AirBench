const apiUrl = '/api/';
const benchUrl = apiUrl + 'bench/';

async function getBenches() {
    const response = await fetch(benchUrl);
    const obj = await response.json();
    
    // Get the benches array within the response object
    const benches = obj.benches;
    return benches;
}

async function getBench(id) {
    const response = await fetch(`${benchUrl}${id}`);
    const obj = await response.json();

    if (obj.success === true) {
        // Perhaps using the delete operator would suffice:
        //   delete obj.success;
        const bench = {
            id: obj.id,
            description: obj.description,
            latitude: obj.latitude,
            longitude: obj.longitude,
            numberSeats: obj.numberSeats,
            averageRating: obj.averageRating,
            addedBy: obj.addedBy,
            reviews: obj.reviews
        };
        return bench;
    } else {
        return undefined;
    }
}