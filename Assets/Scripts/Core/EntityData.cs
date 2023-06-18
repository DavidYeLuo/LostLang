using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
        private Dictionary<string, DataReference<int>> intReferences;
        private Dictionary<string, DataReference<bool>> boolReferences;
        private Dictionary<string, DataReference<float>> floatReferences;

        // Events
        private Dictionary<string, Action> entityActions;

        private void Awake()
        {
            // Initialize Dictionaries
            intReferences = new Dictionary<string, DataReference<int>>();
            boolReferences = new Dictionary<string, DataReference<bool>>();
            floatReferences = new Dictionary<string, DataReference<float>>();

            // Initialize References
            if (health) intReferences.Add("health", new DataReference<int>());
            if (maxHealth) intReferences.Add("maxHealth", new DataReference<int>());
            if (walkSpeed) floatReferences.Add("walkSpeed", new DataReference<float>());
            if (runSpeed) floatReferences.Add("runSpeed", new DataReference<float>());
        }

        public DataReference<int> GetIntReference(string referenceName)
        {
            DataReference<int> data;
            intReferences.TryGetValue(referenceName, out data);
            return data;
        }
        public DataReference<bool> GetBoolReference(string referenceName)
        {
            DataReference<bool> data;
            boolReferences.TryGetValue(referenceName, out data);
            return data;
        }
        public DataReference<float> GetFloatReference(string referenceName)
        {
            DataReference<float> data;
            floatReferences.TryGetValue(referenceName, out data);
            return data;
        }
        public Action GetActionReference(string referenceName)
        {
            Action data;
            entityActions.TryGetValue(referenceName, out data);
            return data;
        }
    }
}
