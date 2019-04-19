using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class SoundInfo
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 1;

    public string instrument;

    public int keyNumber;

    public bool loop;
    
    [HideInInspector]
    public AudioSource source;
}
