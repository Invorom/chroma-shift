using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardMenuScript : MonoBehaviour
{
    public GameObject humanoid;
    public GameObject guard;

    // Update is called once per frame
    void Update()
    {
        var navMeshAgent = guard.GetComponent<NavMeshAgent>();
        
        navMeshAgent.SetDestination(humanoid.transform.position);
        navMeshAgent.transform.LookAt(humanoid.transform);
    }
}
