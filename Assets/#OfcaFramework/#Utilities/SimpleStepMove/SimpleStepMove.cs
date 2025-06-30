using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using com.cyborgAssets.inspectorButtonPro;
using UnityEditor;
using DG.Tweening;

public class SimpleStepMove : MonoBehaviour
{
    public enum AnimationLoopingMode
    {
        NoLoop,
        Loop,
        TeleportToStartAfterFinish,
        TeleportToStartOnEndPoint,
        Yoyo
    }

    [SerializeField] List<VisualStep> listOfSteps;
    [SerializeField] GameObject visualStepPrefab;
    [SerializeField] Gradient stepsColorGradient;
    [SerializeField] List<Color> gradientColorsList;

    [SerializeField] Transform transformToAnimate;

    [SerializeField] bool loopedMode = false;
    [SerializeField] int currentStep = 0;
    [SerializeField] float stepTime = 1F;
    [SerializeField] Ease easeType = Ease.Linear;
    [SerializeField] AnimationLoopingMode loopingMode = AnimationLoopingMode.NoLoop;
    [SerializeField] float cooldown = 0f;

    private void Update()
    {
        if (cooldown > 0f)
        {
            cooldown -= Time.deltaTime;
        }
    }

    [ProButton]
    public void NextStep()
    {

        if (transformToAnimate != null && cooldown <= 0f)
        {
            //Loop
            float newStepTime = listOfSteps[GetNextStep()].GetStepTime();
            Ease newEase = listOfSteps[GetNextStep()].GetEaseType();

            transformToAnimate.DOMove(listOfSteps[GetNextStep()].transform.position,
                newStepTime).SetEase(newEase);


            cooldown = newStepTime;
            currentStep = GetNextStep();
        }
    }

    [ProButton]
    public void TransformToAnimateToStepZero()
    {
        if (listOfSteps.Count > 0)
        {
            transformToAnimate.transform.position = listOfSteps[0].transform.position;
        }
    }

    private int GetNextStep()
    {
        int step = 0;
        if (currentStep < listOfSteps.Count - 1)
        {
            step = currentStep + 1;
        }
        return step;
    }

    [ProButton]
    public void AddNextStep()
    {
        VisualStep step = Instantiate(visualStepPrefab,transform).GetComponent<VisualStep>();
        listOfSteps.Add(step);
        step.setChildNumber(listOfSteps.Count-1);
        step.gameObject.name = "Step[" + (listOfSteps.Count - 1) + "]";
        step.SetEaseType(easeType);
        step.SetStepTime(stepTime);

        if (listOfSteps.Count > 1)
        {
            step.transform.position = listOfSteps[step.getChildNumber() - 1].transform.position;
        }

        //setting next step transform
        if (listOfSteps.Count > 1)
        {
            listOfSteps[step.getChildNumber() - 1].SetNextVisualStepTransform(step.transform);
        }
        UpdateLoopedVisuals();

        if (stepsColorGradient != null)
        {
            UpdateStepsColors();
        }
        
        if (listOfSteps.Count > 1)
        {
            Selection.activeGameObject = step.gameObject;
        }
        step.SetShowChildNumber(listOfSteps[0].GetShowChildNumber());
    }

    private void UpdateStepsColors()
    {
        int colorsCount = listOfSteps.Count + listOfSteps.Count - 1;
        
        gradientColorsList.Clear();

        float colorStep = 1F / colorsCount;

        for (int i = 0; i < colorsCount; i++)
        {
            float time = i * colorStep;
            Debug.Log($"Color time (0-1): {time}");
            Color newColor = stepsColorGradient.Evaluate(time);
            gradientColorsList.Add(newColor);
        }

        foreach (VisualStep step in listOfSteps)
        {
            //setting sphere color
            step.SetSphereGizmoColor(gradientColorsList[step.getChildNumber()*2]);

            //setting line color
            if (step.getChildNumber() * 2 + 1 == gradientColorsList.Count)
            {
                step.SetLineGizmoColor(gradientColorsList[step.getChildNumber() * 2]);
            }
            else
            {
                step.SetLineGizmoColor(gradientColorsList[step.getChildNumber() * 2 + 1]);
            }
        }
    }

    [ProButton]
    public void DeleteAllChildrenSteps()
    {
        listOfSteps.Clear();
        while (transform.childCount > 0)
        {
            GameObject.DestroyImmediate(transform.GetChild(0).gameObject);
        }
        gradientColorsList.Clear();
    }

    [ProButton]
    public void ChangeChildNumbersVisibleState()
    {
        if (listOfSteps.Count > 0)
        {
            bool currentVisibleState = listOfSteps[0].GetShowChildNumber();
            foreach (VisualStep step in listOfSteps)
            {
                step.SetShowChildNumber(!currentVisibleState);
            }
        }
    }

    [ProButton]
    public void ChangeLoopedMode()
    {
        loopedMode = !loopedMode;

        UpdateLoopedVisuals();
    }

    private void UpdateLoopedVisuals()
    {
        if (loopedMode && listOfSteps.Count > 1)
        {
            listOfSteps[listOfSteps.Count - 1].SetNextVisualStepTransform(listOfSteps[0].transform);
        }
        else
        {
            listOfSteps[listOfSteps.Count - 1].SetNextVisualStepTransform(null);
        }
    }
}
