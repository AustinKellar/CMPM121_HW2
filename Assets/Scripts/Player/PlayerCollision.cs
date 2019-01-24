using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private Text _deadChickensText;

    [SerializeField]
    private Text _notDeadChickensText;

    [SerializeField]
    private GameObject _bloodParticle;

    [SerializeField]
    private ChickenSpawner _chickenSpawner;

    private int _deadChickenCount;

    private void Start()
    {
        _deadChickenCount = 0;

        _deadChickensText.text = "Dead Chickens: 0";
        _notDeadChickensText.text = "Not Dead Chickens: " + _chickenSpawner.numberOfChickens.ToString() + " :(";
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Chicken")
        {
            _deadChickensText.text = "Dead Chickens: " + (++_deadChickenCount).ToString();

            int aliveChickens = _chickenSpawner.numberOfChickens - _deadChickenCount;
            if (aliveChickens > 0)
            {
                _notDeadChickensText.text = "Alive Chickens " + (aliveChickens).ToString() + " :(";
            }
            else
            {
                _notDeadChickensText.text = "Alive Chickens " + (aliveChickens).ToString() + " :)";
            }

            Vector3 position = collider.gameObject.transform.position;
            Quaternion rotation = collider.gameObject.transform.rotation;

            for(int i=0; i<1000; i++)
            {
                Instantiate(_bloodParticle, position, rotation);
            }
            Destroy(collider.gameObject);
        }
    }
}
