using System.Collections.Generic;
using UnityEngine;

public class TopDownMovementKinematic : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] ContactFilter2D contactFilter;
 
    Vector2 moveInput;
    List<RaycastHit2D> results = new List<RaycastHit2D>();
    Rigidbody2D rb;
 
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
 
    public void FixedUpdate()
    {
        moveInput = new Vector2(
            Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")
        );
        
        MovePlayer(moveInput);
    }
 
    // Tries to move the player in a direction by casting in that direction
    public void MovePlayer(Vector2 direction)
    {
        // Check for potential collisions
        int count = rb.Cast(
            direction, // X and Y values between -1 and 1 that represent the direction from the body to look for collisions
            contactFilter, // The settings that determine where a collision can occur on such as layers to collide with
            results, // List of collisions to store the found collisions into after the Cast is finished
            moveSpeed * Time.fixedDeltaTime); // The amount to cast equal to the movement
 
        if (count == 0)
        {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            foreach (RaycastHit2D hit in results)
            {
                rb.MovePosition(
                    rb.position + direction * moveSpeed * Time.fixedDeltaTime
                    + hit.normal * hit.distance
                );
                print(hit.ToString());
            }
        }
    }
}