using UnityEngine;

public class FollowCharacter : MonoBehaviour
{
    public GameObject target; // Reference to the player's transform
    private float smoothSpeed = 0.125f; // Adjust the smoothness of the camera follow

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.transform.position + new Vector3(0f, 0f, -10f); // Offset the camera in the Z-axis
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
