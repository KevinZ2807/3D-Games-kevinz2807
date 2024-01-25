
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;

    [Header("Attributes")]
    [SerializeField] private float speed = 12f;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private float jumpHeight = 2f;


    private float gravity = -9.81f;
    private bool isGrounded;
    Vector3 velocity;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        Move();
    }

    private void Move() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Di chuyen
        Vector3 move = transform.right * x + transform.forward * z; // Transform.right: di chuyen theo huong phai cua nhan vat thay vi cua the gioi
                                                                    // Transform.forward: Nhin theo huong thang cua nhan vat
        controller.Move(move * speed * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && isGrounded) velocity.y = Mathf.Sqrt(jumpHeight *
        -2f * gravity); // jump = sqrt(2f * -2f * -9.81f)
        // Falling calculate
        if (isGrounded && velocity.y < 0) velocity.y = -2f;
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime); // y = (1/2) x g x t^2
    }

}
