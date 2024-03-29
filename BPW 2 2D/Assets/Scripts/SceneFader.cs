using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Texture2D fadeTexture; // Texture used for fading
    public float fadeSpeed = 1f; // Speed of the fade effect
    public KeyCode interactKey = KeyCode.E; // Key to trigger the scene transition

    private int drawDepth = -1000; // Texture's draw order in the hierarchy
    private float alpha = 1f; // Alpha value of the texture
    private int fadeDirection = -1; // Direction of the fade (-1 = fade in, 1 = fade out)

    private void Update()
    {
        // Check if the interact key is pressed to trigger the scene transition
        if (Input.GetKeyDown(interactKey))
        {
            StartCoroutine(FadeToNextScene());
        }
    }

    private void OnGUI()
    {
        // Fade out/in the alpha value using a direction, a speed, and Time.deltaTime to convert the operation to seconds
        alpha += fadeDirection * fadeSpeed * Time.deltaTime;
        // Force (clamp) the number to be between 0 and 1 because GUI.color uses alpha values between 0 and 1
        alpha = Mathf.Clamp01(alpha);

        // Set color of GUI (in this case, the texture). All color values remain the same & the alpha is set to the variable alpha
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth; // Make the black texture render on top
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture); // Draw the texture to fill the screen
    }

    private IEnumerator FadeToNextScene()
    {
        yield return FadeOut(); // Fade out the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Load the next scene
        yield return FadeIn(); // Fade in the new scene
    }

    private IEnumerator FadeOut()
    {
        fadeDirection = 1; // Set fade direction to fade out
        yield return new WaitForSeconds(fadeSpeed); // Wait for fade speed duration
    }

    private IEnumerator FadeIn()
    {
        fadeDirection = -1; // Set fade direction to fade in
        yield return new WaitForSeconds(fadeSpeed); // Wait for fade speed duration
    }
}