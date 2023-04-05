using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetamorphScript : MonoBehaviour
{
    void Update()
    {
        var player = GameObject.FindWithTag("Player"); // Find the player
        var playerTransform = player.transform; // Get the player's transform
        var playerScale = playerTransform.localScale; // Get the player's scale
        var playerBody = GameObject.FindWithTag("PlayerBody"); // Find the player's body
        var playerRenderer = playerBody.GetComponent<Renderer>(); // Get the player's body's renderer

        if (playerRenderer.material.color == Color.magenta)
        {
            // Shrink the player
            playerScale.x = 0.5f;
            playerScale.y = 0.5f;
            playerScale.z = 0.5f;
        }
        else
        {
            // Reset the player size
            playerScale.x = 1;
            playerScale.y = 1;
            playerScale.z = 1;
        }
        playerTransform.localScale = playerScale; // Set the player's scale
    }
}
