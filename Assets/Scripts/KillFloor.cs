using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class KillFloor : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float distance = 3f; // distance to check for death
    [SerializeField] private LayerMask death; // layer mask for the death floor
    [SerializeField] private Transform respawnPoint; // respawn point for the player
    [SerializeField] private Transform player; // reference to the player object

    private float respawnCooldown = 1.0f; // seconds to wait after respawn
    private float respawnTimer = 0f;

    private void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
    }
    void Update()
    {
        if (respawnTimer > 0f)
        {
            respawnTimer -= Time.deltaTime;
            return;
        }

        Ray ray = new Ray(cam.transform.position, -Vector3.up);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
        RaycastHit hitInfo;
        bool hitDeath = Physics.Raycast(ray, out hitInfo, distance, death);
        if (hitDeath)
        {
            // Disable CharacterController before moving
            var controller = player.GetComponent<CharacterController>();
            if (controller != null)
                controller.enabled = false;

            player.transform.position = respawnPoint.transform.position;

            // Reset movement in PlayerMotor if present
            var motor = player.GetComponent<PlayerMotor>();
            if (motor != null)
                motor.StopMovement();

            // Re-enable CharacterController after moving
            if (controller != null)
                controller.enabled = true;

            respawnTimer = respawnCooldown;
        }
    }
}
