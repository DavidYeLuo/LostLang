using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class PlayerInput : EntityComponent
    {
        DataReference<Vector3> playerMoveDirection;
        DataReference<float> playerMoveSpeed;
        protected override void Start()
        {
            base.Start();
            playerMoveSpeed.SetData(10);
        }
        private void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector3 inputVector = new Vector3(horizontal, 0, vertical);
            //float speed = inputVector.magnitude;
            Vector3 direction = inputVector.normalized;

            playerMoveDirection.SetData(direction);
            //playerMoveSpeed.SetData(1);
        }

        protected override void InitData()
        {
            playerMoveDirection = entityData.GetVector3Reference(GameConstants.Vector3DataReference.InputDirection);
            playerMoveSpeed = entityData.GetFloatReference(GameConstants.FloatDataReference.MoveSpeed);
        }
    }
}
