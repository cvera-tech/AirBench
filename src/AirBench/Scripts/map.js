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

    class Bench {
        constructor(id, description, latitude, longitude, numberSeats, avgRating) {
            this.id = id;
            this.description = description;
            this.latitude = latitude;
            this.longitude = longitude;
            this.numberSeats = numberSeats;
            this.avgRating = avgRating;
        }
    }

    const popup = {
        container: document.getElementById('popup'),
        content: document.getElementById('popup-content'),
        // button: document.getElementById('popup-details')
    };

    function initMap() {
        // Initial parameters
        const initCenter = [0, 0];
        const initZoom = 3;
        const mapId = 'map';

        // The layer with the map tiles to use
        const rasterLayer = new TileLayer({
            source: new OSM()
        });

        // The layer with the points on the map to render
        const vectorLayer = new VectorLayer({
            source: new VectorSource()
        });

        const overlay = new Overlay({
            id: 'popup',
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

    function addMarker(latitude, longitude, markerOptions = {}) {
        markerOptions.geometry = new Point(FromLonLat([longitude, latitude]));
        const iconFeature = new Feature(markerOptions);

        getVectorSource(map).addFeature(iconFeature);
    }

    // function getBenchFromFeature(feature) {
    //     let bench = {
    //         id: feature.get('id'),
    //         latitude: feature.get('latitude'),
    //         longitude: feature.get('longitude'),
    //         numberSeats: feature.get('numberSeats'),
    //         av
    //     };
    // }

    function getPopupContent(feature) {
        let content = '';
        content += '<table><thead></thead><tbody>';
        const description = feature.get('description');
        const descriptionArray = description.split(' ');
        let shortDescription;
        if (descriptionArray.length > 10) {
            const shortDescriptionArray = descriptionArray.slice(0, 10);
            shortDescription = shortDescriptionArray.join(' ') + '...';
        } else {
            shortDescription = description;
        }
        content += '<tr><td>Description</td><td>' + shortDescription + '</td></tr>';
        content += '<tr><td>Latitude</td><td>' + feature.get('latitude') + '</td></tr>';
        content += '<tr><td>Longitude</td><td>' + feature.get('longitude') + '</td></tr>';
        content += '<tr><td>Seats</td><td>' + feature.get('numberSeats') + '</td></tr>';
        const avgRating = feature.get('averageRating');
        const rating = avgRating === null ? 'no ratings' : avgRating;
        content += '<tr><td>Rating</td><td>' + rating + '</td></tr>';
        return content;
    }

    function getVectorSource(map) {
        const layers = map.getLayers();
        const vectorLayer = layers.item(1);
        const vectorSource = vectorLayer.getSource();
        return vectorSource;
    }

    function registerEventListeners(map) {
        map.on('singleclick', (e) => {
            const overlay = map.getOverlayById('popup');
            const feature = map.forEachFeatureAtPixel(e.pixel,
                // callback function exits on the first truthy value
                // i.e. it returns the top-most feature on the map
                feature => feature
            );
            if (feature) {
                const coordinates = feature.getGeometry().getCoordinates();
                popup.content.innerHTML = getPopupContent(feature);
                overlay.setPosition(coordinates);
            } else {
                overlay.setPosition(undefined);
            }
        })
    }

    //********************
    // Now do things
    //********************
    const map = initMap();
    registerEventListeners(map);

    const benches = await getBenches();
    benches.forEach(b => addBenchMarker(b));
})();
