using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChromaChangeScript : MonoBehaviour
{
    void Update()
    {
        var playerBody = GameObject.FindWithTag("PlayerBody");
        var playerRenderer = playerBody.GetComponent<Renderer>();
        var characterRootTransform = playerBody.transform.parent;
        
        
        // Change the player color
        if (playerRenderer.material.color != Color.magenta ||
            !(Physics.SphereCast(characterRootTransform.position + 0.4951f * Vector3.up, 0.495f, Vector3.up,
                out var hit, 0.51f)))
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (playerRenderer.material.color == Color.red)
                {
                    playerRenderer.material.color = Color.white;
                }
                else
                {
                    // Red
                    playerRenderer.material.color = Color.red;
                }
            }

            if (Input.GetKeyUp(KeyCode.E))
            {
                if (playerRenderer.material.color == Color.blue)
                {
                    playerRenderer.material.color = Color.white;
                }
                else
                {
                    // Blue
                    playerRenderer.material.color = Color.blue;
                }
            }

            if (Input.GetKeyUp(KeyCode.R))
            {
                if (playerRenderer.material.color == Color.magenta)
                {
                    playerRenderer.material.color = Color.white;
                }
                else
                {
                    // Purple
                    playerRenderer.material.color = Color.magenta;
                }
            }

            if (Input.GetKeyUp(KeyCode.F))
            {
                if (playerRenderer.material.color == Color.green)
                {
                    playerRenderer.material.color = Color.white;
                }
                else
                {
                    // Green
                    playerRenderer.material.color = Color.green;
                }
            }
        }
    }
}
