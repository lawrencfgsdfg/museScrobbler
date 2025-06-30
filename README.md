
# museScrobbler

last.fm scrobbling functionality implemented into PeroPeroGames' hit game Muse Dash!

## Setup

1. Download files from the [latest release](https://github.com/lawrencfgsdfg/museScrobbler/releases).
2. Place `museScrobbler.dll` into your `..\Muse Dash\Mods` folder.
3. Place `IF.Lastfm.Core.dll` into your `..\Muse Dash\Plugins` folder.
4. On initial run, the file `..\Muse Dash\UserData\lastfmConfig.ini` will be created.
Put the appropriate details in this file, and re-open the game.

## lastfmConfig.ini
You will need a [last.fm API account](https://www.last.fm/api/account/create), in addition to a normal last.fm user account.
|Setting|Description|
|---|---|
|apiKey|Application API Key|
|apiSecret|Application Shared Secret|
|username|last.fm account username|
|password|last.fm account password|


## Developer Comments
I have referenced the following projects extensively through development of this mod:

[MuseDashMirror](https://github.com/MDMods/MuseDashMirror), [MuseDashInfoPlus](https://github.com/MDMods/MuseDashInfoPlus/tree/main), [OsuLastfmScrobbler](https://github.com/iMyon/OsuLastfmScrobbler/tree/master), [lastfm .NET library](https://github.com/inflatablefriends/lastfm)

Thank you to the developers of these projects for helping me learn.

This is not only my first Muse Dash mod, but also my first C# project entirely (and my first time writing a meaningful README!). I don't think things look terrible, but they certainly aren't perfect. If you have questions, feedback, etc, please feel free to open an [issue](https://github.com/lawrencfgsdfg/museScrobbler/issues) or [pull request](https://github.com/lawrencfgsdfg/museScrobbler/pulls).

Thank you! ^^
