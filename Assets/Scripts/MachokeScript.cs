using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachokeScript : MonoBehaviour
{
    void Update()
    {
        var player = GameObject.FindWithTag("Player");
        var playerBody = GameObject.FindWithTag("PlayerBody");
        var playerRenderer = playerBody.GetComponent<Renderer>();
        
        if (playerRenderer.material.color != Color.red)
        {
            player.gameObject.GetComponent<PhysicalCharacterControllerScript>().walkForce = 8000f;
        }
    } 
    
    private void OnCollisionStay(Collision other)
    {
        var playerBody = GameObject.FindWithTag("PlayerBody");
        var playerRenderer = playerBody.GetComponent<Renderer>();
        
        if (other.gameObject.CompareTag("Player"))
        {
            if (playerRenderer.material.color == Color.red)
            {
                other.gameObject.GetComponent<PhysicalCharacterControllerScript>().walkForce = 15000f;
            }
        }
    }
        
    private void OnCollisionEnter(Collision other)
    {
        var playerBody = GameObject.FindWithTag("PlayerBody");
        var playerRenderer = playerBody.GetComponent<Renderer>();
        
        if (other.gameObject.CompareTag("Player"))
        {
            if (playerRenderer.material.color == Color.red)
            {
                other.gameObject.GetComponent<PhysicalCharacterControllerScript>().walkForce = 15000f;
            }
        }
    }
    
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PhysicalCharacterControllerScript>().walkForce = 8000f;
        }
    }
}
