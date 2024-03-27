using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundries : MonoBehaviour
{
    public Transform target; // The player's transform to follow
    public Vector2 minBounds; // Minimum bounds for camera movement
    public Vector2 maxBounds; // Maximum bounds for camera movement
    public float smoothTime = 0.3f; // Smoothing time for camera movement

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        // Calculate target position based on player's position
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

        // Clamp target position within bounds
        targetPosition.x = Mathf.Clamp(targetPosition.x, minBounds.x, maxBounds.x);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minBounds.y, maxBounds.y);

        // Smoothly move the camera towards the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    private void OnDrawGizmosSelected()
    {
        // Draw camera boundary gizmos in scene view for visualization
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(minBounds.x, minBounds.y, 0), new Vector3(maxBounds.x, minBounds.y, 0));
        Gizmos.DrawLine(new Vector3(maxBounds.x, minBounds.y, 0), new Vector3(maxBounds.x, maxBounds.y, 0));
        Gizmos.DrawLine(new Vector3(maxBounds.x, maxBounds.y, 0), new Vector3(minBounds.x, maxBounds.y, 0));
        Gizmos.DrawLine(new Vector3(minBounds.x, maxBounds.y, 0), new Vector3(minBounds.x, minBounds.y, 0));
    }
}
