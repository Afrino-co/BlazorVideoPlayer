# BlazorVideoPlayer
A suitable and customisable video player for Blazor WebAssembly.Based on plyr.io, With capabilities such as Fullscreen, Shortcuts, Picture-in-Picture, Playsinline,Speed controls,Multiple captions,Responsive and ...

[![Image of Plyr](https://user-images.githubusercontent.com/65253484/115996747-d4299e80-a5f5-11eb-97c6-23e268a31b0d.png)](https://www.nuget.org/packages/BlazorVideoPlayer)


# Install
Install this package in client_side project packages with:
```
Install-Package BlazorVideoPlayer -Version x.x
``` 
x.x is version of package for use last version see https://www.nuget.org/packages/BlazorVideoPlayer

# How to use
add css and js files in client_side _Host.cshml or index.html

Between head tag:
```
<link rel="stylesheet" href="_content/BlazorVideoPlayer/Plyr.css">
```

Befor closed body tag:
```
<script src="_content/BlazorVideoPlayer/plyr.js"></script>
```

then use:
```
<VideoPlayer.VideoPlayer id="elementId" settings="captions,quality,speed,loop" controls="play-large,restart,rewind,play,fast-forward,progress,current-time,duration,mute,volume,captions,settings,pip,airplay,download,fullscreen" DownloadLink="" Sources="" Poster=""/>
```
in your Components.(Defining an id attribute is mandatory)

### settings
Included: captions,quality,speed,loop

### controls
Included: play-large,restart,rewind,play,fast-forward,progress,current-time,duration,mute,volume,captions,settings,pip,airplay,download,fullscreen

### DownloadLink
your video download link

### Sources
Dictionary<string, string> of your qualities video links

### Poster
your video preview thumbnail

Items are being added, please help us
