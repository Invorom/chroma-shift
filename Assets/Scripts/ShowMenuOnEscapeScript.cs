using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ShowMenuOnEscapeScript : MonoBehaviour
{
    public GameObject panel;
    public GameObject player;
    public GameObject scriptHolder;
    public GameObject crosshair;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panel.activeSelf == false)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                crosshair.SetActive(false);
                // disable all scripts on player
                var scripts = player.GetComponents<MonoBehaviour>();
                foreach (var script in scripts)
                {
                    script.enabled = false;
                }
                // disable hide cursor script on ScriptHolder
                var hideCursorScript = scriptHolder.GetComponent<HideCursorScript>();
                hideCursorScript.enabled = false;
                // enable panel
                panel.SetActive(true);
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                crosshair.SetActive(true);
                // enable all scripts on player
                var scripts = player.GetComponents<MonoBehaviour>();
                foreach (var script in scripts)
                {
                    script.enabled = true;
                }
                // enable hide cursor script on ScriptHolder
                var hideCursorScript = scriptHolder.GetComponent<HideCursorScript>();
                hideCursorScript.enabled = true;
                // disable panel
                panel.SetActive(false);
            }
        }
    }
}