using Unity.Cinemachine;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] CinemachineCamera defaultCamera;
    [SerializeField] CinemachineCamera interactionCamera;
    [SerializeField] CinemachineCamera startingCamera;
    [SerializeField] GameObject eSign;

    private bool ePressed = false;
    private bool canInteract = false;

    private void Start() {
        interactionCamera.gameObject.SetActive(false);
        startingCamera.gameObject.SetActive(true);
        defaultCamera.gameObject.SetActive(false);
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
        if(this.gameObject.name == "First Threshold") {
            startingCamera.gameObject.SetActive(false);
            defaultCamera.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(this.gameObject.name == "NPC Granny") {
            canInteract = false;
            ePressed = false;
            interactionCamera.gameObject.SetActive(false);
            defaultCamera.gameObject.SetActive(true);
            eSign.gameObject.SetActive(false);
        }

        Debug.Log("Trigger Left");
    }
}
