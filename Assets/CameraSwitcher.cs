using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras;
    private int currentCameraIndex;

    void Start()
    {
        // Disable all cameras at start except the first one
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }
        currentCameraIndex = 0;
    }

    void Update()
    {
        // Example: Press 'C' to cycle through cameras
        if (Input.GetKeyDown(KeyCode.C))
        {
            currentCameraIndex++;
            if (currentCameraIndex < cameras.Length) // Check if last camera in array
            {
                cameras[currentCameraIndex - 1].gameObject.SetActive(false);
                cameras[currentCameraIndex].gameObject.SetActive(true);
            }
            else
            {
                // If we've reached the last camera, cycle back to the first
                cameras[currentCameraIndex - 1].gameObject.SetActive(false);
                currentCameraIndex = 0;
                cameras[currentCameraIndex].gameObject.SetActive(true);
            }
        }
    }
}