using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachokeScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PhysicalCharacterControllerScript>().walkForce = 15000f;
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
