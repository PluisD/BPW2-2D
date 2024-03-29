using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Add this line to include the UI namespace

public class SceneChanger : MonoBehaviour

{
    public KeyCode interactKey = KeyCode.E; // Define the key to interact with the button
    public Transform buttonPosition; // Position where the button needs to be pressed to trigger scene change
    public string sceneToLoad; // Name of the scene to load

    public Image image; // Reference to the Image component for fade-in effect
    public float fadeDuration = 1f; // Duration of the fade-in animation

    public Transform playerTransform; // Reference to the player's transform

    private bool fadeInTriggered = false; // Flag to track if fade-in is triggered

    private void Start()
    {
        // Ensure the image is initially hidden
        image.gameObject.SetActive(false);
    }

    private void Update()
    {
        // Check if the interact key is pressed, fade-in is not already triggered, and if the player is at the button position
        if (Input.GetKeyDown(interactKey) && !fadeInTriggered && IsPlayerAtButtonPosition())
        {
            fadeInTriggered = true;
            // Start the fade-in coroutine
            StartCoroutine(FadeInImageAndLoadScene());
        }
    }

    private System.Collections.IEnumerator FadeInImageAndLoadScene()
    {
        // Activate the image
        image.gameObject.SetActive(true);

        float elapsedTime = 0f;

        // Gradually increase the alpha value of the image to fade it in
        while (elapsedTime < fadeDuration)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the alpha value is exactly 1 at the end of the fade-in
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);

        // Save player position
        SavePlayerPosition();

        // Load the scene specified
        SceneManager.LoadScene(sceneToLoad);
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