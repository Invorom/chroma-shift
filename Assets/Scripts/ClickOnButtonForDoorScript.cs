using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickOnButtonForDoorScript : MonoBehaviour
{
    
    public GameObject eyes;
    // Update is called once per frame
    void Update()
    {
        var eyesCamera = eyes.GetComponent<Camera>();

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            RaycastHit hit;
            Ray ray = eyesCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            
            if (Physics.Raycast(ray, out hit, 3.0f))
            {
                if (hit.collider.gameObject.tag == "Button")
                {
                    // switch value isAtivated on the script OpenDoor
                    var openDoorScript = hit.collider.gameObject.GetComponent<OpenDoorScript>();
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
