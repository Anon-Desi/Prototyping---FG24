using Unity.Cinemachine;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5f;
    private Vector3 _playerInput;
    void Start() {
        
    }
    void FixedUpdate() {
        Move();
    }
    
    void Update() {
        GatherInput();
        Look();
    }

    void GatherInput() {
        _playerInput = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
    }

    void Look() {
        var relative = (transform.position + _playerInput) - transform.position;
        var rot = Quaternion.LookRotation(relative);

        transform.rotation = rot;
    }

    void Move() {
        _rb.MovePosition(transform.position + transform.forward * _speed * Time.deltaTime);
    }
}
