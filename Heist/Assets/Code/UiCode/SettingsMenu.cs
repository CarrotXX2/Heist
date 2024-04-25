using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public TMPro.TMP_Text Credits;
    public TMP_Text volumeText;
    public Slider volumeSlider;
    Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdownList;
    public Canvas settings;
    public Canvas main;

    // Start is called before the first frame update
    void Start()
    {
        settings.enabled = false;
        resolutions = Screen.resolutions;
        Credits.enabled = false;
        resolutionDropdownList.ClearOptions();
        List<string> options = new List<string>();

        int currentresolutionsindex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentresolutionsindex = i;
            }
        }
        resolutionDropdownList.AddOptions(options);
        resolutionDropdownList.value = currentresolutionsindex;
        resolutionDropdownList.RefreshShownValue();
    }

    // Update is called once per frame
    void Update()
    {
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);

        UpdateVolumeText(volumeSlider.value);
    }
    public void SetClick()
    {
        mainMenu.SetActive(true);
        Credits.enabled = false;
    }
    public void credClick()
    {
        mainMenu.SetActive(false);
        Credits.enabled = true;
    }
    public void OnVolumeChanged(float value)
    {
        UpdateVolumeText(value);

        AudioListener.volume = value;
    }

    public void UpdateVolumeText(float value)
    {
        volumeText.text = $"Volume: {Mathf.RoundToInt(value * 100)}%";
    }
    public void change()
    {
        Screen.fullScreen = !Screen.fullScreen;
        print("screen changed");
    }
    public void setresolution(int resolutionindex)

    {
        Resolution resolution = resolutions[resolutionindex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void back()
    {
        settings.enabled = false;
        main.enabled = true;
    }
}
