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

    private UIController uIController;
    private GameController gameController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        uIController = UIController.instance;
        if (uIController == null)
            throw new System.Exception("No UIController present");

        gameController = GameController.instance;
        if (gameController == null)
            throw new System.Exception("No GameController present");

        Cursor.lockState = CursorLockMode.Locked;
        uIController.SetCrosshairState(CrosshairState.Enabled);
    }

    void FixedUpdate()
    {
        // don't want to be moving or anything while a puzzle is engaged
        if (gameController.puzzleEngaged == true) return;

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
        float xRot = playerCamera.transform.eulerAngles.x;
        xRot = (xRot > 180) ? xRot - 360 : xRot;
        lookY = Mathf.Clamp(xRot + -lookY, -90.0f, 90.0f);
        playerCamera.transform.rotation = Quaternion.Euler(
            lookY,
            playerCamera.transform.eulerAngles.y,
            playerCamera.transform.eulerAngles.z
        );

        // look for interactable stuff
        RaycastHit hit;
        Vector3 origin = playerCamera.transform.position;
        float length = 2.0f;
        Vector3 castDirection = playerCamera.transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(origin, castDirection, out hit, length))
        {
            IInteractable obj = hit.transform.gameObject.GetComponent<IInteractable>() as IInteractable;
            if (obj != null)
            {
                uIController.SetCrosshairState(CrosshairState.Engaged);

                if (Input.GetButtonDown("Fire1"))
                {
                    obj.Interact();
                }
            }
            else
            {
                uIController.SetCrosshairState(CrosshairState.Enabled);
            }
        }
        else
        {
            uIController.SetCrosshairState(CrosshairState.Enabled);
        }
    }
}
