using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class EntityComponent : MonoBehaviour
    {
        protected EntityData entityData;
        protected bool isInitialized = false;
        protected virtual void Start()
        {
            entityData = transform.root.GetComponent<EntityData>();
            if(entityData == null)
            {
                Debug.Log("Entity Data isn't found in the root game object");
            }
            InitData();
            Subscribe();
            isInitialized = true;
        }


        protected virtual void OnEnable()
        {
            _Subscribe();
        }
        protected virtual void OnDisable()
        {
            Unsubscribe();
        }
        protected virtual void InitData()
        {
        }
        protected virtual void Subscribe()
        {
        }
        protected virtual void Unsubscribe()
        {
        }
        private void _Subscribe()
        {
            if (!isInitialized) return;
            Subscribe();
        }
    }
}
