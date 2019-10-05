(async () => {
    // Aliases
    const Feature = ol.Feature;
    const FromLonLat = ol.proj.fromLonLat;
    const Map = ol.Map;
    const OSM = ol.source.OSM;
    const Overlay = ol.Overlay;
    const Point = ol.geom.Point;
    const TileLayer = ol.layer.Tile;
    const ToLonLat = ol.proj.toLonLat;
    const VectorLayer = ol.layer.Vector;
    const VectorSource = ol.source.Vector;
    const View = ol.View;

    const gebi = (e) => document.getElementById(e);

    // HTML element IDs
    const benchAddedById = 'bench-added-by';
    const benchDescriptionId = 'bench-description';
    const benchDetailsId = 'bench-details';
    const benchLatitudeId = 'bench-latitude';
    const benchListId = 'bench-list';
    const benchListTableId = 'bench-list-table';
    const benchLongitudeId = 'bench-longitude';
    const benchRatingId = 'bench-rating';
    const benchReviewsId = 'bench-reviews';
    const benchSeatsId = 'bench-seats';
    const mapId = 'map';
    const popupOverlayId = 'popup';
    const seatsSelectId = 'seats-select';

    const popup = {
        container: gebi('popup'),
        content: gebi('popup-content')
    };

    function initMap() {
        // Initial parameters
        const initCenter = [0, 0];
        const initZoom = 3;

        // The layer with the map tiles to use
        const rasterLayer = new TileLayer({
            source: new OSM()
        });

        // The layer with the points on the map to render
        const vectorLayer = new VectorLayer({
            source: new VectorSource()
        });

        const overlay = new Overlay({
            id: popupOverlayId,
            element: popup.container,
            autoPan: true,
            autoPanAnimation: {
                duration: 250
            }
        });

        const map = new Map({
            layers: [rasterLayer, vectorLayer],
            overlays: [overlay],
            target: mapId,
            view: new View({
                center: initCenter,
                zoom: initZoom
            })
        });

        registerEventListeners(map, {
            overlay: overlay
        });

        return map;
    }

    function addBenchMarker(bench) {
        addMarker(bench.latitude, bench.longitude, bench);
    }

    // clear the vector layer and readd features
    function addBenchMarkers(benches) {
        getVectorSource().clear();
        benches.forEach(b => {
            addBenchMarker(b);
        });
    }

    function addMarker(latitude, longitude, markerOptions = {}) {
        markerOptions.geometry = new Point(FromLonLat([longitude, latitude]));
        const iconFeature = new Feature(markerOptions);

        getVectorSource().addFeature(iconFeature);
    }

    function buildBenchDetails(bench) {
        // Fill out table head
        gebi(benchDescriptionId).innerHTML = bench.description;
        gebi(benchLatitudeId).innerHTML = bench.latitude;
        gebi(benchLongitudeId).innerHTML = bench.longitude;
        gebi(benchSeatsId).innerHTML = bench.numberSeats;
        gebi(benchRatingId).innerHTML = bench.averageRating === null ? 'no ratings' : bench.averageRating;
        gebi(benchAddedById).innerHTML = bench.addedBy;

        buildList(bench.reviews, benchReviewsId, buildReviewListRow);
    }

    /**
     * Builds an HTML table rows for a given list.
     * @param {Array} list
     * @param {string} targetElementId
     * @param {function} rowBuilder
     */
    function buildList(list, targetElementId, rowBuilder) {
        let content = [];
        for (listElement of list) {
            content.push(rowBuilder(listElement));
        }
        gebi(targetElementId).innerHTML = content.join();
    }

    function buildBenchListRow(bench) {
        const avgRating = bench.averageRating;
        const rating = avgRating === null ? 'no ratings' : avgRating;
        const content = 
        `<tr><td colspan="2">
            <table class="table">
                <thead></thead>
                <tbody>
                    <tr>
                        <td>Description</td>
                        <td>${bench.description}</td>
                    </tr>
                    <tr>
                        <td>Latitude</td>
                        <td>${bench.latitude}</td>
                    </tr>
                    <tr>
                        <td>Longitude</td>
                        <td>${bench.longitude}</td>
                    </tr>
                    <tr>
                        <td>Seats</td>
                        <td>${bench.numberSeats}</td>
                    </tr>
                    <tr>
                        <td>Rating</td>
                        <td>${rating}</td>
                    </tr>
                </tbody>
            </table>
        </td></tr>`;
        return content;
    }

    // TODO: Rewrite to match other build functions
    function buildPopupContent(feature) {
        let content = '<table><thead></thead><tbody>';
        content += '<tr><td>Description</td><td>' + feature.get('description') + '</td></tr>';
        content += '<tr><td>Latitude</td><td>' + feature.get('latitude') + '</td></tr>';
        content += '<tr><td>Longitude</td><td>' + feature.get('longitude') + '</td></tr>';
        content += '<tr><td>Seats</td><td>' + feature.get('numberSeats') + '</td></tr>';
        const avgRating = feature.get('averageRating');
        const rating = avgRating === null ? 'no ratings' : avgRating;
        content += '<tr><td>Rating</td><td>' + rating + '</td></tr>';
        content += '</tbody></table>';
        return content;
    }

    function buildReviewListRow(review) {
        const content = 
        `<tr><td colspan="2">
            <table class="table">
                <thead></thead>
                <tbody>
                    <tr>
                        <td>Date</td>
                        <td>${review.date}</td>
                    </tr>
                    <tr>
                        <td>Reviewer</td>
                        <td>${review.reviewer}</td>
                    </tr>
                    <tr>
                        <td>Rating</td>
                        <td>${review.rating}</td>
                    </tr>
                    <tr>
                        <td>Description</td>
                        <td>${review.description}</td>
                    </tr>
                </tbody>
            </table>
        </td></tr>`;
        return content;
    }

    async function getBenchFromFeature(feature) {
        const benchId = feature.get('id');

        // Make an API call to get the reviews as well
        const bench = await getBench(benchId);
        return bench;
    }

    function getVectorSource() {
        const layers = map.getLayers();
        const vectorLayer = layers.item(1);
        const vectorSource = vectorLayer.getSource();
        return vectorSource;
    }

    function showDetailsTable() {
        gebi(benchDetailsId).classList.remove('hidden');
        gebi(benchListTableId).classList.add('hidden');
    }

    function hideDetailsTable() {
        gebi(benchDetailsId).classList.add('hidden');
        gebi(benchListTableId).classList.remove('hidden');
    }

    function registerEventListeners(map) {

        // Map listeners
        map.on('singleclick', async (e) => {
            const overlay = map.getOverlayById(popupOverlayId);
            const feature = map.forEachFeatureAtPixel(e.pixel,
                // callback function exits on the first truthy value
                // i.e. it returns the top-most feature on the map
                feature => feature
            );
            if (feature) {
                const coordinates = feature.getGeometry().getCoordinates();
                popup.content.innerHTML = buildPopupContent(feature);
                overlay.setPosition(coordinates);

                const bench = await getBenchFromFeature(feature);
                buildBenchDetails(bench);
                showDetailsTable();
            } else {
                overlay.setPosition(undefined);
                hideDetailsTable();
            }
        })

        // Table listeners
        const seatsSelect = gebi(seatsSelectId);
        seatsSelect.addEventListener('change', (e) => {
            const seats = parseInt(e.target.value);
            let benchList;
            if (seats === 0) {
                benchList = benches;
            } else {
                benchList = benches.filter(b => b.numberSeats === seats);
            }
            addBenchMarkers(benchList);
            buildList(benchList, benchListId, buildBenchListRow);
            map.getOverlayById(popupOverlayId).setPosition(undefined);
        });
    }

    //********************
    // Now do things
    //********************
    let benches = await getBenches();
    const map = initMap();
    registerEventListeners(map);

    addBenchMarkers(benches);
    buildList(benches, benchListId, buildBenchListRow);
})();
