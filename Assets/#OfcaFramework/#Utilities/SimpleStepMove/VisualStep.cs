using UnityEditor;
using UnityEngine;
using DG.Tweening;

public class VisualStep : MonoBehaviour
{
    [SerializeField] Color gizmoSphereColor = Color.white;
    [SerializeField] Color gizmoLineColor = Color.white;
    [SerializeField] SimpleStepMove simpleStepMove;
    [SerializeField] int childNumber = 0;
    [SerializeField] Transform nextVisualStepTransform = null;
    [SerializeField] Texture circleTexture;
    [SerializeField] Ease easeType = Ease.Linear;
    [SerializeField] float stepTime = 1f;

    bool showChildNumber = true;

    public void SetEaseType(Ease _easeType)
    {
        easeType = _easeType;
    }

    public Ease GetEaseType()
    {
        return easeType;
    }

    public void SetStepTime(float _stepTime)
    {
        stepTime = _stepTime;
    }

    public float GetStepTime()
    {
        return stepTime;
    }

    public void SetSphereGizmoColor(Color newGizmoColor)
    {
        gizmoSphereColor = newGizmoColor;
    }

    public void SetLineGizmoColor(Color newGizmoColor)
    {
        gizmoLineColor = newGizmoColor;
    }

    public void SetSimpleStepMove(SimpleStepMove _simpleStepMove)
    {
        simpleStepMove = _simpleStepMove;
    }

    public void SetNextVisualStepTransform(Transform _nextVisualStepTransform)
    {
        nextVisualStepTransform = _nextVisualStepTransform;
    }

    public void setChildNumber(int _childNumber)
    {
        childNumber = _childNumber;
    }

    public int getChildNumber()
    {
        return childNumber;
    }

    public static Color InvertColor(Color color)
    {
        return new Color(1f - color.r, 1f - color.g, 1f - color.b, color.a);
    }

    public bool GetShowChildNumber()
    {
        return showChildNumber;
    }

    public void SetShowChildNumber(bool visibleStatus)
    {
        showChildNumber = visibleStatus;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoSphereColor;


        Gizmos.DrawSphere(transform.position, 0.2f);

        if (nextVisualStepTransform != null)
        {
            Gizmos.color = gizmoLineColor;
            Gizmos.DrawLine(transform.position, nextVisualStepTransform.position);
        }

        if (showChildNumber)
        {
            Handles.PositionHandle(transform.position, Quaternion.identity);

            GUIStyle labelStyle = null;

            if (labelStyle == null)
            {
                labelStyle = new GUIStyle(EditorStyles.label);
                labelStyle.fontSize = 20;
                labelStyle.normal.textColor = Color.white;//InvertColor(gizmoSphereColor);
            }

            //Handles.color = Color.black; // InvertColor(gizmoSphereColor);
            Handles.Label(transform.position + Vector3.up * 0.5f, "" + childNumber, labelStyle);
        }
    }
}
