using System.Runtime.CompilerServices;
using Unity.Cinemachine;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotationSpeed; 

    [SerializeField] private CharacterController characterController;
    [SerializeField] private float jumpSpeed = 5f;
    private float ySpeed;
    
    void Start() {
    }
    void FixedUpdate() {
        Move();
        //Different code, make it so that the player movement isnt dependent on the axis

    }
    
    void Update() {
        //GatherInput();
        // Look();
        Move();
        ySpeed += Physics.gravity.y * Time.deltaTime;
        if(Input.GetButtonDown("Jump")) {
            ySpeed = jumpSpeed;
        }
    }

    void Move() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 movementDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * _speed;
        movementDirection.Normalize();

        //transform.Translate(movementDirection * _speed * Time.deltaTime, Space.World);
        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;
        characterController.Move(velocity * Time.deltaTime);

        if(movementDirection != Vector3.zero) {
            //transform.forward = movementDirection; 
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
        }

    
    }

    private void OnJump() {
        if(Input.GetButtonDown("Jump")) {
            ySpeed = jumpSpeed;
        }
    }
}
