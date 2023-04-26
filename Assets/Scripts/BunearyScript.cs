using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunearyScript : MonoBehaviour
{
    public GameObject player;
    public GameObject playerBody;
    void Update()
    {
        var playerRenderer = playerBody.GetComponent<Renderer>(); // Get the player's body's renderer
        var playerScript = player.GetComponent<PhysicalCharacterControllerScript>(); // Get the player's script

        // Increase jump force if the player is blue
        if (playerRenderer.material.color == Color.blue)
        {
            playerScript.jumpForce = 10f;
        }
        else
        {
            playerScript.jumpForce = 8f;
        }
    }
}
