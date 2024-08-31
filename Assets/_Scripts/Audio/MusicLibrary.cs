using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MusicLibrary : MonoBehaviour
{
    [Header("Music Clips")]
    [SerializeField]
    private List<MusicClip> _musicClips;

    public Dictionary<MusicClipType, AudioClip> MusicClipDict;

    private void Start()
    {
        MusicClipDict = _musicClips.ToDictionary(clip => clip.ClipType, clip => clip.AudioClip);
    }
}
