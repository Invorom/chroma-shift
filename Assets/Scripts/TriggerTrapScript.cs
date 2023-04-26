using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrapScript : MonoBehaviour
{
    public GameObject trapdoor;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBody"))
        {
            trapdoor.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
