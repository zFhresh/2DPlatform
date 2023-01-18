using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingsScript : MonoBehaviour
{
    [SerializeField]TMP_Dropdown Dropdown;
    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;
    private float CurrentRefreshRate;
    private int currentResolutionIndex = 0;
    void Start()
    {
        ScanResulations();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HideSettings() {
        this.gameObject.SetActive(false);
    }





    void ScanResulations() {
        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();

        Dropdown.ClearOptions();
        CurrentRefreshRate = Screen.currentResolution.refreshRate;
        for (int i = 0; i < resolutions.Length; i++) {
            if(resolutions[i].refreshRate == CurrentRefreshRate) {
                filteredResolutions.Add(resolutions[i]);
            }
        }
        List<string> options = new List<string>();
        for (int i = 0; i < filteredResolutions.Count; i++) {
            string resolutionOption = filteredResolutions[i].width + "x" + filteredResolutions[i].height + " " + filteredResolutions[i].refreshRate + "Hz";
            options.Add(resolutionOption);
            if(filteredResolutions[i].width == Screen.width && filteredResolutions[i].height == Screen.height) {
                currentResolutionIndex = i;
            }
        }

        Dropdown.AddOptions(options);
        Dropdown.value = currentResolutionIndex;
        Dropdown.RefreshShownValue();
        SetResolution(options.Count - 1);
    }
    public void SetResolution(int resolutionIndex) {
        Resolution resolution = filteredResolutions[resolutionIndex];
        if(resolution.height < 700) {
            this.transform.parent.GetComponent<MenuScript>().ShowError();
            return;
        }
        Screen.SetResolution(resolution.width,resolution.height,true);
    }
}
