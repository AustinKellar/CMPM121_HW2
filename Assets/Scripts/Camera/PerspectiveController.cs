using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerspectiveController : MonoBehaviour
{
    [SerializeField]
    private float _transitionSpeed;

    [SerializeField]
    private Dropdown _perspectiveDropdown;

    [SerializeField]
    private Vector3 _firstPersonPosition;

    [SerializeField]
    private Vector3 _thirdPersonPosition;

    [SerializeField]
    private Vector3 _thirdPersonRotation;

    private Vector3 _destinationPosition;
    private Vector3 _destinationRotation;

    private void Update()
    {
        if (_perspectiveDropdown.value == 0)
        {
            _destinationPosition = _firstPersonPosition;
            _destinationRotation = Vector3.zero;
        }
        else
        {
            _destinationPosition = _thirdPersonPosition;
            _destinationRotation = _thirdPersonRotation;
        }
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.localPosition, _destinationPosition) < 0.01f)
        {
            transform.localPosition = _destinationPosition;
        }

        if (Vector3.Distance(transform.eulerAngles, _destinationRotation) < 0.01f)
        {
            transform.localEulerAngles = _destinationRotation;
        }

        if (transform.localPosition != _destinationPosition)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, _destinationPosition, _transitionSpeed);
        }

        if (transform.localEulerAngles != _destinationRotation)
        {
            transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, _destinationRotation, _transitionSpeed);
        }
    }
}
