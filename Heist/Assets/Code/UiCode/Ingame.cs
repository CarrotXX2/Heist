using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InGameSettings : MonoBehaviour
{
    public GameObject mainMenu2;
    public TMPro.TMP_Text Credits2;
    public TMP_Text volumeText2;
    public Slider volumeSlider2;
    Resolution[] resolutions2;
    public TMP_Dropdown resolutionDropdownList2;

    // Start is called before the first frame update
    void Start()
    {
        resolutions2 = Screen.resolutions;
        Credits2.enabled = false;
        resolutionDropdownList2.ClearOptions();
        List<string> options = new List<string>();

        int currentresolutionsindex = 0;
        for (int i = 0; i < resolutions2.Length; i++)
        {
            string option = resolutions2[i].width + "x" + resolutions2[i].height;
            options.Add(option);

            if (resolutions2[i].width == Screen.currentResolution.width &&
                resolutions2[i].height == Screen.currentResolution.height)
            {
                currentresolutionsindex = i;
            }
        }
        resolutionDropdownList2.AddOptions(options);
        resolutionDropdownList2.value = currentresolutionsindex;
        resolutionDropdownList2.RefreshShownValue();
    }

    // Update is called once per frame
    void Update()
    {
        volumeSlider2.onValueChanged.AddListener(OnVolumeChanged);

        UpdateVolumeText(volumeSlider2.value);
    }
    public void OnVolumeChanged(float value)
    {
        UpdateVolumeText(value);

        AudioListener.volume = value;
    }

    public void UpdateVolumeText(float value)
    {
        volumeText2.text = $"Volume: {Mathf.RoundToInt(value * 100)}%";
    }
    public void change()
    {
        Screen.fullScreen = !Screen.fullScreen;
        print("screen changed");
    }
    public void setresolution(int resolutionindex)

    {
        Resolution resolution = resolutions2[resolutionindex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
