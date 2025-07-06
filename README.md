# museScrobbler

last.fm scrobbling functionality implemented into PeroPeroGames' hit game Muse Dash!

## Setup

1. Download from the [latest release](https://github.com/lawrencfgsdfg/museScrobbler/releases).
2. Extract the zip into your `..\Muse Dash` folder.
3. On initial run, the file `..\Muse Dash\UserData\lastfmConfig.json` will be created. Put the appropriate details in this file.
4. Re-open the game, and an authorization page should open in your browser. Click "Allow Access".
5. Hopefully, you are now scrobbling in Muse Dash!

## lastfmConfig.json
You will need a [last.fm API account](https://www.last.fm/api/account/create). Copy the relevant details to this config file.
|Setting|Description|
|---|---|
|apiKey|Application API Key|
|apiSecret|Application Shared Secret|


## Developer Comments

Thanks to [kapral](https://github.com/kapral) for his [fork](https://github.com/kapral/lastfm/tree/next) of the [Inflatable .NET last.fm library](https://github.com/inflatablefriends/lastfm).
___

I have referenced the following projects extensively through development of this mod:

[MuseDashMirror](https://github.com/MDMods/MuseDashMirror), [MuseDashInfoPlus](https://github.com/MDMods/MuseDashInfoPlus/tree/main), [OsuLastfmScrobbler](https://github.com/iMyon/OsuLastfmScrobbler/tree/master)

Thank you to the developers of these projects for helping me learn.

This is not only my first Muse Dash mod, but also my first C# project entirely. I don't think things look terrible, but they certainly aren't perfect. If you have questions, feedback, etc, please do not hesitate to open an [issue](https://github.com/lawrencfgsdfg/museScrobbler/issues) or [pull request](https://github.com/lawrencfgsdfg/museScrobbler/pulls).

Thank you! ^^
