using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(MusicLibrary))]
public class MusicController : MonoBehaviour
{

    public static MusicController Instance;

    private MusicLibrary _library;

    private AudioSource _audioSource;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        } else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            _audioSource = GetComponent<AudioSource>();
            _library = GetComponent<MusicLibrary>();
        }
    }

    public void PlayMusic(MusicClipType clipType)
    {
        var audioClip = _library.MusicClipDict[clipType];

        _audioSource.clip = audioClip;
        _audioSource.Play();
        _audioSource.loop = true;
    }
}
