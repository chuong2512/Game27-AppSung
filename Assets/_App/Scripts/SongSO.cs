using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class SongInfor
{
    public AudioClip song;
    public string name;
    public Sprite icon;
}

[CreateAssetMenu(fileName = "Songs ", menuName = "Data/Scriptable Object/Song Infor SO")]
public class SongSO : ScriptableObject
{
    public List<SongInfor> songInfors;

    public SongInfor GetSongWithID(int id)
    {
        /////////////////////////////////////////////////////////////////////////
        return songInfors[id];
    }
}