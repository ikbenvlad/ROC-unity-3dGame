using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float distance = 3f; // distance to interact with objects
    [SerializeField] private LayerMask mask; // layer mask for interactable and wall objects
    private PlayerUI playerUI; // reference to the PlayerUI script to update the prompt text
    private InputManager inputManager; // reference to the InputManager script

    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    void Update()
    {
        playerUI.UpdateText(string.Empty);

        // Ray from the center of the camera
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);

        RaycastHit hitInfo;
        // Raycast using the mask (should include both Interactable and Wall layers)
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            // Only interact if the first thing hit is an Interactable
            Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                playerUI.UpdateText(interactable.promptMessage);
                if (inputManager.onFoot.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}