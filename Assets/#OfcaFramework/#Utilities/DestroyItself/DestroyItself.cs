using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OfcaFramework
{
    namespace Utilities
    {
        public class DestroyItself : MonoBehaviour
        {
            [SerializeField] GameObject gameObjectToDestroy;

            private void Awake()
            {
                if (gameObjectToDestroy != null)
                {
                    gameObjectToDestroy = gameObject;
                }
            }

            public void DestroyGameObject()
            {
                Destroy(gameObjectToDestroy);
            }
        }
    }
}

