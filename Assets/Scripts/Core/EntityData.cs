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
        [SerializeField] private bool walkSpeed;
        [SerializeField] private bool runSpeed;

        // Entity Data
        private Dictionary<IntDataReference, DataReference<int>> intReferences;
        private Dictionary<BoolDataReference, DataReference<bool>> boolReferences;
        private Dictionary<FloatDataReference, DataReference<float>> floatReferences;

        // Events
        private Dictionary<ActionReference, Action> entityActions;

        private void Awake()
        {
            // Initialize Dictionaries
            intReferences = new Dictionary<IntDataReference, DataReference<int>>();
            boolReferences = new Dictionary<BoolDataReference, DataReference<bool>>();
            floatReferences = new Dictionary<FloatDataReference, DataReference<float>>();
            entityActions = new Dictionary<ActionReference, Action>();

            // Initialize References
            if (health) intReferences.Add(IntDataReference.Health, new DataReference<int>());
            if (maxHealth) intReferences.Add(IntDataReference.MaxHealth, new DataReference<int>());
            if (walkSpeed) floatReferences.Add(FloatDataReference.WalkSpeed, new DataReference<float>());
            if (runSpeed) floatReferences.Add(FloatDataReference.RunSpeed, new DataReference<float>());
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
        public Action GetActionReference(ActionReference referenceName)
        {
            Action data;
            entityActions.TryGetValue(referenceName, out data);
            return data;
        }
    }
}
