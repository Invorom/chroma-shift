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
	    var movingCubes = GameObject.FindGameObjectsWithTag("MovingCube");
		var InputField = GameObject.FindWithTag("InputField");
		var canvas = InputField.GetComponent<Canvas>();
        
        if (playerRenderer.material.color != Color.red && canvas.enabled == false)
        {
            player.gameObject.GetComponent<PhysicalCharacterControllerScript>().walkForce = 8000f;

			// Change the mass of the moving cubes
			foreach (var movingCube in movingCubes)
			{
				movingCube.GetComponent<Rigidbody>().mass = 50f;
			}
        }
    } 
    
    private void OnCollisionStay(Collision other)
    {
        var playerBody = GameObject.FindWithTag("PlayerBody");
        var playerRenderer = playerBody.GetComponent<Renderer>();
	    var movingCubes = GameObject.FindGameObjectsWithTag("MovingCube");
        
        if (other.gameObject.CompareTag("Player"))
        {
            if (playerRenderer.material.color == Color.red)
            {
                other.gameObject.GetComponent<PhysicalCharacterControllerScript>().walkForce = 15000f;
				// Change the mass of the moving cubes
				foreach (var movingCube in movingCubes)
				{
					movingCube.GetComponent<Rigidbody>().mass = 1f;
				}
            }
        }
    }
        
    private void OnCollisionEnter(Collision other)
    {
        var playerBody = GameObject.FindWithTag("PlayerBody");
        var playerRenderer = playerBody.GetComponent<Renderer>();
	    var movingCubes = GameObject.FindGameObjectsWithTag("MovingCube");
        
        if (other.gameObject.CompareTag("Player"))
        {
            if (playerRenderer.material.color == Color.red)
            {
                other.gameObject.GetComponent<PhysicalCharacterControllerScript>().walkForce = 15000f;
				// Change the mass of the moving cubes
				foreach (var movingCube in movingCubes)
				{
					movingCube.GetComponent<Rigidbody>().mass = 1f;
				}
            }
        }
    }
    
    private void OnCollisionExit(Collision other)
    {
	    var movingCubes = GameObject.FindGameObjectsWithTag("MovingCube");

        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PhysicalCharacterControllerScript>().walkForce = 8000f;
			// Change the mass of the moving cubes
			foreach (var movingCube in movingCubes)
			{
				movingCube.GetComponent<Rigidbody>().mass = 50f;
			}
        }
    }
}
