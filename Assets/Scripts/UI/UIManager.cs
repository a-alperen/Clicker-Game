using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider musicSlider, sfxSlider;

    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }
    public void ToggleMusic()
    {
        SoundManager.Instance.ToggleMusic();
    }
    public void ToggleSFX()
    {
        SoundManager.Instance.ToggleSFX();
    }
    public void MusicVolume()
    {
        SoundManager.Instance.MusicVolume(musicSlider.value);
    }
    public void SFXVolume()
    {
        SoundManager.Instance.SFXVolume(sfxSlider.value);
    }
}
