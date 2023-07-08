using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class Jumper : EntityComponent
{
    private GameObject jumpObject;
    private DataReference<float> jumpForce;

    private float _jumpForce;
    private Rigidbody rb;
    protected override void InitData()
    {
        jumpObject = transform.root.gameObject;
        jumpForce = entityData.GetFloatReference(GameConstants.FloatDataReference.JumpForce);
        _jumpForce = jumpForce.GetData();

        rb = jumpObject.GetComponent<Rigidbody>();
    }

    protected override void Subscribe()
    {
        jumpForce.onDataChange += OnJumpForceChange;
    }
    protected override void Unsubscribe()
    {
        jumpForce.onDataChange -= OnJumpForceChange;
    }

    private void OnJumpForceChange()
    {
        _jumpForce = jumpForce.GetData();
    }

    private void OnJump()
    {
        // TODO: Gather info: IsGrounded?
        // TODO: Add input to trigger the jump
        rb.AddForce(_jumpForce * jumpObject.transform.up);
    }
}
