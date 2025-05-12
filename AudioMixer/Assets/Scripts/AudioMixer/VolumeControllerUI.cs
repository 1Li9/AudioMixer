using System;
using UnityEngine;

public class VolumeControllerUI : MonoBehaviour
{
    public event Action<float> OnVolumeChanged;

    public void UpdateVolume(float volume) =>
        OnVolumeChanged?.Invoke(volume);
}
