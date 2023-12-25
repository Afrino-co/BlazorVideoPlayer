using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using BlazorVideoPlayer.Test;
using BlazorVideoPlayer.Test.Shared;
using BlazorVideoPlayer;

namespace BlazorVideoPlayer.Test.Pages;

public partial class Advanced
{
    private List<Source> sources = new()
    {
        new()
        {
            Src = "/sample.mp4",
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