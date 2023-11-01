using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class GameSettings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public string mixerParameterName;
    public UnityEngine.UI.Slider slider;

    public UnityEngine.UI.Toggle fullscreenToggle; // Thêm Toggle cho fullscreen

    private const string FullscreenPrefsKey = "Fullscreen"; // Khóa cho lưu trữ fullscreen

    [System.Obsolete]
    private void Start()
    {
        // Khôi phục giá trị của Slider từ PlayerPrefs khi khởi động
        float savedVolume = PlayerPrefs.GetFloat(mixerParameterName, 1f);
        SetSliderValue(savedVolume);
        // Khôi phục trạng thái của fullscreen từ PlayerPrefs
        bool fullscreenValue = System.Convert.ToBoolean(PlayerPrefs.GetInt(FullscreenPrefsKey));
        SetFullscreen(fullscreenValue);
    }
   
    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat(mixerParameterName, Mathf.Log10(volume) * 20f);

        // Lưu giá trị của Slider vào PlayerPrefs
        PlayerPrefs.SetFloat(mixerParameterName, volume);
    }

    private void SetSliderValue(float value)
    {
        slider.value = value;
    }
    /*// Change quanlity Graphics
    public void SetQuality (int quanlityIndex)
    {
        QualitySettings.SetQualityLevel(quanlityIndex);
    }*/
    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        // Lưu trạng thái fullscreen vào PlayerPrefs
        PlayerPrefs.SetInt(FullscreenPrefsKey, System.Convert.ToInt32(isFullscreen));

        // Cập nhật trạng thái toggle
        UpdateToggleState();
    }
    private void UpdateToggleState()
    {
        fullscreenToggle.isOn = System.Convert.ToBoolean(PlayerPrefs.GetInt(FullscreenPrefsKey));
    }
}
