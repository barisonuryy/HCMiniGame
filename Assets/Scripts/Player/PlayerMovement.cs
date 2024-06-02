using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(CharacterController))] 
public class PlayerMovement : MonoBehaviour
{
    public Camera playerCamera;
    public float gravity = -9.81f;
    public float moveSpeed = 5f;
    public float rotationSpeed = 720f; 
    private float verticalVelocity; 
    private bool isGrounded;

    private CharacterController characterController;
    private IInputHandler inputHandler;
    private IMovementHandler movementHandler;
    private IRotationHandler rotationHandler;
    private Vector2 movementInput, lookInput,direction,rotateDirection;
    public Vector3 movement;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        inputHandler = new InputHandler();
        movementHandler = new MovementHandler();
        rotationHandler = new RotationHandler();
    }
    
    void Update()
    {
        isGrounded = characterController.isGrounded;

        if (isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f; // Karakterin yerde kalması için negatif değer verdim
        }
     
     
        movementInput = inputHandler.GetMovementInput();
        lookInput = inputHandler.GetLookInput();
        Vector3 cameraForward = playerCamera.transform.forward;
        Vector3 cameraRight = playerCamera.transform.right;

        // Amacım burada kameranın baktığı yöne doğru hareketleri tanımlamak
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();
        
        Vector3 moveDirection = cameraForward * movementInput.y + cameraRight* movementInput.x;
        
      movement = moveDirection *moveSpeed* Time.deltaTime;
      verticalVelocity += gravity * Time.deltaTime;
      movement.y = verticalVelocity;
     
        movementHandler.Move(characterController, new Vector2(movement.x,movement.z), moveSpeed);
        characterController.Move(Vector3.up * movement.y);
        rotationHandler.Rotate(transform,new Vector2(movement.x,movement.z),rotationSpeed, Time.deltaTime);
    }
    
   
}
