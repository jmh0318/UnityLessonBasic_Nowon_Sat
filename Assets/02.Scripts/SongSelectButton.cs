using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class SongSelectButton : MonoBehaviour
{
    public string clipName;
    public void OnClick()
    {
        SongSelector.instance.LoadSongData(clipName);
    }
}
