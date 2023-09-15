
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float horizontalSpeed = 5.0f; // Adjust this speed factor as needed
    public float minX = -7.0f; // Minimum x position
    public float maxX = 7.0f; // Maximum x position
    public Animation anim;
    public bool isdead = false;

    private void Start()
    {
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput * horizontalSpeed * Time.deltaTime, 0, 0);

        // Update the x position while clamping it within the specified bounds
        float newX = Mathf.Clamp(transform.position.x + movement.x, minX, maxX);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        
    }

private void OnCollisionEnter(Collision collision)
{
    // Check if the colliding object has the "taxi" tag
    if (collision.gameObject.CompareTag("Taxi"))
    {
        // Destroy the game object when colliding with a "taxi"
        Destroy(gameObject);
            isdead = true;
    }
}

}
