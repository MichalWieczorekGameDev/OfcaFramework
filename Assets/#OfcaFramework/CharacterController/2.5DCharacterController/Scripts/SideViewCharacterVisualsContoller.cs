using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.ProBuilder.MeshOperations;

namespace OfcaFramework
{
    namespace CharacterController
    {
        public class SideViewCharacterVisualsContoller : CharacterControllerProcessor, ICharacterControllerOnFixedUpdate, ICharacterControllerOnEnable, ICharacterControllerOnDisable
        {
            [SerializeField] Transform visualsTransform;
            

            [SerializeField] Vector2 movementVector;
            [SerializeField] bool isLookingRight = true;

            [SerializeField] float rotationTime = 0f;

            //[SerializeField] InputActionReference moveAction;
            [SerializeField] SriptableSideViewCharacterControllerPlayerInputReader inputReader;


            private void UpdateMovementVector(Vector2 moveVector)
            {
                this.movementVector = moveVector;
            }

            public void OnFixedUpdateInvoke()
            {
                if (movementVector.x > 0f)
                {
                    isLookingRight = true;
                }
                else if (movementVector.x < 0f)
                {
                    isLookingRight = false;
                }

                if (isLookingRight)
                {
                    visualsTransform.eulerAngles = new Vector3(0f, 0f, 0f);
                }
                else
                {
                    visualsTransform.eulerAngles = new Vector3(0f, 180f, 0f);
                }
            }

            public void OnEnableInvoke()
            {
                inputReader.moveStartedEvent += UpdateMovementVector;
            }

            public void OnDisableInvoke()
            {
                inputReader.moveStartedEvent -= UpdateMovementVector;
            }
        }
    }
}
