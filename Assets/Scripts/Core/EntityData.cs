using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GameConstants;

namespace Core
{
    public class EntityData : MonoBehaviour
    {
        [Header("Initialize")]
        [SerializeField] private bool health;
        [SerializeField] private bool maxHealth;
        [Space]
        [SerializeField] private bool moveSpeed;
        [SerializeField] private bool moveDirection;

        // Entity Data
        private Dictionary<IntDataReference, DataReference<int>> intReferences;
        private Dictionary<BoolDataReference, DataReference<bool>> boolReferences;
        private Dictionary<FloatDataReference, DataReference<float>> floatReferences;
        private Dictionary<Vector3DataReference, DataReference<Vector3>> vector3Reference;

        // Events
        private Dictionary<ActionReference, Action> entityActions;

        private void Awake()
        {
            // Initialize Dictionaries
            intReferences = new Dictionary<IntDataReference, DataReference<int>>();
            boolReferences = new Dictionary<BoolDataReference, DataReference<bool>>();
            floatReferences = new Dictionary<FloatDataReference, DataReference<float>>();
            vector3Reference = new Dictionary<Vector3DataReference, DataReference<Vector3>>();
            entityActions = new Dictionary<ActionReference, Action>();

            // Initialize References
            if (health) intReferences.Add(IntDataReference.Health, new DataReference<int>());
            if (maxHealth) intReferences.Add(IntDataReference.MaxHealth, new DataReference<int>());
            if (moveSpeed) floatReferences.Add(FloatDataReference.MoveSpeed, new DataReference<float>());
            if (moveDirection) vector3Reference.Add(Vector3DataReference.InputDirection, new DataReference<Vector3>());
        }

        public DataReference<int> GetIntReference(IntDataReference referenceName)
        {
            DataReference<int> data;
            intReferences.TryGetValue(referenceName, out data);
            return data;
        }
        public DataReference<bool> GetBoolReference(BoolDataReference referenceName)
        {
            DataReference<bool> data;
            boolReferences.TryGetValue(referenceName, out data);
            return data;
        }
        public DataReference<float> GetFloatReference(FloatDataReference referenceName)
        {
            DataReference<float> data;
            floatReferences.TryGetValue(referenceName, out data);
            return data;
        }
        public DataReference<Vector3> GetVector3Reference(Vector3DataReference referenceName)
        {
            DataReference<Vector3> data;
            vector3Reference.TryGetValue(referenceName, out data);
            return data;
        }
        public Action GetActionReference(ActionReference referenceName)
        {
            Action data;
            entityActions.TryGetValue(referenceName, out data);
            return data;
        }
    }
}
