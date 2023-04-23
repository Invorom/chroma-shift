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
        var player = GameObject.FindWithTag("Player");
        var playerBody = GameObject.FindWithTag("PlayerBody");
        var eyes = GameObject.FindWithTag("Eyes");
        var eyesCamera = eyes.GetComponent<Camera>();
        var inputField = GameObject.FindWithTag("InputField");

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            RaycastHit hit;
            Ray ray = eyesCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            
            // If the raycast hit Button tag object (Digicode)
            if (Physics.Raycast(ray, out hit, 1.0f))
            {
                if (hit.collider.gameObject.tag == "Button")
                {
                    // Get the canvas from the input field
                    var canvas = inputField.GetComponent<Canvas>();
                    
                    // Enable the canvas
                    canvas.enabled = true;
                    
                    // Block the player's movement
                    player.gameObject.GetComponent<PhysicalCharacterControllerScript>().walkForce = 0f;
                    
                    // Set the mouse sensitivity to 0
                    player.gameObject.GetComponent<PhysicalCharacterControllerScript>().mouseXSensitivity = 0f;
                    player.gameObject.GetComponent<PhysicalCharacterControllerScript>().mouseYSensitivity = 0f;
                }
            }
        }
        
        // If escape is pressed, disable the canvas
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            // Get the canvas from the input field
            var canvas = inputField.GetComponent<Canvas>();
            
            // Disable the canvas
            canvas.enabled = false;
            
            // Enable the player's movement
            player.gameObject.GetComponent<PhysicalCharacterControllerScript>().walkForce = 8000f;
            
            // Set the mouse sensitivity to the default value
            player.gameObject.GetComponent<PhysicalCharacterControllerScript>().mouseXSensitivity = 250f;
            player.gameObject.GetComponent<PhysicalCharacterControllerScript>().mouseYSensitivity = 150f;
        }
    }
}
