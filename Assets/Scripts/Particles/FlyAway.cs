using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAway : MonoBehaviour
{
    [SerializeField]
    private float _directionRange;

    private Rigidbody _rigidbody;
    private float _startTime;
    private float _timeToDisappear;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _startTime = Time.time;
        _timeToDisappear = 2f;

        transform.localScale = new Vector3(Random.Range(.08f, .3f), Random.Range(.08f, .3f), Random.Range(.08f, .3f));

        Vector3 direction = new Vector3(Random.Range(-_directionRange, _directionRange), Random.Range(-_directionRange, _directionRange), Random.Range(-_directionRange, _directionRange));
        float speed = Random.Range(.001f, 0.03f);
        _rigidbody.velocity = direction * speed;
    }

    private void Update()
    {
        if (Time.time >= _startTime + _timeToDisappear)
        {
            Destroy(gameObject);
        }
    }
}
