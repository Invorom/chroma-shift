using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickOnButton : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        var eyes = GameObject.FindWithTag("Eyes");
        var eyesCamera = eyes.GetComponent<Camera>();
        // get mouse click

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            // write in console
            Debug.Log("Mouse click");
            RaycastHit hit;
            Ray ray = eyesCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            
            if (Physics.Raycast(ray, out hit, 3.0f))
            {
                if (hit.collider.gameObject.tag == "Button")
                {
                    // switch value isAtivated on the script OpenDoor
                    var openDoorScript = hit.collider.gameObject.GetComponent<OpenDoor>();
                    if(openDoorScript.isActivated == false)
                    {
                        openDoorScript.isActivated = true;
                    }
                    else
                    {
                        openDoorScript.isActivated = false;
                    }
                    
                }
            }
        }
    }
}
