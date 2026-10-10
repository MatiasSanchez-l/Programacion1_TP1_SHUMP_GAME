/**
 * @author Matias
 * @create date 2026-10-10 00:24:13
 * @modify date 2026-10-10 00:24:13
 * @desc música de fondo persistente y efectos de sonido del juego
 */
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioClip music;
    [SerializeField, Range(0f, 1f)] private float musicVolume = 0.4f;
    [SerializeField, Range(0f, 1f)] private float sfxVolume = 0.8f;

    private AudioSource musicSource;
    private AudioSource sfxSource;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.clip = music;
        musicSource.loop = true;
        musicSource.volume = musicVolume;
        musicSource.playOnAwake = false;

        sfxSource = gameObject.AddComponent<AudioSource>();
        sfxSource.playOnAwake = false;

        if (music != null) musicSource.Play();
    }

    void OnDestroy()
    {
        if (instance == this) instance = null;
    }

    public static void Play(AudioClip clip, float volume = 1f)
    {
        if (instance == null || clip == null) return;
        instance.sfxSource.PlayOneShot(clip, volume * instance.sfxVolume);
    }

    public void PauseMusic()
    {
        musicSource.Pause();
    }

    public void ResumeMusic()
    {
        musicSource.UnPause();
    }
}
