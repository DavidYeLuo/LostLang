using System.Collections;
using System.Collections.Generic;
using GameConstants;
using UnityEngine;

namespace Item
{
    public class ResourceObject : MonoBehaviour
    {
        [SerializeField] private List<ResourceType> typeOfResources;
        [SerializeField] private List<ResourceType> masterResources;
    };
}
