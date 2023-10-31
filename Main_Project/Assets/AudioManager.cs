
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----------AudioSource----------")]
    [SerializeField] private AudioSource MusicSource;
    [SerializeField] private AudioSource SFXSource;

    [Header("----------AudioClip----------")]
    public AudioClip Background;
    public AudioClip PortalIn;
    public AudioClip PortalOut;
    public AudioClip ButtonClick;
    public AudioClip Collection_Items;

    private void Start()
    {
        MusicSource.clip= Background;
        MusicSource.loop = true;
        MusicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
