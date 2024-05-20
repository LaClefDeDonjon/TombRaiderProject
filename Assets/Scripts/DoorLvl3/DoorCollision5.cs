using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollision5 : MonoBehaviour
{
    private bool _leverState5 = true;

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
            _leverState5 = false;
            Debug.Log("_leverState5 à false");
        }
    }
    public bool GetLeverStateFinal5()
    {
        return _leverState5;
    }
}
