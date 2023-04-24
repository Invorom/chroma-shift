using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OpenDoor : MonoBehaviour
{
    public GameObject leftDoor;
    public float leftDoorXStart;
    public float leftDoorYStart;
    public float leftDoorZStart;
    public float leftDoorXEnd;
    public float leftDoorYEnd;
    public float leftDoorZEnd;
    public GameObject rightDoor;
    public float rightDoorXStart;
    public float rightDoorYStart;
    public float rightDoorZStart;
    public float rightDoorXEnd;
    public float rightDoorYEnd;
    public float rightDoorZEnd;
    
    public bool isActivated = false;
    
    // Update is called once per frame
    void Update()
    {
        if (isActivated == true)
        {
            leftDoor.transform.position = new Vector3(leftDoorXEnd, leftDoorYEnd, leftDoorZEnd);
            rightDoor.transform.position = new Vector3(rightDoorXEnd, rightDoorYEnd, rightDoorZEnd);
        }
        else
        {
            leftDoor.transform.position = new Vector3(leftDoorXStart, leftDoorYStart, leftDoorZStart);
            rightDoor.transform.position = new Vector3(rightDoorXStart, rightDoorYStart, rightDoorZStart);
        }
    }
    
    // on change value of isActivated
    
    
}
