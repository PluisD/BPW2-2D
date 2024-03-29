using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ShowButton : MonoBehaviour
{

    [SerializeField] private Image customImage;
 
    public string playerTag = "Player"; // Tag of the GameObject that triggers the image

    private void Start()
    {
        customImage.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering GameObject has the specified tag
        if (other.CompareTag(playerTag))
        {
            // Show the image GameObject
            customImage.enabled = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the exiting GameObject has the specified tag
        if (other.CompareTag(playerTag))
        {
            // Hide the image GameObject
            customImage.enabled = false; 
        }
    }
}