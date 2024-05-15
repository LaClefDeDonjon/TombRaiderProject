using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollision2 : MonoBehaviour
{
    private bool _leverState2 = true;
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
            _leverState2 = false;
            Debug.Log("_leverState2 à false");
        }
    }


    public bool GetLeverStateFinal2()
    {
        return _leverState2;
    }
}
