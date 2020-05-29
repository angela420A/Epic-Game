var iframe = document.getElementsByTagName("iframe");
for (let i = 0; i < iframe.length; i++) {
    var div = document.getElementsByTagName("iframe")[i].parentNode;
    div.className = "iframeclass";
}