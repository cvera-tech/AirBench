(() => {
    // Aliases
    const Feature = ol.Feature;
    const LonLat = ol.proj.fromLonLat;
    const Map = ol.Map;
    const OSM = ol.source.OSM;
    const Overlay = ol.Overlay;
    const Point = ol.geom.Point;
    const TileLayer = ol.layer.Tile;
    const VectorLayer = ol.layer.Vector;
    const VectorSource = ol.source.Vector;
    const View = ol.View;

    function initMap() {
        // Initial parameters
        const initCenter = [0, 0];
        const initZoom = 2;
        const mapId = 'map';

        // The layer with the map tiles to use
        const rasterLayer = new TileLayer({
            source: new OSM()
        });

        // The layer with the points on the map to render
        const vectorLayer = new VectorLayer({
            source: new VectorSource()
        });

        const map = new Map({
            layers: [rasterLayer, vectorLayer],
            target: mapId,
            view: new View({
                center: initCenter,
                zoom: initZoom
            })
        });

        // Init popup
        const popupElement = document.querySelector('#popup');
        const popupOverlay = new Overlay({
            element: popupElement,
            positioning: 'bottom-center',
            stopEvent: false,
            offset: [0, -50]
        });
        map.addOverlay(popupOverlay);

        registerEventListeners(map, popupElement, popupOverlay);
        return map;
    }

    function addMarker(map, latitude, longitude) {
        const iconFeature = new Feature({
            geometry: new Point(LonLat([longitude, latitude]))
        });

        getVectorSource(map).addFeature(iconFeature);
    }

    function getVectorSource(map) {
        const layers = map.getLayers();
        const vectorLayer = layers.item(1);
        const vectorSource = vectorLayer.getSource();
        return vectorSource;
    }

    function registerEventListeners(map, popupElement, popupOverlay) {
        map.on('click', e => {
            // Get the features clicked
            const feature = map.forEachFeatureAtPixel(e.pixel, feature => feature);

            if (feature) {
                const coordinates = feature.getGeometry().getCoordinates();
                popupOverlay.setPosition(coordinates);
                $(popupElement).popover({
                    placement: 'top',
                    html: true,
                    content: feature.get('name')
                });
                $(popupElement).popover('show');
            } else {
                $(popupElement).popover('destroy');
            }

        })
    }

    const map = initMap();
    addMarker(map, 15, 28);
    addMarker(map, 23, -15);

})();
