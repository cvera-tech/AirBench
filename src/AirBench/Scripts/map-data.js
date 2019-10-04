const apiUrl = '/api/';
const benchUrl = apiUrl + 'bench/';

async function getBenches() {
    const response = await fetch(benchUrl + 'list');
    const obj = await response.json();
    
    // Get the benches array within the response object
    const benches = obj.benches;
    return benches;
}