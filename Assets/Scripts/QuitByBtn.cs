using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitByBtn : MonoBehaviour
{
    // Get quit button
    public Button quitBtn;

    void Start () {
        quitBtn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick(){
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }
}
