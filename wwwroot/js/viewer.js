function createViewer(accessToken, element, urnId) {
  let viewer;
  const options = {
    env: "AutodeskProduction",
    accessToken,
    api: "derivativeV2",
  };

  Autodesk.Viewing.Initializer(options, () => {
    // Create and start the viewer in that element
    viewer = new Autodesk.Viewing.GuiViewer3D(element);
    viewer.start();

    const documentId = `urn:${urnId}`;
    Autodesk.Viewing.Document.load(
      documentId,
      onDocumentLoadSuccess,
      onDocumentLoadFailure
    );
  });

  /**
   * Autodesk.Viewing.Document.load() success callback.
   * Proceeds with model initialization.
   */
  function onDocumentLoadSuccess(doc) {
    // Load the default viewable geometry into the viewer.
    // Using the doc, we have access to the root BubbleNode,
    // which references the root node of a graph that wraps each object from the Manifest JSON.
    var viewable = doc.getRoot().getDefaultGeometry();
    if (viewable) {
      viewer
        .loadDocumentNode(doc, viewable)
        .then((result) => {
          console.log("Viewable Loaded!");
        })
        .catch((err) => {
          console.log("Viewable failed to load.");
          console.log(err);
        });
    }
  }

  /**
   * Autodesk.Viewing.Document.load() failure callback.
   */
  function onDocumentLoadFailure(viewerErrorCode) {
    console.error("onDocumentLoadFailure() - errorCode: " + viewerErrorCode);
  }
}
