using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsDisplay : MonoBehaviour
{
    public Button exitSettingsBtn;
    public Button settingsBtn;
    public GameObject settingsMenu;
    public GameObject mainMenu;
    public bool settingsMenuActive = false;

    void Start () {
        exitSettingsBtn.onClick.AddListener(TaskOnClick);
        settingsBtn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick(){
        if (settingsMenuActive == false)
        {
            settingsMenu.SetActive(true);
            mainMenu.SetActive(false);
            settingsMenuActive = true;
        }
        else
        {
            settingsMenu.SetActive(false);
            mainMenu.SetActive(true);
            settingsMenuActive = false;
        }
    }
}
