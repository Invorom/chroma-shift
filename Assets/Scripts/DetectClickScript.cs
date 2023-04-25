using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;


public class DetectClickScript : MonoBehaviour
{
    [SerializeField]
    public TMP_InputField inputField;
    public Collider Digicode;

    // Make raycast when the player press the left mouse button
    void Update()
    {
        // Get the Eyes tag camera
        var player = GameObject.FindWithTag("Player");
        var playerBody = GameObject.FindWithTag("PlayerBody");
        var eyes = GameObject.FindWithTag("Eyes");
        var eyesCamera = eyes.GetComponent<Camera>();
        var canvasInputField = GameObject.FindWithTag("InputField");

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            RaycastHit hit;
            Ray ray = eyesCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            
            // If the raycast hit Button tag object (Digicode)
            if (Physics.Raycast(ray, out hit, 2.0f))
            {
                if (hit.collider == Digicode)
                {
                    // Block the player's movement
                    player.gameObject.GetComponent<PhysicalCharacterControllerScript>().walkForce = 0f;
                    
                    // Set the mouse sensitivity to 0
                    player.gameObject.GetComponent<PhysicalCharacterControllerScript>().mouseXSensitivity = 0f;
                    player.gameObject.GetComponent<PhysicalCharacterControllerScript>().mouseYSensitivity = 0f;
                    
                    // Get the canvas from the input field
                    var canvas = canvasInputField.GetComponent<Canvas>();
                    
                    // Enable the canvas
                    canvas.enabled = true;

                    // Select the input field
                    inputField.Select();
                    
                    // IsActivated is true for CheckDigicodeScript
                    var checkDigicodeScript = GameObject.FindWithTag("Scripts").GetComponent<CheckDigicodeScript>();
                    checkDigicodeScript.isActivated = true;
                }
            }
        }
        
        // If escape is pressed, disable the canvas
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            // Get the canvas from the input field
            var canvas = canvasInputField.GetComponent<Canvas>();
            
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
