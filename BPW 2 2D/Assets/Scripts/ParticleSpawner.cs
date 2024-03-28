using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public GameObject particlePrefab; // Reference to the particle prefab to spawn
    private Collider2D playerCollider; // Reference to the collider of the player

    private void Start()
    {
        // Find the player GameObject with the "Player" tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            // Get the collider component attached to the player GameObject
            playerCollider = player.GetComponent<Collider2D>();
        }
        else
        {
            Debug.LogError("Player GameObject not found! Make sure it has the 'Player' tag assigned.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player has entered the collider
        if (other == playerCollider)
        {
            Debug.Log("Player entered the collider");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // Check if the player is inside the collider and pressed the "E" key
        if (other == playerCollider && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("F key pressed inside the collider");
            // Spawn the particle effect at the current position
            Instantiate(particlePrefab, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the player has exited the collider
        if (other == playerCollider)
        {
            Debug.Log("Player exited the collider");
        }
    }
}