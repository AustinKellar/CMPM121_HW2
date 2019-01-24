using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float ForwardMovement { get; private set; }
    public float RotationalMovement { get; private set; }
    public bool IsSprinting { get; private set; }
    public bool Jump { get; private set; }
    

    private void Update()
    {
        ForwardMovement = Input.GetAxisRaw("Vertical");
        RotationalMovement = Input.GetAxis("Horizontal");

        IsSprinting = Input.GetKey(KeyCode.LeftShift);
        Jump = Input.GetKeyDown(KeyCode.Space);
    }
}
