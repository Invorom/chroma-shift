using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnownScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        var trap = GameObject.FindWithTag("Trap");
        var playerBody = GameObject.FindWithTag("PlayerBody");
        var playerRenderer = playerBody.GetComponent<Renderer>();
        
        if (playerRenderer.material.color != Color.green)
        {
            // Desactivate the mesh renderer of the trap
            trap.GetComponent<MeshRenderer>().enabled = false;
        }
        
        if (playerRenderer.material.color == Color.green)
        {
            // Activate the mesh renderer of the trap
            trap.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
