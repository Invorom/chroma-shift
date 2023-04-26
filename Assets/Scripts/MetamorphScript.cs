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
			// Get the player's root transform
			var characterRootTransform = player.GetComponent<PhysicalCharacterControllerScript>().characterRootTransform;
			if (!(Physics.SphereCast(characterRootTransform.position + 0.4951f * Vector3.up, 0.495f,
                Vector3.up, out var hit, 0.51f)) )
			{
			    // Grow the player
				playerScale.x = 1f;
				playerScale.y = 1f;
				playerScale.z = 1f;
			}
        }
        playerTransform.localScale = playerScale; // Set the player's scale
    }
}
