(function () {
    'use strict';
    // Uncomment the following line to enable first chance exceptions.
    // Debug.enableFirstChanceException(true);

    function onActivated() {
        document.getElementById("status").textContent = "Downloading";
        WinJS.xhr({ url: "http://blogs.msdn.com?format=xml" })
                 .then(onDownloaded, onDownloadError);
        WinJS.UI.processAll();
    }
    
    function onDownloaded(xhr) {
        document.getElementById("status").textContent = "";
        var items = xhr.responseXML.selectNodes("//item");        
        var posts = document.getElementById("posts");
        var template = WinJS.UI.getControl(document.getElementById("postTemplate"));

        var data = [];
        for (var i = 0, len = items.length; i < len; i++) {
            var item = items[i];
            var post = {
                postTitle: item.selectSingleNode("title").text,
                postDate: item.selectSingleNode("pubDate").text
            };
            data.push(post);            
        }
        WinJS.UI.getControl(posts).dataSource = data;
    }

    function onDownloadError() {
        document.getElementById("status").textContent = "Error";
    }

    WinJS.Application.addEventListener("activated", onActivated);
    WinJS.Application.start();
})();