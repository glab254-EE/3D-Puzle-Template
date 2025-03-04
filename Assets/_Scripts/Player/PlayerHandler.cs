using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerHandler : MonoBehaviour
{
    [SerializeField] private Transform CameraTransform;
    [SerializeField] private float UPLookBounds = 45;
    [SerializeField] private float DOWNLookBounds = 55;
    [SerializeField] private float MoveSpeed = 5f;
    [SerializeField] private float MouseSensitivity = 5f;
    [SerializeField] private float JumpForce = 50f;
    private PlayerInputActions inputActions;
    private Rigidbody rb;
    private Vector2 movementVector;
    bool cameraLocked = true;
    private bool IsOnGround()
    {
        if (Physics.Raycast(transform.position-new Vector3(0,transform.localScale.y/2,0),Vector3.down,out RaycastHit hitInfo) == true)
        {
            if (hitInfo.distance <= transform.localScale.y && hitInfo.collider != null){
                return true;
            }
        } 
        return false;
    }
    private void OnJump(InputAction.CallbackContext action)
    {
        if (IsOnGround()){
            rb.AddForce(Vector3.up*JumpForce);
        }
    }
    private void OnMovementChange(InputAction.CallbackContext action)
    {
        Vector2 vector2 = action.ReadValue<Vector2>();
        if (vector2 != null){
            movementVector = vector2;
        }
    }
    private void OnMouseMove(InputAction.CallbackContext action)
    {
        Vector2 look = action.ReadValue<Vector2>();
        if (look != null && cameraLocked){
            transform.Rotate(new Vector3(0,look.x*MouseSensitivity,0));
            CameraTransform.localRotation = Quaternion.Euler(CameraTransform.rotation.eulerAngles.x,0,0);
            CameraTransform.Rotate(look.y*MouseSensitivity*-1,0,0);
            float newXAngle = CameraTransform.rotation.eulerAngles.x + look.y*MouseSensitivity*-1;
            if (newXAngle < 360-UPLookBounds && newXAngle > 180)
            {
                CameraTransform.rotation = Quaternion.Euler(360-UPLookBounds,CameraTransform.rotation.eulerAngles.y,0);
            } else if (newXAngle > DOWNLookBounds && newXAngle < 360-UPLookBounds)
            {
                CameraTransform.rotation = Quaternion.Euler(DOWNLookBounds,CameraTransform.rotation.eulerAngles.y,0);
            } else 
            {
                CameraTransform.Rotate(look.y*MouseSensitivity*-1,0,0);
            }
        }
    }
    private void OnLockKeyPress(InputAction.CallbackContext action)
    {
        cameraLocked = !cameraLocked;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        inputActions = new();
        inputActions.InGame.Jump.performed += OnJump;
        inputActions.InGame.Camera_Movement.performed += OnMouseMove;
        inputActions.InGame.Movement.performed += OnMovementChange;
        inputActions.InGame.Movement.canceled += OnMovementChange;
        inputActions.InGame.MouseLock.performed += OnLockKeyPress;
        inputActions.InGame.Enable();
    }
    void Update()
    {
        if (cameraLocked && Cursor.lockState != CursorLockMode.Locked) Cursor.lockState = CursorLockMode.Locked;
        else if (!cameraLocked && Cursor.lockState != CursorLockMode.None) Cursor.lockState = CursorLockMode.None;
        rb.velocity = new Vector3(0,rb.velocity.y,0) + transform.forward * movementVector.y * MoveSpeed + transform.right * movementVector.x * MoveSpeed;
    }
    void OnDestroy()
    {
        inputActions.InGame.Jump.performed -= OnJump;
        inputActions.InGame.Camera_Movement.performed -= OnMouseMove;
        inputActions.InGame.Movement.performed -= OnMovementChange;
        inputActions.InGame.Movement.canceled -= OnMovementChange;  
        inputActions.InGame.MouseLock.performed -= OnLockKeyPress; 
        inputActions.InGame.Disable();     
    }
}
