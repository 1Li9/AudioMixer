using System;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(VolumeControllerUI))]
public class VolumeController : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private AudioMixerParams _parameter;

    private VolumeControllerUI _volumeControllerUI;

    private float _minVolume;
    private float _maxVolume;

    private void Awake() =>
        _volumeControllerUI= GetComponent<VolumeControllerUI>();

    private void Start()
    {
        if (_mixer.GetFloat(_parameter.ToString(), out _maxVolume) == false)
            throw new ArgumentNullException(_parameter.ToString());

        _minVolume = _maxVolume - 80f;
    }

    private void OnEnable() =>
        _volumeControllerUI.OnVolumeChanged += ChangeVolume;

    private void OnDisable() =>
        _volumeControllerUI.OnVolumeChanged -= ChangeVolume;

    private void ChangeVolume(float volume)
    {
        float newVolume = _maxVolume + _minVolume - volume * _minVolume;
        _mixer.SetFloat(_parameter.ToString(), newVolume);
    }
}
