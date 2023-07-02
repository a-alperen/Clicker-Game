using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioSource clickSound, musicSound;

    [SerializeField] private Image musicToggleImage;
    [SerializeField] private Image sfxToggleImage;

    [SerializeField] private Sprite[] musicToggleSprites;
    [SerializeField] private Sprite[] sfxToggleSprites;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        musicSound.mute = IntToBool(PlayerPrefs.GetInt("MusicToggle"));
        clickSound.mute = IntToBool(PlayerPrefs.GetInt("SFXToggle"));

        if(musicSound.mute) musicToggleImage.sprite = musicToggleSprites[1];
        if(clickSound.mute) sfxToggleImage.sprite = sfxToggleSprites[1];
        PlayMusic();

    }
    int BoolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }

    bool IntToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }
    public void PlayMusic()
    {
        musicSound.Play();
    }
    public void PlaySFX()
    {
        clickSound.PlayOneShot(clickSound.clip);
    }

    public void ToggleMusic()
    {
        musicSound.mute = !musicSound.mute;
        if(musicSound.mute) musicToggleImage.sprite = musicToggleSprites[1];
        else musicToggleImage.sprite = musicToggleSprites[0];
        PlayerPrefs.SetInt("MusicToggle",BoolToInt(musicSound.mute));
    }
    public void ToggleSFX()
    {
        clickSound.mute = !clickSound.mute;
        if (clickSound.mute) sfxToggleImage.sprite = sfxToggleSprites[1];
        else sfxToggleImage.sprite = sfxToggleSprites[0];
        PlayerPrefs.SetInt("SFXToggle", BoolToInt(clickSound.mute));
    }
    public void MusicVolume(float volume)
    {
        musicSound.volume = volume;
        if (volume == 0) musicToggleImage.sprite = musicToggleSprites[1];
        else musicToggleImage.sprite = musicToggleSprites[0];
        PlayerPrefs.SetFloat("MusicVolume",volume);
    }
    public void SFXVolume(float volume)
    {
        clickSound.volume = volume;
        if (volume == 0) sfxToggleImage.sprite = sfxToggleSprites[1];
        else sfxToggleImage.sprite = sfxToggleSprites[0];
        PlayerPrefs.SetFloat("SFXVolume",volume);
    }
}
