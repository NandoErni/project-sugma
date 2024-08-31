using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SFXLibrary))]
[RequireComponent(typeof(AudioSource))]
public class SFXController : MonoBehaviour
{
    public static SFXController Instance;

    private SFXLibrary _library;

    private AudioSource _audioSource;


    private void Start()
    {
        _library = GetComponent<SFXLibrary>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlaySound(SFXClipType clipType, float volume = 1)
    {
        var clip = _library.GetClip(clipType);
        _audioSource.PlayOneShot(clip, volume);
    }
}
