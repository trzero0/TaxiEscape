using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 rotation;
    public Camera cam;
    public float lookSens = 5f;
    public float speed = 1f;
    public float jumpHeight = 5f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movement Input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 moveInput = new Vector2(horizontalInput, verticalInput);

        // Mouse Rotation
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y"); // Invert vertical input for typical FPS controls

        // Apply camera rotation (up/down) and player rotation (left/right)
        cam.transform.eulerAngles = new Vector2(rotation.x * lookSens, 0);
        transform.eulerAngles = new Vector2(0, rotation.y * lookSens);

        // Calculate desired velocity and apply it to the Rigidbody
        Vector3 desiredVelocity = transform.forward * moveInput.y + transform.right * moveInput.x;
        desiredVelocity *= speed;

        rb.velocity = new Vector3(desiredVelocity.x, rb.velocity.y, desiredVelocity.z);

        // Jump Input
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void Jump()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 1.2f))
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }
}
