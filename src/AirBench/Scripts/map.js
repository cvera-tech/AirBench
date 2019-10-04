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


        // Init popup
        const popup = {
            container: document.getElementById('popup'),
            content: document.getElementById('popup-content')
        };

        const overlay = new Overlay({
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
        // const featureOptions = { geometry: new Point(FromLonLat([longitude, latitude])) };
        // foreach(key in markerOptions) {
        //     featureOptions.setProperty()
        // }

        // Add a geometry object to the marker options
        markerOptions.geometry = new Point(FromLonLat([longitude, latitude]));
        const iconFeature = new Feature(markerOptions);

        getVectorSource(map).addFeature(iconFeature);
    }

    function getVectorSource(map) {
        const layers = map.getLayers();
        const vectorLayer = layers.item(1);
        const vectorSource = vectorLayer.getSource();
        return vectorSource;
    }

    function registerEventListeners(map, eventObjects) {
        map.on('singleclick', (e) => {
            const overlay = eventObjects.overlay;
            const feature = map.forEachFeatureAtPixel(e.pixel,
                // callback function exits on the first truthy value
                // i.e. it returns the top-most feature on the map
                feature => feature
            );
            if (feature) {
                const coordinates = feature.getGeometry().getCoordinates();
                overlay.setPosition(coordinates);
            } else {
                overlay.setPosition(undefined);
            }
        })
    }

    const map = initMap();
    // addMarker(0, 0);
    // addMarker(.5, .5);
    // addMarker(0, .5);
    // addMarker(15, 28);
    // addMarker(23, -15);
    
    const benches = await getBenches();
    for(bench of benches) {
        console.log(bench.description);
        addMarker(bench.longitude, bench.latitude, bench)
    }
    console.log(benches);
})();
