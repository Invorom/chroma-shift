using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageSoundScript : MonoBehaviour
{
    public GameObject sound;

    private void OnTriggerEnter(Collider other)
    {
        // If the player enters the trigger zone
        if (other.gameObject.tag == "PlayerBody")
        {
            // Play the sound
            sound.GetComponent<AudioSource>().enabled = true;
            
            // And destroy the other sounds
        }
    }
}
