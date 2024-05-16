using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollision4 : MonoBehaviour
{
    private bool _leverState4 = true;
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
            _leverState4 = false;
            Debug.Log("_leverState4 à false");
        }
    }
    public bool GetLeverStateFinal4()
    {
        return _leverState4;
    }
}
