using System.Collections;
using System.Collections.Generic;
using GameConstants;
using UnityEngine;

namespace Item
{
    public class ResourceObject : MonoBehaviour
    {
        [SerializeField] private List<ItemType> typeOfResources;
        [SerializeField] private List<ResourceType> typeOfResource;
        [SerializeField] private List<EquipmentType> typeOfEquipment;
        private ItemId<ItemType> _itemType;
        private ItemId<ResourceType> _resourceType;
        private ItemId<EquipmentType> _equipmentType;

        private void Start()
        {
            _itemType = new ItemId<ItemType>();
            _resourceType = new ItemId<ResourceType>();
            _equipmentType = new ItemId<EquipmentType>();
        }

        public GameObject PickUp()
        {

            return this.gameObject;
        }
    };
}
