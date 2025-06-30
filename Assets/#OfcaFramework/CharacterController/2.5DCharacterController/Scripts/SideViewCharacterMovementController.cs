using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace OfcaFramework
{
    namespace CharacterController
    {
        public class SideViewCharacterMovementController : CharacterControllerProcessor, ICharacterControllerOnAwake, ICharacterControllerOnEnable, ICharacterControllerOnDisable, ICharacterControllerOnUpdate
        {
            //INPUT REFERENCES
            [SerializeField] SriptableSideViewCharacterControllerPlayerInputReader inputReader;

            //MOVEMENT
            [SerializeField] Vector2 currentMovementInput;
            [SerializeField] Vector3 currentMovement;
            [SerializeField] bool isMovementPressed;
            [SerializeField] float currentMovementSpeed = 1.0f;

            //GRAVITY
            [SerializeField] float gravityForce = -9.8f;
            [SerializeField] float groundedGravityForce = -0.5f;

            //JUMPING
            [SerializeField] bool isJumpPressed = false;
            [SerializeField] float initialJumpVelocity;
            [SerializeField] float maxJumpHeight = 1.0f;
            [SerializeField] float maxJumpTime = 0.5f;
            [SerializeField] bool isJumping = false;

            [SerializeField] UnityEngine.CharacterController characterController;

            public void OnAwakeInvoke()
            {
                SetUpJumpVariables();
            }
            public void OnDisableInvoke()
            {
                inputReader.moveStartedEvent -= OnMovementInput;
                inputReader.movePerformedEvent -= OnMovementInput;
                inputReader.moveCanceledEvent -= OnMovementInput;
                inputReader.jumpStartedEvent -= OnJumpStartedInput;
                inputReader.jumpCanceledEvent -= OnJumpCanceledInput;
            }

            public void OnEnableInvoke()
            {
                inputReader.moveStartedEvent += OnMovementInput;
                inputReader.movePerformedEvent += OnMovementInput;
                inputReader.moveCanceledEvent += OnMovementInput;
                inputReader.jumpStartedEvent += OnJumpStartedInput;
                inputReader.jumpCanceledEvent += OnJumpCanceledInput;
            }

            public void OnUpdateInvoke()
            {
                UpdateMovement();
                UpdateGravity();
                UpdateJump();
            }

            void UpdateMovement()
            {
                characterController.Move(currentMovement * Time.deltaTime * currentMovementSpeed);
            }

            void UpdateJump()
            {
                if (!isJumping && characterController.isGrounded && isJumpPressed)
                {
                    isJumping = true;
                    currentMovement.y = initialJumpVelocity * 0.5f;
                }
                else if(!isJumpPressed && isJumping && characterController.isGrounded)
                {
                    isJumping = false;
                }
            }

            void UpdateGravity()
            {
                bool isFalling = currentMovement.y <= 0.0f || !isJumpPressed;
                float fallMultiplier = 2.0f;

                if (characterController.isGrounded)
                {
                    currentMovement.y = groundedGravityForce;
                }
                else if (isFalling)
                {
                    float previousYVelocity = currentMovement.y;
                    float newYVelocity = currentMovement.y + (gravityForce * fallMultiplier * Time.deltaTime);
                    float nextYVelocity = Mathf.Max((previousYVelocity + newYVelocity) * 0.5f, -20f);
                    currentMovement.y = nextYVelocity;
                }
                else
                {
                    float previousYVelocity = currentMovement.y;
                    float newYVelocity = currentMovement.y + (gravityForce * Time.deltaTime);
                    float nextVelocity = (previousYVelocity + newYVelocity) * 0.5f;
                    currentMovement.y = nextVelocity;
                }
            }

            void OnJumpStartedInput()
            {
                isJumpPressed = true;
            }

            void OnJumpCanceledInput()
            {
                isJumpPressed = false;
            }



            void OnMovementInput(Vector2 moveVector)
            {
                currentMovementInput = moveVector;
                currentMovement.x = currentMovementInput.x;
                isMovementPressed = currentMovementInput.x != 0;
            }

            void SetUpJumpVariables()
            {
                float timeToApex = maxJumpTime / 2;
                gravityForce = (-2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
                initialJumpVelocity = (2 * maxJumpHeight) / timeToApex;
            }
        }
    }
}