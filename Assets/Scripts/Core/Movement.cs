using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Movement : EntityComponent 
    {
        private GameObject moveObject;
        DataReference<float> moveSpeed;
        DataReference<Vector3> inputDirection;

        float _moveSpeed;
        Vector3 _direction;

        protected override void InitData()
        {
            moveObject = transform.root.gameObject;

            moveSpeed = entityData.GetFloatReference(GameConstants.FloatDataReference.MoveSpeed);
            inputDirection = entityData.GetVector3Reference(GameConstants.Vector3DataReference.InputDirection);
            _moveSpeed = moveSpeed.GetData();
        }

        protected override void Subscribe()
        {
            moveSpeed.onDataChange += OnMoveSpeedChange;
        }
        protected override void Unsubscribe()
        {
            moveSpeed.onDataChange -= OnMoveSpeedChange;
        }

        private void OnMoveSpeedChange()
        {
            _moveSpeed = moveSpeed.GetData();
        }

        void FixedUpdate()
        {
            _direction = inputDirection.GetData();
            Vector3 newDirection = Vector3.Scale(_direction, moveObject.transform.forward).normalized;
            moveObject.transform.position += _moveSpeed * _direction;
        }
    }
}
