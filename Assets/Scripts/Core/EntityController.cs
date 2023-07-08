using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [RequireComponent(typeof(EntityData))]
    public abstract class EntityController : MonoBehaviour
    {
        protected EntityData entityData;

        protected virtual void Awake()
        {
            entityData = GetComponent<EntityData>();
        }
    }
}
