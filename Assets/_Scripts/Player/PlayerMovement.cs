using System;
using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerMovement : RigidBodyMovementWithRotation
    {
        protected Vector3 lastMoveDir;
        
        protected void Update()
        {
            //Get Input
            Vector2 moveDir = GetMovementDirAsNormalized();
            OnMove(moveDir);
            
            if (moveDir != Vector2.zero)
            {
                lastMoveDir = moveDir;
            }
        }


        private Vector2 GetMovementDirAsNormalized()
        {
            return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
    }
}