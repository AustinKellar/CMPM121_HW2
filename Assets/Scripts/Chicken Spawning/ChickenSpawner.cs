using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSpawner : MonoBehaviour
{
    public int numberOfChickens;

    [SerializeField]
    private float _xRange;
    
    [SerializeField]
    private float _yRange;

    [SerializeField]
    private float _zRange;

    [SerializeField]
    private GameObject _chicken;

    [SerializeField]
    private Vector3 _giantChickenScale;


    private void Start()
    {
        for(int i=0; i<numberOfChickens; i++)
        {
            Vector3 position = new Vector3(Random.Range(-_xRange, _xRange), Random.Range(0.2f, _yRange), Random.Range(-_zRange, _zRange));
            Vector3 eulerAngles = new Vector3(0, Random.Range(-360, 360), 0);
      
            Instantiate(_chicken, position, Quaternion.Euler(eulerAngles));
        }
    }

    public void SpawnSuperChicken()
    {
        Vector3 position = new Vector3(0, 5, 0);
        Vector3 eulerAngles = Vector3.zero;

        GameObject superChicken = Instantiate(_chicken, position, Quaternion.Euler(eulerAngles));
        superChicken.transform.localScale = _giantChickenScale;
    }
}
