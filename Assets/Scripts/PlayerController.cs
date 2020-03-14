using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed;
    public float gravity;
    private CharacterController characterController;

    [Header("Look")]
    public float lookSpeed;
    public Camera playerCamera;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        // movement
        // get direction player wants to move in
        Vector3 direction = new Vector3();
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        // apply gravity
        if (!characterController.isGrounded)
        {
            direction.y = -gravity;
        }

        // apply movement
        Vector3 movement = transform.TransformDirection(direction.normalized * movementSpeed * Time.fixedDeltaTime);
        characterController.Move(movement);

        // looking
        float lookX = Input.GetAxis("Mouse X") * lookSpeed * Time.fixedDeltaTime;
        characterController.transform.rotation = Quaternion.Euler(
            characterController.transform.eulerAngles.x,
            characterController.transform.eulerAngles.y + lookX,
            characterController.transform.eulerAngles.z
        );

        float lookY = Input.GetAxis("Mouse Y") * lookSpeed * Time.fixedDeltaTime;
        lookY = Mathf.Clamp(lookY, -90.0f, 90.0f);
        playerCamera.transform.rotation = Quaternion.Euler(
            playerCamera.transform.eulerAngles.x + -lookY,
            playerCamera.transform.eulerAngles.y,
            playerCamera.transform.eulerAngles.z
        );
    }
}
