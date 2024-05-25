using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Rouleau : MonoBehaviour
{
    [SerializeField] private GameObject _rouleauHaut;
    [SerializeField] private GameObject _rouleauBas;
    [SerializeField] private GameObject _rouleauAll;
    [SerializeField] private float _speedRouleau = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _rouleauHaut.transform.Rotate(-1.5f, 0, 0);

        _rouleauBas.transform.Rotate(1.5f, 0, 0);

        _rouleauAll.transform.Translate(0, 0, -_speedRouleau);

    }
}
