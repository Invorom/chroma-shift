using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        var filter = GameObject.FindWithTag("Filter");
        var playerBody = GameObject.FindWithTag("PlayerBody");
        var playerRenderer = playerBody.GetComponent<Renderer>();
        
        // Get the Filter material
        var transparentMaterial = filter.GetComponent<MeshRenderer>().material;

        if (playerRenderer.material.color == Color.white)
        {
            // Activate the mesh renderer of the filter
            filter.GetComponent<MeshRenderer>().enabled = false;
        }

        if (playerRenderer.material.color == Color.red)
        {
            // Activate the mesh renderer of the filter
            filter.GetComponent<MeshRenderer>().enabled = true;
            // Set the filter material to red transparent
            transparentMaterial.color = new Color(1, 0, 0, 0.0001f);
            // Set the filter material emission color to red
            transparentMaterial.SetColor("_EmissionColor", new Color(0.35f, 0, 0));
        }
        
        if (playerRenderer.material.color == Color.blue)
        {
            // Activate the mesh renderer of the filter
            filter.GetComponent<MeshRenderer>().enabled = true;
            // Set the filter material to blue transparent
            transparentMaterial.color = new Color(0, 0, 1, 0.0001f);
            // Set the filter material emission color to blue
            transparentMaterial.SetColor("_EmissionColor", new Color(0, 0, 0.35f));
        }
        
        if (playerRenderer.material.color == Color.green)
        {
            // Activate the mesh renderer of the filter
            filter.GetComponent<MeshRenderer>().enabled = true;
            // Set the filter material to green transparent
            transparentMaterial.color = new Color(0, 0.6f, 0, 0.0001f);
            // Set the filter material emission color to green
            transparentMaterial.SetColor("_EmissionColor", new Color(0, 0.2f, 0));
        }
        
        if (playerRenderer.material.color == Color.magenta)
        {
            // Activate the mesh renderer of the filter
            filter.GetComponent<MeshRenderer>().enabled = true;
            // Set the filter material to magenta transparent
            transparentMaterial.color = new Color(1, 0, 1, 0.0001f);
            // Set the filter material emission color to magenta
            transparentMaterial.SetColor("_EmissionColor", new Color(0.35f, 0, 0.35f));
        }
    }
}
