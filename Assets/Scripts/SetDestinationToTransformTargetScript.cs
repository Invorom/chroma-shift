using UnityEngine;
using UnityEngine.AI;

public class SetDestinationToTransformTargetScript : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }
}