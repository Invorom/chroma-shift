using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickOnButtonScript : MonoBehaviour
{
    public GameObject eyes;
    
    void Update()
    {
        var eyesCamera = eyes.GetComponent<Camera>();

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("Mouse Click");
            RaycastHit hit;
            Ray ray = eyesCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            
            if (Physics.Raycast(ray, out hit, 3.0f))
            {
                if (hit.collider.gameObject.tag == "Button")
                {
                    var script = hit.collider.gameObject.GetComponent<MonoBehaviour>();

                    Debug.Log(script.GetType().Name);
                    if (script.GetType().Name == "OpenDoorScript")
                    {
                        var openDoorScript = script as OpenDoorScript;
                        if(openDoorScript.isActivated == false)
                        {
                            openDoorScript.isActivated = true;
                        }
                        else
                        {
                            openDoorScript.isActivated = false;
                        }
                    }
                    else if (script.GetType().Name == "ChangeCameraScript")
                    {
                        var changeCameraScript = script as ChangeCameraScript;
                        changeCameraScript.OnClick();
                    }
                    
                }
            }
        }
    }
}
