using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DetectClickScript : MonoBehaviour
{
    // Make raycast when the player press the left mouse button
    void Update()
    {
        // Get the Eyes tag camera
        var eyes = GameObject.FindWithTag("Eyes");
        var eyesCamera = eyes.GetComponent<Camera>();
        
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            RaycastHit hit;
            Ray ray = eyesCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            
            // If the raycast hit MovingCube tag console log "Hit"
            if (Physics.Raycast(ray, out hit, 1.0f))
            {
                if (hit.collider.gameObject.tag == "Button")
                {
                    Debug.Log("Hit");
                }
            }
        }
    }
}
