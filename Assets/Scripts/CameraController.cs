using UnityEngine;

public class CameraController : MonoBehaviour
{
    // These appear in your Inspector
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;

    // This is used internally for smoothing
    private float lookAhead;

    private void Update()
    {
        // 1. Follow the player's X position
        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);

        // 2. Calculate the "Look Ahead" so the camera shifts when you turn
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * Mathf.Sign(player.localScale.x)), Time.deltaTime * cameraSpeed);
    }

    // This function is for the "Door" logic later in the video
    public void MoveToNewRoom(Transform _newRoom)
    {
        // This will snap the camera to a new room's center
        transform.position = new Vector3(_newRoom.position.x, transform.position.y, transform.position.z);
    }
}