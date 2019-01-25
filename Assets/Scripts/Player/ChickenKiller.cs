using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChickenKiller : MonoBehaviour
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

    private int AliveChickenCount
    {
        get { return _chickenSpawner.numberOfChickens - _deadChickenCount; }
    }

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
            _deadChickenCount++;
            UpdateChickenText();
            CreateBloodExplosion(collider);
            Destroy(collider.gameObject);

            if (AliveChickenCount == 0)
            {
                _chickenSpawner.SpawnSuperChicken();
            }
        }
    }

    private void UpdateChickenText()
    {
        _deadChickensText.text = "Dead Chickens: " + (_deadChickenCount).ToString();

        if (AliveChickenCount > 0)
        {
            _notDeadChickensText.text = "Alive Chickens " + (AliveChickenCount).ToString() + " :(";
        }
        else
        {
            _notDeadChickensText.text = "Alive Chickens: 0 :)";
        }
    }

    private void CreateBloodExplosion(Collider collider)
    {
        Vector3 position = collider.gameObject.transform.position;
        Quaternion rotation = collider.gameObject.transform.rotation;

        for (int i = 0; i < 1000; i++)
        {
            Instantiate(_bloodParticle, position, rotation);
        }
    }
}
