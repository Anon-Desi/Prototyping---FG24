using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    PlayerController playerController; 

    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetMouseButtonDown(1)) {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash() {
        float startTime = Time.time;

        while(Time.time < startTime + dashTime) {
            playerController.characterController.Move(playerController.movementDirection * dashSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
