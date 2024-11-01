using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : NetworkBehaviour
{
    public Rigidbody2D rigidBody;
    public Animator animator;
    private readonly float gravity = 7f;
    public float jumpStrength = 20;

    // Udpdated by owner, read by others
    public readonly NetworkVariable<bool> netPlayerIsWalking = new(false, writePerm: NetworkVariableWritePermission.Owner);
    public readonly NetworkVariable<Vector2> netPosition = new(writePerm: NetworkVariableWritePermission.Owner);
    public readonly NetworkVariable<Vector2> netYVelocity = new(writePerm: NetworkVariableWritePermission.Owner);
    
    private DisplayController displayController;
    private float knockbackMultiplier = 2f;  // Base multiplier for knockback
    private float boundaryY = 10f;  // Adjust based on your scene size
    private int maxStocks = 3;
    private int currentStocks;
    private int hittedHitCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody.gravityScale = gravity;
        animator = GetComponent<Animator>();
        displayController = GameObject.FindObjectOfType<DisplayController>();
        currentStocks = maxStocks;
    }

    // Update is called once per frame
    void Update()
    {   
        // Update other's state
        if(!IsOwner) { 
            rigidBody.position = netPosition.Value;
            //rigidBody.velocity = netYVelocity.Value;
            animator.SetBool("isWalking", netPlayerIsWalking.Value);
            return;
        } else {
            netPosition.Value = rigidBody.position;
            netYVelocity.Value = rigidBody.velocity;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && rigidBody.position.y < -0.83f && rigidBody.position.y > -0.84f)
        {      
            // Update owner state
            rigidBody.velocity = Vector2.up * jumpStrength;
        }

        if(Input.GetKey(KeyCode.RightArrow)){
            // Calculate new position
            Vector2 newPosition = new(rigidBody.position.x + 7f * Time.deltaTime, rigidBody.position.y);
            
            // Update owner state
            rigidBody.position = newPosition;
            animator.SetBool("isWalking", true);
            
            // Update network variables
            netPlayerIsWalking.Value = true;
        }
        else if(Input.GetKey(KeyCode.LeftArrow)){
            // Calculate new position
            Vector2 newPosition = new(rigidBody.position.x - 7f * Time.deltaTime, rigidBody.position.y);
            
            // Update owner state
            rigidBody.position = newPosition;
            animator.SetBool("isWalking", true);

            // Update network variables
            netPlayerIsWalking.Value = true;
        } else {
            // Update owner state
            animator.SetBool("isWalking", false);
            
            // Update network variables
            netPlayerIsWalking.Value = false;
        }

        // Add boundary check
        CheckBoundaries();
    }

    private void CheckBoundaries()
    {
        if (Mathf.Abs(rigidBody.position.y) > boundaryY)
        {
            if (IsOwner)
            {
                currentStocks--;
                if (currentStocks <= 0)
                {
                    // Implement game over logic here
                    Debug.Log("Game Over!");
                }
                else
                {
                    // Respawn
                    Debug.Log("Respawn!");
                    rigidBody.position = Vector2.zero;
                }
            }
        }
    }

    // Client tells server to notify all other clients running this prefab script
    // We need RequireOwnership = false to allow users to hit and push opponents
    [ServerRpc(RequireOwnership = false)]
    public void CmdNotifyServerOfHitServerRpc()
    {
        // Then notify all clients with the updated hit count
        hittedHitCount++;
        RpcPushPlayerClientRpc(hittedHitCount);
    }

    // Server tells each client to run this function
    [ClientRpc]
    void RpcPushPlayerClientRpc(int hittedHitCount)
    {
        if (IsOwner){
            displayController.IncreaseHitsReceived(1);
        }
        Debug.Log("Hitted's hits: " + hittedHitCount);
        float knockbackForce = 2f + (knockbackMultiplier * hittedHitCount);
        Debug.Log("knockbackForce: " + knockbackForce);
        Vector2 newPosition = new(rigidBody.position.x + knockbackForce, rigidBody.position.y);
        rigidBody.position = newPosition;
    }
}
