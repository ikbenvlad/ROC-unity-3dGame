using UnityEngine;

public class Climb : MonoBehaviour
{
    // The upward force applied to the player
    public float climbForce = 5f;
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                // Apply an upward force to the player
                playerRb.linearVelocity = new Vector3(playerRb.linearVelocity.x, climbForce, playerRb.linearVelocity.z);
            }
        }
    }
}
