using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider slider;
    Resolution[] resolutions;
    public TMP_Dropdown resolutionsDropdown, qualityDropdown;
    public SceneFader sceneFader;
    public string MainScene = "MainMenu";
    
    void Start(){
        resolutions = Screen.resolutions;
        resolutionsDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width+" x "+resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width &&
               resolutions[i].height == Screen.currentResolution.height)
               {
                    currentResolutionIndex = i;
               }
        }
        resolutionsDropdown.AddOptions(options);
        resolutionsDropdown.value = currentResolutionIndex;
        resolutionsDropdown.RefreshShownValue();
        setResolution(currentResolutionIndex);
        setQuality(0);
        Debug.Log("resolution: "+currentResolutionIndex);
        //Sound
        Load();
    }
    void Update(){
        
    }
    public void setVolume(float volume){
        audioMixer.SetFloat("volume", volume);
        Save();
        
    }
    public float GetMasterLevel(){
		float value;
		bool result =  audioMixer.GetFloat("volume", out value);
		if(result){
			return value;
		}else{
			return 0f;
		}
	}
    private void Save(){
        PlayerPrefs.SetFloat("volume", GetMasterLevel());
    }

    private void Load(){
        float value = PlayerPrefs.GetFloat("volume");
        audioMixer.SetFloat("volume",PlayerPrefs.GetFloat("volume"));
        slider.SetValueWithoutNotify(value);
        
    }
    public void setQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);

    }
    public void setFullScreen(bool isFullScreen){
        Screen.fullScreen = isFullScreen;
    }
    public void setResolution(int resolutionIndex){
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        
    }

    public void onBtnBack(){
        sceneFader.FadeToScene(MainScene);
        Save();
    }
}
