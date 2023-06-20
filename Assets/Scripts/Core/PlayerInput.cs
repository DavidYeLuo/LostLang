using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class PlayerInput : EntityComponent
    {
        DataReference<Vector3> playerMoveDirection;
        DataReference<float> playerMoveSpeed;
        private void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector3 inputVector = new Vector3(horizontal, 0, vertical);
            float speed = inputVector.magnitude;
            Vector3 direction = inputVector.normalized;

            playerMoveDirection.SetData(direction);
            playerMoveSpeed.SetData(speed);
        }

        protected override void InitData()
        {
            playerMoveDirection = entityData.GetVector3Reference(GameConstants.Vector3DataReference.InputDirection);
            playerMoveSpeed = entityData.GetFloatReference(GameConstants.FloatDataReference.MoveSpeed);
        }
    }
}
