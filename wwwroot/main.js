
export function load(settings, controls, elementId, component) {

    var settingsArray = settings.split(",");
    var controlsArray = controls.split(",");
    const player = new Plyr('#' + elementId, {
        settings: settingsArray,
        controls: controlsArray,

        quality: { default: 576, options: [4320, 2880, 2160, 1440, 1080, 720, 576, 480, 360, 240, 200, 100, 50, 20] }
    });
    player.on('ended', event => {
        component.invokeMethodAsync('onEnded');
    });
    //const players = Array.from(document.querySelectorAll('.js-player')).map(p => new Plyr(p, {
    //    settings: settingsArray,
    //    controls: controlsArray,

    //    quality: { default: 576, options: [4320, 2880, 2160, 1440, 1080, 720, 576, 480, 360, 240,200,100,50,20] }

    //}));
}
