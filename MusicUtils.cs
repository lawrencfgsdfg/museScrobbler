using System;
using Il2CppAssets.Scripts.Database;

public class MusicUtils
{
    public static MusicInfo MusicInfo => GlobalDataBase.s_DbBattleStage.selectedMusicInfo;
    public static string MusicName => GlobalDataBase.s_DbBattleStage.selectedMusicName;
    public static string MusicAuthor => MusicInfo.author;

}
