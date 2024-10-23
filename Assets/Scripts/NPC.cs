using TMPro;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] CinemachineCamera defaultCamera;
    [SerializeField] CinemachineCamera interactionCamera;
    [SerializeField] GameObject eSign;

    private bool ePressed = false;
    private bool canInteract = false;

    private void Start() {
        interactionCamera.gameObject.SetActive(false);
        eSign.gameObject.SetActive(false);
    }

    private void Update() {
        if (canInteract && Input.GetKeyUp(KeyCode.E)) {
            ePressed = true;
            Debug.Log("E pressed");
            
            
            if (ePressed) {
                Debug.Log("Interaction triggered");
                eSign.gameObject.SetActive(false);
                interactionCamera.gameObject.SetActive(true);
                defaultCamera.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (this.gameObject.name == "NPC Granny") {
            eSign.gameObject.SetActive(true);
            Debug.Log("Granny found");
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        canInteract = false;
        ePressed = false;
        Debug.Log("Trigger Left");
    }
}
