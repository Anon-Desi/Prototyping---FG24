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
    
    void Start() {
        //Code about starting position
    }
    void FixedUpdate() {
        Move();
    }
    
    void Update() {
        //GatherInput();
        // Look();
        Move();
    }

    // void GatherInput() {
    //     _playerInput = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
    // }

    // void Look() {
    //     var relative = (transform.position + _playerInput) - transform.position;
    //     var rot = Quaternion.LookRotation(relative);

    //     transform.rotation = rot;
    // }

    void Move() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * _speed;
        movementDirection.Normalize();

        //transform.Translate(movementDirection * _speed * Time.deltaTime, Space.World);
        characterController.SimpleMove(movementDirection * magnitude);

        if(movementDirection != Vector3.zero) {
            //transform.forward = movementDirection; 
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}
