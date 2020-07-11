using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;

    private ChangeKey inputManager;
    private float horizontalAxis;
    private float verticalAxis;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        inputManager = GameObject.Find("InputManager").GetComponent<ChangeKey>();
    }

    void Update()
    {
        KeysToAxis();

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(horizontalAxis, 0, verticalAxis);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // jumps when jump button is pressed
        if (Input.GetKeyDown(inputManager.jump) && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    /// <summary>
    /// convert inputs pressed to axis for movement
    /// </summary>
    private void KeysToAxis()
    {
        verticalAxis = 0;
        horizontalAxis = 0;

        //vertical axis is 0 by default, 1 when up is pressed, -1 when down is pressed, and 0 when both are pressed
        if (Input.GetKey(inputManager.up))
        {
            verticalAxis += 1;
        }
        if (Input.GetKey(inputManager.down))
        {
            verticalAxis -= 1;
        }
        
        //horizontal axis is 0 by default, 1 when right is pressed, -1 when left is pressed, and 0 when both are pressed
        if (Input.GetKey(inputManager.right))
        {
            horizontalAxis += 1;
        }
        if (Input.GetKey(inputManager.left))
        {
            horizontalAxis -= 1;
        }
    }
}