# BlazorVideoPlayer
A suitable and customisable video player for Blazor WebAssembly.Based on plyr.io, With capabilities such as Fullscreen, Shortcuts, Picture-in-Picture, Playsinline,Speed controls,Multiple captions,Responsive and ...

# Install
Install this package in client_side project packages with:
```
Install-Package BlazorVideoPlayer -Version x.x
``` 
x.x is version of package for use last version see https://www.nuget.org/packages/BlazorVideoPlayer

# How to use
add css and js files in client_side _Host.cshml or index.html
```
<link rel="stylesheet" href="_content/VideoPlayer/Plyr.css">
```
Between head tag


```
<script src="_content/VideoPlayer/plyr.js"></script>
```
Befor closed body tag

then use 
```
<VideoPlayer.VideoPlayer DownloadLink="" Sources="" Poster=""/>
```
in your Components

### DownloadLink
your video download link

### Sources
Dictionary<string, string> of your qualities video links

### Poster
your video preview thumbnail

Items are being added, please help us
