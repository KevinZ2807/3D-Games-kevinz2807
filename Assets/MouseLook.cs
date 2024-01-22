using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    //public Transform playerBody;
    private Transform parentTransform;
    
    public float mouseSensitivity = 100f;
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        parentTransform = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Nhan gia tri dieu khien chuot
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Nhin len/xuong
        xRotation -= mouseY; // Neu cong, huong nhin se nguoc lai
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Gioi han goc xoay camera
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        gun.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Nhin trai/phai
        parentTransform.Rotate(Vector3.up * mouseX);
    }
}
