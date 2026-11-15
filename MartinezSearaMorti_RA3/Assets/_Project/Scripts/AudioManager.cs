
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource musicSource, sfxSource;
    [SerializeField] private AudioClip gravityClip, hurtClip, doorClip, backgroundMusic;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        GameEvents.OnGravityChange += PlayGravity;
        GameEvents.OnTakeDamage += PlayHurt;
        GameEvents.OnOpeningDoor += PlayDoor;
        GameEvents.OnGameOver += StopMusic;
        GameEvents.OnGameStart += PlayMusic;
        GameEvents.OnGameWin += StopMusic;
    }
    private void OnDisable()
    {
        GameEvents.OnGravityChange -= PlayGravity;
        GameEvents.OnTakeDamage -= PlayHurt;
        GameEvents.OnOpeningDoor -= PlayDoor;
        GameEvents.OnGameOver -= StopMusic;
        GameEvents.OnGameStart -= PlayMusic;
        GameEvents.OnGameWin -= StopMusic;
    }
    public void PlayHurt()
    {
        sfxSource.PlayOneShot(hurtClip);
    }
    public void PlayDoor()
    {
        sfxSource.PlayOneShot(doorClip);
    }
    public void PlayGravity()
    {
        sfxSource.PlayOneShot(gravityClip);
    }
    public void PlayMusic()
    {
        Debug.Log("MUSIC");
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}
