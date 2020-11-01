const container = "editor";
const containerElem = document.getElementById(container);

// first we need to create a stage
const stage = new Konva.Stage({ container, width: 400, height: 300 });

// then create layer
const layer = new Konva.Layer();

const buildings = [];

function putBuilding(id) {
  console.log(`Sending building ${id} data to back end`);
  const r = buildings[id];
  const body = JSON.stringify({
    x: r.absolutePosition().x,
    y: r.absolutePosition().y,
    width: r.width(),
    height: r.height(),
    scaleX: r.scaleX(),
    scaleY: r.scaleY(),
    rotation: r.rotation(),
  });
  fetch(`/BlockEditor/Building?buildingId=${id}`, {
    method: "PUT",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
    body,
  }).then((_) => {
    r.lock = false;
    console.log(`Unlocked building ${id}`);
  });
}

function updateBuildings() {
  fetch("/BlockEditor/Buildings?blockId=1")
    .then((res) => res.json())
    .then((data) => {
      for (const r of tr.nodes()) {
        r.lock = true;
      }
      for (const building of data) {
        let r = null;
        if (!(building.id in buildings)) {
          r = new Konva.Rect({
            x: 0,
            y: 0,
            width: 100,
            height: 100,
            fill: "gray",
            stroke: "black",
            strokeWidth: 1,
            draggable: true,
          });
          r.id = building.id;
          r.lock = false;
          r.on("dragmove", () => (r.lock = true));
          r.on("dragend", () => putBuilding(building.id));
          layer.add(r);
          buildings[building.id] = r;
        }
        r = buildings[building.id];
        if (r.lock) {
          continue;
        }

        const v = building.vertices;
        r.absolutePosition({ x: v.x, y: v.y });

        r.width(v.width);
        r.height(v.height);

        r.scaleX(v.scaleX);
        r.scaleY(v.scaleY);

        r.rotation(v.rotation);

        layer.draw();
      }
    });
}

updateBuildings();

const UPDATE_INTERVAL_MS = 500;
setInterval(updateBuildings, UPDATE_INTERVAL_MS);

const tr = new Konva.Transformer();
layer.add(tr);

// by default select nothing
tr.nodes([]);

// add the layer to the stage
stage.add(layer);

stage.on("click tap", function (e) {
  // if click on empty area - remove all selections
  if (e.target === stage) {
    const previous = tr.nodes();
    if (previous.length > 0) {
      putBuilding(previous[0].id);
    }
    tr.nodes([]);
    layer.draw();
    return;
  }

  const isSelected = tr.nodes().indexOf(e.target) >= 0;

  if (!isSelected) {
    // if no key pressed and the node is not selected
    // select just one
    tr.nodes([e.target]);
    e.target.lock = true;
    console.log(`Locked building ${e.target.id}`);
  }

  layer.draw();
});

// draw the image
layer.draw();

function resizeStage() {
  stage.width(containerElem.clientWidth);
  stage.height(containerElem.clientHeight);
}
resizeStage();
window.addEventListener("resize", resizeStage);

function open3DModel() {
  const active = tr.nodes();
  if (active.length > 0) {
    const buildingId = active[0].id;
    location.href = `/Building/${buildingId}`;
  }
}

function downloadDocument() {
  const active = tr.nodes();
  if (active.length > 0) {
    const buildingId = active[0].id;
    location.href = `/DocumentGenerator?buildingId=${buildingId}`;
  }
}
