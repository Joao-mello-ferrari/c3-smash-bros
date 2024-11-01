using UnityEngine;
using Unity.Netcode;

public class CharacterCollider : NetworkBehaviour
{
    private Collider2D collidedObject; // Store reference to the collided object

    void Update()
    {
        // Only handle input on the local player
        if (IsOwner && collidedObject != null)
        {
            // Detect if the Q key was pressed
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("collided with " + collidedObject.name);
                
                // Notify the display controller and the server
                FindObjectOfType<DisplayController>().IncreaseHit(1);
                collidedObject.GetComponent<CharacterMovement>().CmdNotifyServerOfHitServerRpc();
            }
        }
    }

    // Detect collision and store the collided object
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3) // Layer 3 == player layer
        {
            collidedObject = collision; // Store the collided object reference
        }
    }

    // Clear the collided object when no longer colliding
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == collidedObject)
        {
            collidedObject = null;
        }
    }
}
