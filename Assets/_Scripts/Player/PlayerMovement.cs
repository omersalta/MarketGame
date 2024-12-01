using System;
using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerMovement : RigidBodyMovementWithRotation
    {
        private void Update()
        {
            OnMove(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        }
    }
}