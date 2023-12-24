# BlazorVideoPlayer
A suitable and customisable video player for Blazor WebAssembly.Based on plyr.io, With capabilities such as Fullscreen, Shortcuts, Picture-in-Picture, Playsinline,Speed controls,Multiple captions,Responsive and ...

[![Image of Plyr](https://user-images.githubusercontent.com/65253484/115996747-d4299e80-a5f5-11eb-97c6-23e268a31b0d.png)](https://www.nuget.org/packages/BlazorVideoPlayer)


# Install the package
Find the package through NuGet Package Manager or install it with following command.
```
Install-Package BlazorVideoPlayer -Version x.x
```
```
dotnet add package BlazorVideoPlayer
``` 
x.x is version of package for use last version see https://www.nuget.org/packages/BlazorVideoPlayer

# Add Imports
After the package is added, you need to add the following in your _Imports.razor
```
@using BlazorVideoPlayer
```

# Register Services
Add the following in Program.cs
```
builder.Services.AddVideoPlayerServices();
```

# How To Use
Be sure to use a unique ID
```
<div style="width:700px;">
    <Player id="advanced"
            CurrentTimeControl="true"
            DownloadControl="true"
            DurationControl="true"
            FastForwardControl="true"
            FullscreenControl="true"
            PIPControl="true"
            VolumeControl="true"
            MuteControl="true"
            SettingsControl="true"
            RewindControl="true"
            RestartControl="true"
            ProgressControl="true"
            PlayControl="true"
            CaptionsControl="true"
            AirplayControl="true"
            PlayLargeControl="true"
            Captions="true"
            Loop="true"
            Quality="true"
            Speed="true"
            Poster="poster.png"
            Sources="@sources"
            OnEndedVideo="OnEndedVideo"
            OnPlayVideo="OnPlayVideo"
            OnVideoTimeUpdate="@((e) => OnVideoTimeUpdate(e.currentTime,e.duration))" />
</div>
@code{
    private List<Source> sources = new()
    {
        new()
        {
            Src = "/path/to/video.mp4",
            Type = "video/mp4"
        }
    };
    private void OnEndedVideo()
    {
        Console.WriteLine("End of play");
    }
    private void OnPlayVideo()
    {
        Console.WriteLine("Start playing");
    }
    private void OnVideoTimeUpdate(float currentTime, float duration)
    {
        Console.WriteLine("Current Time: " + currentTime);
        Console.WriteLine("Duration: " + duration);
    }
}
```
