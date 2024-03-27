using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E; // Define the key to interact with the button
    public Transform buttonPosition; // Position where the button needs to be pressed to trigger scene change
    public string sceneToLoad; // Name of the scene to load

    public Transform playerTransform; // Reference to the player's transform

    private void Update()
    {
        // Check if the interact key is pressed and if the player is at the button position
        if (Input.GetKeyDown(interactKey) && IsPlayerAtButtonPosition())
        {

            // Save player position
            SavePlayerPosition();

            // Load the scene specified
            SceneManager.LoadScene(sceneToLoad);
        }
    }

        private void SavePlayerPosition()
        {
            // Save player position to PlayerPrefs or any other data storage method
            PlayerPrefs.SetFloat("PlayerX", playerTransform.position.x);
            PlayerPrefs.SetFloat("PlayerY", playerTransform.position.y);
            PlayerPrefs.SetFloat("PlayerZ", playerTransform.position.z);
        }
    

    private bool IsPlayerAtButtonPosition()
    {
        // Calculate the distance between the player's position and the button position
        float distance = Vector3.Distance(transform.position, buttonPosition.position);

        // If the distance is less than a threshold, consider the player to be at the button position
        // Adjust the threshold as needed based on your game's scale
        float threshold = 1.5f;
        return distance < threshold;
    }
}
