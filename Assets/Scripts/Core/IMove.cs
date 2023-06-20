using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public interface IMove
    {
        public void SetDirection(Vector3 direction);
        public void SetSpeed(float speed);
    }
}
