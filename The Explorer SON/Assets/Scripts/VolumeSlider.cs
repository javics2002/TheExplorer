using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private enum VolumeType { MASTER, MUSIC, AMBIENCE, SFX, DIALOGUES};

    [Header("Type")]
    [SerializeField] private VolumeType volumeType;

    private Slider volumeSlider;

    private void Start()
    {
        volumeSlider = GetComponent<Slider>();
    }

    private void Update()
    {
        switch (volumeType)
        {
            case VolumeType.MASTER:
                volumeSlider.value = GameManager.Instance.audioManager.masterVolume;
                break;
            case VolumeType.MUSIC:
                volumeSlider.value = GameManager.Instance.audioManager.musicVolume;
                break;
            case VolumeType.AMBIENCE:
                volumeSlider.value = GameManager.Instance.audioManager.ambienceVolume;
                break;
            case VolumeType.SFX:
                volumeSlider.value = GameManager.Instance.audioManager.sfxVolume;
                break;
            case VolumeType.DIALOGUES:
                volumeSlider.value = GameManager.Instance.audioManager.dialogueVolume;
                break;
        }
    }

    public void OnSliderValueChanged()
    {
        switch (volumeType)
        {
            case VolumeType.MASTER:
                GameManager.Instance.audioManager.masterVolume = volumeSlider.value;
                break;
            case VolumeType.MUSIC:
                GameManager.Instance.audioManager.musicVolume = volumeSlider.value;
                break;
            case VolumeType.AMBIENCE:
                GameManager.Instance.audioManager.ambienceVolume = volumeSlider.value;
                break;
            case VolumeType.SFX:
                GameManager.Instance.audioManager.sfxVolume = volumeSlider.value;
                break;
            case VolumeType.DIALOGUES:
                GameManager.Instance.audioManager.dialogueVolume = volumeSlider.value;
                break;
        }
    }
}
