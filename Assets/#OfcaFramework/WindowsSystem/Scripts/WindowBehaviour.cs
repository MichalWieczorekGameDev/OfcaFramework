using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class WindowBehaviour : MonoBehaviour
{
    [SerializeField] Image topBar;
    [SerializeField] Image windowBackgroundRectangle;

    [SerializeField] string windowName = "WindowName";
    [SerializeField] TextMeshProUGUI windowTitleTMP;

    [SerializeField] Color topBarColor;
    [SerializeField] Color windowBackgroundColor;

    [SerializeField] Transform dataContainer;

    [SerializeField] UnityEvent onDestroyEvent;
    private void OnValidate()
    {
        UpdateWindowColors(topBarColor, windowBackgroundColor);
        windowTitleTMP.text = windowName;
    }

    private void UpdateWindowColors(Color _topBarColor, Color _windowBackgroundColor)
    {
        topBar.color = _topBarColor;
        windowBackgroundRectangle.color = _windowBackgroundColor;
    }

    private void UpdateWindowName(string _windowName)
    {
        windowName = _windowName;
        gameObject.name = "Window[" + windowName + "]";
        windowTitleTMP.text = windowName;
    }

    public void SetUp(GameObject _dataGameObject, string _windowName, Color _windowColor)
    {
        _dataGameObject.transform.SetParent(dataContainer, false);
        ResizeWindowBasedOnDataGameObject(_dataGameObject);
        UpdateWindowColors(_windowColor);
        UpdateWindowName(_windowName);
    }

    private void UpdateWindowColors(Color _color)
    {
        var _darkerColor = new Color(_color.r - 0.25F, _color.g - 0.25F, _color.b - 0.25F, 1F);
        UpdateWindowColors(_darkerColor, _color);
    }

    private void ResizeWindowBasedOnDataGameObject(GameObject _dataGameObject)
    {
        RectTransform _dataObjectRectTransform = _dataGameObject.GetComponent<RectTransform>();
        var _windowRectTransform = GetComponent<RectTransform>();
        _windowRectTransform.sizeDelta = _dataObjectRectTransform.sizeDelta;
    }

    private void OnDestroy()
    {
        onDestroyEvent?.Invoke();
    }

    public string GetWindowName()
    {
        return windowName;
    }
}
