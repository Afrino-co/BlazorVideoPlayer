
export function videoInitialize(elementId, component,
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
    fullscreenControl) {

    var settingsArray = new Array();
    if (captions)
        settingsArray.push("captions");
    if (quality)
        settingsArray.push("quality");
    if (speed)
        settingsArray.push("speed");
    if (loop)
        settingsArray.push("loop");

    var controlsArray = new Array();
    if (playLargeControl)
        controlsArray.push("play-large");
    if (restartControl)
        controlsArray.push("restart");
    if (rewindControl)
        controlsArray.push("rewind");
    if (playControl)
        controlsArray.push("play");
    if (fastForwardControl)
        controlsArray.push("fast-forward");
    if (progressControl)
        controlsArray.push("progress");
    if (currentTimeControl)
        controlsArray.push("current-time");
    if (durationControl)
        controlsArray.push("duration");
    if (muteControl)
        controlsArray.push("mute");
    if (volumeControl)
        controlsArray.push("volume");
    if (captionsControl)
        controlsArray.push("captions");
    if (settingsControl)
        controlsArray.push("settings");
    if (pIPControl)
        controlsArray.push("pip");
    if (airplayControl)
        controlsArray.push("airplay");
    if (downloadControl)
        controlsArray.push("download");
    if (fullscreenControl)
        controlsArray.push("fullscreen");
    
    const player = new Plyr('#' + elementId, {
        settings: settingsArray,
        controls: controlsArray,

        quality: { default: 576, options: [4320, 2880, 2160, 1440, 1080, 720, 576, 480, 360, 240, 200, 100, 50, 20] }
    });
    player.on('ended', async event => {
        await component.invokeMethodAsync('OnEnded');
    });
    player.on('timeupdate', async event => {
        await component.invokeMethodAsync('OnTimeUpdate', player.currentTime, player.duration);
    });

    player.on('play', async event => {
        await component.invokeMethodAsync('OnPlay');
    });
    
}
