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

        private Rigidbody rb;

        private float _moveSpeed;
        Vector3 _direction;

        protected override void InitData()
        {
            moveObject = transform.root.gameObject;

            moveSpeed = entityData.GetFloatReference(GameConstants.FloatDataReference.MoveSpeed);
            inputDirection = entityData.GetVector3Reference(GameConstants.Vector3DataReference.InputDirection);
            _moveSpeed = moveSpeed.GetData();

            rb = moveObject.GetComponent<Rigidbody>();
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
            Vector3 moveDirection = moveObject.transform.forward * _direction.z + moveObject.transform.right * _direction.x;
            float currentMoveSpeed = new Vector3(rb.velocity.x, 0,  rb.velocity.z).magnitude;
            if (currentMoveSpeed < _moveSpeed)
                currentMoveSpeed = _moveSpeed;
            rb.velocity = currentMoveSpeed * moveDirection + rb.velocity.y * Vector3.up;
        }
    }
}
