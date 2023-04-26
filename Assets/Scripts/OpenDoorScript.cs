using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OpenDoorScript : MonoBehaviour
{
    public GameObject leftDoor;
    public float leftDoorXStart;
    public float leftDoorYStart;
    public float leftDoorZStart;
    public float leftDoorXEnd;
    public float leftDoorYEnd;
    public float leftDoorZEnd;
    public float leftDoorXRotationStart;
    public float leftDoorYRotationStart;
    public float leftDoorZRotationStart;
    public float leftDoorXRotationEnd;
    public float leftDoorYRotationEnd;
    public float leftDoorZRotationEnd;
    public GameObject rightDoor;
    public float rightDoorXStart;
    public float rightDoorYStart;
    public float rightDoorZStart;
    public float rightDoorXEnd;
    public float rightDoorYEnd;
    public float rightDoorZEnd;
    public float rightDoorXRotationStart;
    public float rightDoorYRotationStart;
    public float rightDoorZRotationStart;
    public float rightDoorXRotationEnd;
    public float rightDoorYRotationEnd;
    public float rightDoorZRotationEnd;

    public bool isActivated = false;
    
    // Update is called once per frame
    void Update()
    {
        if (isActivated == true)
        {
            leftDoor.transform.position = new Vector3(leftDoorXEnd, leftDoorYEnd, leftDoorZEnd);
            leftDoor.transform.rotation =
                Quaternion.Euler(leftDoorXRotationEnd, leftDoorYRotationEnd, leftDoorZRotationEnd);
            rightDoor.transform.position = new Vector3(rightDoorXEnd, rightDoorYEnd, rightDoorZEnd);
            rightDoor.transform.rotation =
                Quaternion.Euler(rightDoorXRotationEnd, rightDoorYRotationEnd, rightDoorZRotationEnd);
        }
        else
        {
            leftDoor.transform.position = new Vector3(leftDoorXStart, leftDoorYStart, leftDoorZStart);
            leftDoor.transform.rotation = Quaternion.Euler(leftDoorXRotationStart, leftDoorYRotationStart, leftDoorZRotationStart);
            rightDoor.transform.position = new Vector3(rightDoorXStart, rightDoorYStart, rightDoorZStart);
            rightDoor.transform.rotation = Quaternion.Euler(rightDoorXRotationStart, rightDoorYRotationStart, rightDoorZRotationStart);
        }
    }
}
