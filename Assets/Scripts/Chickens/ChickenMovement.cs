using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMovement : MonoBehaviour
{

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _maxDestinationChangeCooldown;

    [SerializeField]
    private float _xRange;

    [SerializeField]
    private float _yRange;

    [SerializeField]
    private float _zRange;

    private Vector3 _destination;
    private float _lastDestinationChange;
    private float _cooldown;

    private void Start()
    {
        AssignRandomDestination();
        _cooldown = Random.Range(_maxDestinationChangeCooldown/2, _maxDestinationChangeCooldown);
    }

    private void Update()
    {
        if (Time.time >= _lastDestinationChange + +_cooldown)
        {
            AssignRandomDestination();
        }

        MoveTowardsDestination();
    }

    private void MoveTowardsDestination()
    {
        transform.position = Vector3.Lerp(transform.position, _destination, _speed);
        transform.LookAt(_destination);
    }

    private void AssignRandomDestination()
    {
        _destination = new Vector3(Random.Range(-_xRange, _xRange), Random.Range(0.2f, _yRange), Random.Range(-_zRange, _zRange));
        _lastDestinationChange = Time.time;
    }
}
