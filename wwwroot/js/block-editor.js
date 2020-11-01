const container = "editor";
const containerElem = document.getElementById(container);

// first we need to create a stage
const stage = new Konva.Stage({ container, width: 400, height: 300 });

// then create layer
const layer = new Konva.Layer();

const rect1 = new Konva.Rect({
  x: 20,
  y: 20,
  width: 200,
  height: 100,
  fill: "gray",
  stroke: "black",
  strokeWidth: 1,
  draggable: true,
});

const rect2 = new Konva.Rect({
  x: 20,
  y: 200,
  width: 200,
  height: 100,
  fill: "gray",
  stroke: "black",
  strokeWidth: 1,
  draggable: true,
});

// add the shape to the layer
layer.add(rect1);
layer.add(rect2);

const tr = new Konva.Transformer();
layer.add(tr);

// by default select nothing
tr.nodes([]);

// add the layer to the stage
stage.add(layer);

stage.on("click tap", function (e) {
  // if click on empty area - remove all selections
  if (e.target === stage) {
    tr.nodes([]);
    layer.draw();
    return;
  }

  const isSelected = tr.nodes().indexOf(e.target) >= 0;

  if (!isSelected) {
    // if no key pressed and the node is not selected
    // select just one
    tr.nodes([e.target]);
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
