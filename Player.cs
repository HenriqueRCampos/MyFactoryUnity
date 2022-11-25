using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController playerCC;
    
    Vector3 forward;
    Vector3 strafe;
    Vector3 vertical;

    public float forwardSpeed = 5f;
    public float strafeSpeed = 5f;

    public float maxJumpHeight = 2;
    float gravity;
    float jumpForce;
    float timeToMaxHeight = 0.65f;

    // Start is called before the first frame update
    void Start()
    {
        playerCC = GetComponent<CharacterController>();

        gravity = (-3.5f * maxJumpHeight) / (timeToMaxHeight * timeToMaxHeight);
        jumpForce = (2 * maxJumpHeight) / timeToMaxHeight;
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxisRaw("Vertical");
        float strafeInput = Input.GetAxisRaw("Horizontal");

        vertical += gravity * Time.deltaTime * Vector3.up;

        if (playerCC.isGrounded)
        {
            vertical = Vector3.down;

            forward = forwardInput * forwardSpeed * transform.forward;
            strafe = strafeInput * strafeSpeed * transform.right;
        }

        if (Input.GetKeyDown(KeyCode.Space) && playerCC.isGrounded)
        {
            vertical = jumpForce * Vector3.up;
        }

        if (vertical.y > 0 && (playerCC.collisionFlags & CollisionFlags.Above) != 0)
        {
            vertical = Vector3.zero;
        }

        Vector3 finalVelocity = forward + strafe + vertical;

        playerCC.Move(finalVelocity * Time.deltaTime);
    }

}
