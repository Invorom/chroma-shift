using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTargetGameObjectScript : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Destroy(target);
        }
    }
}
