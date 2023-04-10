using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioSource audioSource;
    public AudioClip rockMoveSound;
    public AudioClip wonSound;

    public void PlaySound(AudioClip clip, float volume)
    {
        audioSource.PlayOneShot(clip, volume);
    }
}
