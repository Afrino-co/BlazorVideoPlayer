using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace BlazorVideoPlayer;

public partial class Player
{
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> InputAttributes { get; set; }

    [Parameter] public List<Source> Sources { get; set; }
    [Parameter] public List<Track> Tracks { get; set; }
    [Parameter] public string Poster { get; set; }

    [Parameter] public bool Captions { get; set; } = false;
    [Parameter] public bool Quality { get; set; } = false;
    [Parameter] public bool Speed { get; set; } = false;
    [Parameter] public bool Loop { get; set; } = false;



    [Parameter] public bool PlayLargeControl { get; set; } = false;
    [Parameter] public bool RestartControl { get; set; } = false;
    [Parameter] public bool RewindControl { get; set; } = false;
    [Parameter] public bool PlayControl { get; set; } = false;
    [Parameter] public bool FastForwardControl { get; set; } = false;
    [Parameter] public bool ProgressControl { get; set; } = false;
    [Parameter] public bool CurrentTimeControl { get; set; } = false;
    [Parameter] public bool DurationControl { get; set; } = false;
    [Parameter] public bool MuteControl { get; set; } = false;
    [Parameter] public bool VolumeControl { get; set; } = false;
    [Parameter] public bool CaptionsControl { get; set; } = false;
    [Parameter] public bool SettingsControl { get; set; } = false;
    [Parameter] public bool PIPControl { get; set; } = false;
    [Parameter] public bool AirplayControl { get; set; } = false;
    [Parameter] public bool DownloadControl { get; set; } = false;
    [Parameter] public bool FullscreenControl { get; set; } = false;


    [Parameter] public EventCallback OnEndedVideo { get; set; }
    [Parameter] public EventCallback<(float currentTime, float duration)> OnVideoTimeUpdate { get; set; }
    [Parameter] public EventCallback OnPlayVideo { get; set; }


    private DotNetObjectReference<Player> objectRef;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        objectRef = DotNetObjectReference.Create(this);

        if (InputAttributes == null ||
            !InputAttributes.Any(p => p.Key == "id") ||
            InputAttributes.FirstOrDefault(p => p.Key == "id").Value == null ||
           string.IsNullOrWhiteSpace(InputAttributes.FirstOrDefault(p => p.Key == "id").Value.ToString())
            )
        {
            throw new ArgumentNullException("id (HTML) can not be null or empty");
        }

        var elementId = InputAttributes.FirstOrDefault(p => p.Key == "id").Value.ToString();

        await VideoPlayerService.Initialize(elementId!, objectRef,
              Captions,
              Quality,
              Speed,
              Loop,
              PlayLargeControl,
              RestartControl,
              RewindControl,
              PlayControl,
              FastForwardControl,
              ProgressControl,
              CurrentTimeControl,
              DurationControl,
              MuteControl,
              VolumeControl,
              CaptionsControl,
              SettingsControl,
              PIPControl,
              AirplayControl,
              DownloadControl,
              FullscreenControl);
    }


    [JSInvokable]
    public async Task OnEnded()
    {
        await OnEndedVideo.InvokeAsync();
    }

    [JSInvokable]
    public async Task OnTimeUpdate(float currentTime, float duration)
    {
        await OnVideoTimeUpdate.InvokeAsync((currentTime, duration));
    }

    [JSInvokable]
    public async Task OnPlay()
    {
        await OnPlayVideo.InvokeAsync();
    }
}
public class Source
{
    public string Src { get; set; }
    public string Type { get; set; }
}

public class Track
{
    public string Src { get; set; }
    public string Kind { get; set; }
    public string Label { get; set; }
    public string SrcLang { get; set; }
    public bool IsDefault { get; set; }
}