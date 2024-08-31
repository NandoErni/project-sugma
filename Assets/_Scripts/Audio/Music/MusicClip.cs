using UnityEngine;
using System.Collections;

[CreateAssetMenu]
public class MusicClip : ScriptableObject
{
	public MusicClipType ClipType;

	public AudioClip AudioClip;
}

