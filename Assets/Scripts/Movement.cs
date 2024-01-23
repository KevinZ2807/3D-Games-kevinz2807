
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CharacterController controller;

    [Header("Attributes")]
    [SerializeField] private float speed = 12f;

    private float gravity = -9.81f;
    Vector3 velocity;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Di chuyen
        Vector3 move = transform.right * x + transform.forward * z; // Transform.right: di chuyen theo huong phai cua nhan vat thay vi cua the gioi
                                                                    // Transform.forward: Nhin theo huong thang cua nhan vat
        controller.Move(move * speed * Time.deltaTime);
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime); // y = (1/2) x g x t^2
    }

}
