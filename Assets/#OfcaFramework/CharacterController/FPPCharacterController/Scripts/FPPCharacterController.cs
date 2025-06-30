using OfcaFramework.ScriptableWorkflow;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPPCharacterController : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Transform playerHead;
    [SerializeField] private Vector3 playerVelocity;
    [SerializeField] private bool groundedPlayer;
    [SerializeField] private float playerWalkSpeed = 4.0f;
    [SerializeField] private float playerRunSpeed = 7.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] float gravityValue = -9.81f;

    //Scriptable Input Variables
    [SerializeField] private ScriptableBoolVariable jumpInput;
    [SerializeField] private ScriptableBoolVariable runInput;
    [SerializeField] private ScriptableVector2Variable mouseMovement;
    [SerializeField] private ScriptableVector2Variable directionalMovement;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerHead = Camera.main.transform;
    }

    private void Update()
    {
        groundedPlayer = characterController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = directionalMovement.Value;
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        move = playerHead.forward * move.z + playerHead.right * move.x;
        move.y = 0f;
        if(!runInput.Value)
        {
            characterController.Move(move * Time.deltaTime * playerWalkSpeed);
        }
        else
        {
            characterController.Move(move * Time.deltaTime * playerRunSpeed);
        }

        //if (move != Vector3.zero)
        //{
        //    gameObject.transform.forward = move;
        //}

        if (jumpInput.Value && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(playerVelocity*Time.deltaTime);

    }
}
