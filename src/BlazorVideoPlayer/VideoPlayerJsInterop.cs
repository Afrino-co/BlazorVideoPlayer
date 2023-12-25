using Microsoft.JSInterop;

namespace BlazorVideoPlayer;
// This class provides an example of how JavaScript functionality can be wrapped
// in a .NET class for easy consumption. The associated JavaScript module is
// loaded on demand when first needed.
//
// This class can be registered as scoped DI service and then injected into Blazor
// components for use.
public interface IVideoPlayerJsInterop
{
    Task Initialize(string id, DotNetObjectReference<Player> objectRef,
            bool captions,
            bool quality,
            bool speed,
            bool loop,
            bool playLargeControl,
            bool restartControl,
            bool rewindControl,
            bool playControl,
            bool fastForwardControl,
            bool progressControl,
            bool currentTimeControl,
            bool durationControl,
            bool muteControl,
            bool volumeControl,
            bool captionsControl,
            bool settingsControl,
            bool pIPControl,
            bool airplayControl,
            bool downloadControl,
            bool fullscreenControl);
}

public class VideoPlayerJsInterop : IAsyncDisposable, IVideoPlayerJsInterop
{
    private readonly Lazy<Task<IJSObjectReference>> moduleTask;
    private readonly Lazy<Task<IJSObjectReference>> mainTask;
    public VideoPlayerJsInterop(IJSRuntime jsRuntime)
    {
        moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/BlazorVideoPlayer/plyr.js").AsTask());

        mainTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/BlazorVideoPlayer/main.js").AsTask());
    }

    public async ValueTask DisposeAsync()
    {
        if (moduleTask.IsValueCreated)
        {
            var module = await moduleTask.Value;
            await module.DisposeAsync();
        }
    }

    public async Task Initialize(string id, DotNetObjectReference<Player> objectRef, bool captions, bool quality, bool speed, bool loop, bool playLargeControl, bool restartControl, bool rewindControl, bool playControl, bool fastForwardControl, bool progressControl, bool currentTimeControl, bool durationControl, bool muteControl, bool volumeControl, bool captionsControl, bool settingsControl, bool pIPControl, bool airplayControl, bool downloadControl, bool fullscreenControl)
    {
        await moduleTask.Value;
        await (await mainTask.Value).InvokeVoidAsync("videoInitialize", id, objectRef,
            captions,
            quality,
            speed,
            loop,
            playLargeControl,
            restartControl,
            rewindControl,
            playControl,
            fastForwardControl,
            progressControl,
            currentTimeControl,
            durationControl,
            muteControl,
            volumeControl,
            captionsControl,
            settingsControl,
            pIPControl,
            airplayControl,
            downloadControl,
            fullscreenControl
            );
    }
}
