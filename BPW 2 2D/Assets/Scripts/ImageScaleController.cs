using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ImageScaleController : MonoBehaviour
{
    // Public variables for width and height
    public float width;
    public float height;

    // Reference to the UI Image component
    private Image image;

    void Start()
    {
        // Get the Image component attached to this GameObject
        image = GetComponent<Image>();

        // Set initial size based on public variables
        SetImageSize();
    }

    void Update()
    {
        // If the size values change in the editor, update the image size accordingly
        if (width != image.rectTransform.sizeDelta.x || height != image.rectTransform.sizeDelta.y)
        {
            SetImageSize();
        }
    }

    // Function to set the size of the UI Image
    void SetImageSize()
    {
        // Set the size of the image using RectTransform's sizeDelta property
        image.rectTransform.sizeDelta = new Vector2(width, height);
    }
}