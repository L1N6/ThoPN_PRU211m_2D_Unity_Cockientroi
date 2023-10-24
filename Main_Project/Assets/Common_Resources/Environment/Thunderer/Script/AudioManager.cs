using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [Header("Audio clip")]
    [SerializeField] AudioClip hammerImpact;
    [SerializeField] AudioClip run;
    [SerializeField] AudioClip normalAttack;
    [SerializeField] AudioClip SpAttack;
    [SerializeField] AudioClip bullet;
    public void PlaySFX(string clip)
    {
        if (clip.Equals("hammerImpact"))
            SFXSource.PlayOneShot(hammerImpact);
    }
}
