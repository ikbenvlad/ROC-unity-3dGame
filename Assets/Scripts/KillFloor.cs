using UnityEngine;

public class KillFloor : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.transform;
            var controller = player.GetComponent<CharacterController>();
            if (controller != null)
                controller.enabled = false;

            player.position = respawnPoint.position;

            //var motor = player.GetComponent<PlayerMotor>();
            //if (motor != null)
            //    motor.StopMovement();

            if (controller != null)
                controller.enabled = true;
        }
    }
}
