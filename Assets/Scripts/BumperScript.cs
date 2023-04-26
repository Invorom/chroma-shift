using UnityEngine;

public class BumperScript : MonoBehaviour
{
    public float force = 1000;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        var targetRigidBody = other.gameObject.transform.parent.GetComponent<Rigidbody>();
        var velocity = targetRigidBody.velocity;
        velocity.y = 0f;
        targetRigidBody.velocity = velocity;
        targetRigidBody.AddForce(transform.up * force, ForceMode.Impulse);
    }
}