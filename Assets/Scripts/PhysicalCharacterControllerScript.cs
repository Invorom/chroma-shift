using UnityEngine;
using UnityEngine.Serialization;

public class PhysicalCharacterControllerScript : MonoBehaviour
{
    public float jumpForce = 10.0f; // Force to apply when jumping
    public float walkForce = 10.0f; // Force to apply when walking
    public float rotationSpeed = 360f; // Speed of rotation in degrees per second
    public float airFriction = 0.05f; // Friction to apply when jumping
    public float airControl = 0.08f; // Air control to apply when jumping
    public float mouseXSensitivity = 1f; // Sensitivity of mouse movement in degrees per pixel
    public float mouseYSensitivity = 1f; // Sensitivity of mouse movement in degrees per pixel
    public float maximumHorizontalVelocity = 10f; // Maximum horizontal velocity in meters per second
    public Transform characterRootTransform; // The transform of the character's root
    public Transform characterEyesTransform; // The transform of the character's eyes
    public Rigidbody characterRootRigidbody; // The rigidbody of the character's root
    private float _yawRotationIntent; // The amount of rotation to apply around the Y axis
    private float _pitchRotationIntent; // The amount of rotation to apply around the X axis
    private float _forwardMovementIntent; // The amount of movement to apply forward
    private float _lateralMovementIntent; // The amount of movement to apply to the side
    private bool _wantToJump; // Whether the character wants to jump

    // Update is called once per frame
    void Update()
    {
        // Reset the rotation and movement intents
        _yawRotationIntent = 0f;
        _forwardMovementIntent = 0f;
        _lateralMovementIntent = 0f;
        
        // Get the input
        InputManager();
        
        // Apply the rotation
        characterRootTransform.Rotate(Vector3.up * (_yawRotationIntent * rotationSpeed * Time.deltaTime));
        characterEyesTransform.Rotate(-Vector3.right * (_pitchRotationIntent * rotationSpeed * Time.deltaTime));
        var localRotation = characterEyesTransform.localEulerAngles.x;
        if (localRotation > 180f)
        {
            localRotation -= 360f;
        }

        // Clamp the rotation
        localRotation = Mathf.Clamp(localRotation, -80f, 80f);
        characterEyesTransform.localEulerAngles = new Vector3(localRotation, 0f, 0f);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _wantToJump = true;
        }
    }
    
    private void InputManager()
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

        // Get the mouse movement
        _yawRotationIntent = Input.GetAxisRaw("Mouse X") * mouseXSensitivity * Time.deltaTime;
        _pitchRotationIntent = Input.GetAxisRaw("Mouse Y") * mouseYSensitivity * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        // Check if the character is grounded
        if (Physics.SphereCast(characterRootTransform.position + 0.4951f * Vector3.up, 0.495f,
                Vector3.down, out var hit, 0.1f) )
        {
            // Add a force to the character
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
            
            // Jump
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
            _wantToJump = false;

            // Apply a friction to the character when in the air
            var velocity = characterRootRigidbody.velocity;
            velocity.x -= velocity.x * airFriction;
            velocity.z -= velocity.z * airFriction;
            characterRootRigidbody.velocity = velocity;
            
            // Add a air control lower than the ground control
            var targetForce = characterRootTransform.forward * _forwardMovementIntent;
            targetForce += characterRootTransform.right * _lateralMovementIntent;
            targetForce = targetForce.normalized * (walkForce * Time.deltaTime * airControl);
            characterRootRigidbody.AddForce(targetForce,
                ForceMode.Force);
        }
    }
}
