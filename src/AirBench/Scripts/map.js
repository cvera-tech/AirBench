// Aliases
const Feature = ol.Feature;
const OSM = ol.source.OSM;
const Point = ol.geom.Point;
const TileLayer = ol.layer.Tile;
const VectorLayer = ol.layer.Vector;
const VectorSource = ol.source.Vector;

// Initial parameters
const initCenter = [0, 0];
const initZoom = 2;
const mapId = 'map';

// The array of features to render on the vector layer
const iconFeatures = [
    new Feature({
        geometry: new Point([0, 0]),
        name: 'Null Island'
    })
];

// The layer with the map tiles to use
const rasterLayer = new TileLayer({
    source: new OSM()
});

// The layer with the points on the map to render
const vectorLayer = new VectorLayer({
    source: new VectorSource({
        features: iconFeatures
    })
});

const map = new ol.Map({
    layers: [rasterLayer, vectorLayer],
    target: mapId,
    view: new ol.View({
        center: initCenter,
        zoom: initZoom
    })
});