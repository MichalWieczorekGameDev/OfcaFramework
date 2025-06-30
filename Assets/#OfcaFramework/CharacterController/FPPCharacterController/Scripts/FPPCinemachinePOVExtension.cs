using UnityEngine;
using Cinemachine;
using OfcaFramework.ScriptableWorkflow;
public class FPPCinemachinePOVExtension : CinemachineExtension
{
    [SerializeField] private ScriptableVector2Variable headMovement;
    [SerializeField] private Vector3 startingRotation;

    [SerializeField] private float clampAngle = 80f;
    [SerializeField] private ScriptableFloatVariable horizontalSpeed;
    [SerializeField] private ScriptableFloatVariable verticalSpeed;
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow)
        {
            if(stage == CinemachineCore.Stage.Aim)
            {
                if (startingRotation == null)
                {
                    startingRotation = transform.localRotation.eulerAngles;
                }
                Vector2 deltaInput = headMovement.Value;
                startingRotation.x += deltaInput.x * verticalSpeed.Value * Time.deltaTime;
                startingRotation.y += deltaInput.y * horizontalSpeed.Value * Time.deltaTime;
                startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngle, clampAngle);
                state.RawOrientation = Quaternion.Euler(-startingRotation.y, startingRotation.x, 0f);
                
            }
        }
    }
}
