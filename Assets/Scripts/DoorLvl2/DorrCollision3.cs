using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DorrCollision3 : MonoBehaviour
{
    private bool _leverState3 = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bloc")
        {
            _leverState3 = false;
            Debug.Log("_leverState3 à false");
        }
    }

    public bool GetLeverStateFinal3()
    {
        return _leverState3;
    }
}
