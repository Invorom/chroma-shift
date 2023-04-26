using UnityEngine;
using UnityEngine.UI;

public class DisplayPanel : MonoBehaviour
{
    public Button exitPanelBtn;
    public Button accessBtn;
    public GameObject panelMenu;
    public GameObject mainMenu;
    public bool panelMenuActive = false;

    void Start () {
        exitPanelBtn.onClick.AddListener(TaskOnClick);
        accessBtn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick(){
        if (panelMenuActive == false)
        {
            panelMenu.SetActive(true);
            mainMenu.SetActive(false);
            panelMenuActive = true;
        }
        else
        {
            panelMenu.SetActive(false);
            mainMenu.SetActive(true);
            panelMenuActive = false;
        }
    }
}
