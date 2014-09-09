(function () {
    'use strict';
    // Uncomment the following line to enable first chance exceptions.
    // Debug.enableFirstChanceException(true);

    WinJS.Application.onmainwindowactivated = function (e) {
        if (e.detail.kind === Windows.ApplicationModel.Activation.ActivationKind.launch) {
            var captureDialog = Windows.Media.Capture.CameraCaptureUI();
            captureDialog.captureFileAsync(Windows.Media.Capture.CameraCaptureUIMode.photo).then();
        }
    }
    WinJS.Application.start();

    

})();