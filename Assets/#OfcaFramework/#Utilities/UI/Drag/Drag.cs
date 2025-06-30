using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace OfcaFramework
{
    namespace Utilities
    {
        namespace UI
        {
            public class Drag : MonoBehaviour, IDragHandler
            {
                [SerializeField] Transform transformToDrag;
                [SerializeField] float xOffset = 0;
                [SerializeField] float yOffset = 0;

                public void SetXOffset(float _newOffset)
                {
                    xOffset = _newOffset;
                }

                public void SetYOffset(float _newOffset)
                {
                    yOffset = _newOffset;
                }
                public void OnDrag(PointerEventData _eventData)
                {
                    transformToDrag.position = _eventData.position + new Vector2(xOffset, yOffset);
                }
            }
        }
    }
}