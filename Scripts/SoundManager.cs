using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    GameData gameData;
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource hitSFX;
    [SerializeField] private AudioSource buttonSFX;
    [SerializeField] private List<AudioClip> hitSounds;

    public Slider musicSlider;
    public Slider sfxSlider;
    private void Start()
    {
        Events.chestDamaged += PlayHitSFX;
        Events.chestChanged += ChangeHitSFX;
        Events.slimeDroped += PlayDropSFX;
        gameData = SaveSystem.Instance.gameData;
        music.volume = gameData.musicVolume;
        hitSFX.volume = gameData.sfxVolume;
        buttonSFX.volume = gameData.sfxVolume;
        musicSlider.value = gameData.musicVolume;
        sfxSlider.value = gameData.sfxVolume;
        
    } 
    void ChangeHitSFX()
    {
        int rand = Random.Range(0, hitSounds.Count);
        hitSFX.clip = hitSounds[rand];
       
    }
    void PlayHitSFX() 
    {
        hitSFX.pitch = Random.Range(0.9f, 1.1f);   
        hitSFX.Play();
        
    }
    void PlayDropSFX(Slime slime) 
    {
        if (slime != null) { }
    }
    private void OnDisable()
    {
        Events.chestDamaged -= PlayHitSFX;
        Events.chestChanged -= ChangeHitSFX;
        Events.slimeDroped -= PlayDropSFX;
    }
    public void OnMusicVolumeChange() 
    {
        music.volume = musicSlider.value;
        gameData.musicVolume = music.volume;
    }
    public void OnSFXVolumeChange()
    {
        hitSFX.volume = sfxSlider.value;
        buttonSFX.volume = sfxSlider.value;
        gameData.sfxVolume = hitSFX.volume;

        PlayHitSFX();
    }
}
