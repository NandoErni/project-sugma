using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SFXLibrary : MonoBehaviour
{
    [Header("SFX Clips")]
    [SerializeField]
    private List<SFXClip> _sfxClips;

    private Dictionary<SFXClipType, AudioClip[]> _sfxClipDict;

    private void Start()
    {
        _sfxClipDict = _sfxClips.ToDictionary(clip => clip.ClipType, clip => clip.AudioClips);
    }

    public AudioClip GetClip(SFXClipType clipType)
    {
        var clipsOfType = _sfxClipDict[clipType];
        return clipsOfType[Random.Range(0, clipsOfType.Length-1)];
    }
}
