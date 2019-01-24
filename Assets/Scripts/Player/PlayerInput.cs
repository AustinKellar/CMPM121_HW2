using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float ForwardMovement { get; private set; }
    public float SideMovement { get; private set; }

    private void Update()
    {
        ForwardMovement = Input.GetAxisRaw("Vertical");
        SideMovement = Input.GetAxisRaw("Horizontal");
    }
}
