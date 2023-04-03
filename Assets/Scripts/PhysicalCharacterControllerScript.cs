using System;
using UnityEngine;

public class PhysicalCharacterControllerScript : MonoBehaviour
{
    public float jumpForce = 10.0f;
    public float walkForce = 10.0f; // Realistic
    public float rotationSpeed = 360f;
    public float mouseXSensitivity = 1f;
    public float mouseYSensitivity = 1f;
    public float maximumHorizontalVelocity = 10f;
    public Transform characterRootTransform;
    public Transform characterEyesTransform;
    public Rigidbody characterRootRigidbody;
    private float _yawRotationIntent;
    private float _pitchRotationIntent;
    private float _forwardMovementIntent;
    private float _lateralMovementIntent;
    private bool _wantToJump;

    // Update is called once per frame
    void Update()
    {
        _yawRotationIntent = 0f;
        _forwardMovementIntent = 0f;
        _lateralMovementIntent = 0f;
        
        QuakeLikeInput();
        characterRootTransform.Rotate(Vector3.up * (_yawRotationIntent * rotationSpeed * Time.deltaTime));
        characterEyesTransform.Rotate(-Vector3.right * (_pitchRotationIntent * rotationSpeed * Time.deltaTime));
        var localRotation = characterEyesTransform.localEulerAngles.x;
        if (localRotation > 180f)
        {
            localRotation -= 360f;
        }

        localRotation = Mathf.Clamp(localRotation, -80f, 80f);
        characterEyesTransform.localEulerAngles = new Vector3(localRotation, 0f, 0f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _wantToJump = true;
        }
    }
    
    private void QuakeLikeInput()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            _lateralMovementIntent += -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _lateralMovementIntent += 1f;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            _forwardMovementIntent += 1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _forwardMovementIntent += -1f;
        }

        _yawRotationIntent = Input.GetAxisRaw("Mouse X") * mouseXSensitivity * Time.deltaTime;
        _pitchRotationIntent = Input.GetAxisRaw("Mouse Y") * mouseYSensitivity * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (Physics.SphereCast(characterRootTransform.position + 0.4951f * Vector3.up, 0.495f,
                Vector3.down, out var hit, 0.1f))
        {
            var velocity = characterRootRigidbody.velocity;
            var targetForce = characterRootTransform.forward * _forwardMovementIntent;
            targetForce += characterRootTransform.right * _lateralMovementIntent;
            targetForce = targetForce.normalized * (walkForce * Time.deltaTime);
            characterRootRigidbody.AddForce(targetForce,
                ForceMode.Force);
            velocity.y = 0f;
            velocity = Vector3.ClampMagnitude(velocity,
                maximumHorizontalVelocity);
            velocity.y = characterRootRigidbody.velocity.y;
            characterRootRigidbody.velocity = velocity;
            
            if (_wantToJump)
            {
                _wantToJump = false;
                velocity.y = 0f;
                characterRootRigidbody.velocity = velocity;
                characterRootRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
        else
        {
            var velocity = characterRootRigidbody.velocity;
            velocity.x -= velocity.x * 0.02f;
            velocity.z -= velocity.z * 0.02f;
            characterRootRigidbody.velocity = velocity;
        }
    }
}
