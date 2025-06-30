using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
namespace OfcaFramework
{
    namespace CharacterController
    {
        [CreateAssetMenu(fileName = "InputReader", menuName = "OfcaFramework/SideViewCharacterControllerPlayer", order = 1)]
        public class SriptableSideViewCharacterControllerPlayerInputReader : ScriptableObject, SideViewCharacterControllerPlayerInput.ICharacterControllsActions
        {
            public event UnityAction jumpStartedEvent = delegate { };
            public event UnityAction jumpCanceledEvent = delegate { };
            public event UnityAction<Vector2> moveStartedEvent = delegate { };
            public event UnityAction<Vector2> movePerformedEvent = delegate { };
            public event UnityAction<Vector2> moveCanceledEvent = delegate { };

            //Input C# script
            private SideViewCharacterControllerPlayerInput playerInput;

            private void OnEnable()
            {
                if (playerInput == null)
                {
                    playerInput = new SideViewCharacterControllerPlayerInput();

                    playerInput.CharacterControlls.Enable();
                    playerInput.CharacterControlls.SetCallbacks(this);
                }
            }

            public void DisableAllInput()
            {
                playerInput.CharacterControlls.Disable();
            }

            private void OnDisable()
            {
                DisableAllInput();
            }

            public void OnMove(InputAction.CallbackContext context)
            {
                if (context.phase == InputActionPhase.Started)
                    moveStartedEvent.Invoke(context.ReadValue<Vector2>());

                if (context.phase == InputActionPhase.Performed)
                    movePerformedEvent.Invoke(context.ReadValue<Vector2>());

                if (context.phase == InputActionPhase.Canceled)
                    moveCanceledEvent.Invoke(context.ReadValue<Vector2>());

                Debug.Log("OnMove Invoked");
            }

            public void OnJump(InputAction.CallbackContext context)
            {
                if (context.phase == InputActionPhase.Started)
                    jumpStartedEvent.Invoke();

                if (context.phase == InputActionPhase.Canceled)
                    jumpCanceledEvent.Invoke();

                Debug.Log("OnJump Invoked");
            }
        }
    }
}