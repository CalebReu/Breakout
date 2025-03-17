using UnityEngine;

public class AudioManager : SingletonMonoBehavior<AudioManager>
{
    [Header("Audio Sources")] // headers get added to the inspector (for readability)

    public AudioSource sfxSource;
    public AudioSource bkgMusicSource;

    [Header("Audio Clips")]

    public AudioClip bkgMusicClip; // background music
    public AudioClip blockBreakClip; // ball collides w block
    public AudioClip wallClip; // ball collides w wall
    public AudioClip paddleClip; // ball collides w paddle
    public AudioClip levelCompleteClip; // last block in level destroyed/transition to next level
    public AudioClip buttonClip; // main menu button click

    void Start()
    {
        playBackgroundMusic();
    }

    private void playBackgroundMusic()
    {
        if (bkgMusicClip != null && bkgMusicSource != null)
        {
            bkgMusicSource.clip = bkgMusicClip;
            bkgMusicSource.loop = true;
            bkgMusicSource.Play();
        }
    }

    // generic method to play any sound effect you like using this AudioManager
    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
}
