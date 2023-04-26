using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickOnButtonScript : MonoBehaviour
{
    public Collider Button;

    // Update is called once per frame
    void Update()
    {
        var eyes = GameObject.FindWithTag("Eyes");
        var eyesCamera = eyes.GetComponent<Camera>();

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            RaycastHit hit;
            Ray ray = eyesCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            
            if (Physics.Raycast(ray, out hit, 2.0f))
            {
                if (hit.collider == Button)
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
