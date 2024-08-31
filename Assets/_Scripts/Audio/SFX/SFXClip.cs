using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SFXClip : ScriptableObject
{
    public SFXClipType ClipType;

    public AudioClip[] AudioClips;

    public AudioClip GetRandomAudioClip()
    {
        return AudioClips[0];
    }
}
