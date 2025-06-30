using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OfcaFramework
{
    namespace CharacterController
    {
        public class CharacterControllerProcessor : MonoBehaviour
        {
            [SerializeField] string processorName;
            private void FixedUpdate()
            {
                //Debug.Log($"{processorName} initalised.");
            }
            public string GetProcessorName()
            {
                return processorName;
            }
        }
    }
}