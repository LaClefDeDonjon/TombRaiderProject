using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollision : MonoBehaviour
{
    //private GameObject _isDoorColliding;
    private bool _leverState = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Bloc")
        {
            _leverState = false;
            Debug.Log("_leverState à false");
        }


    }

    public bool GetLeverStateFinal ()
    {
        return _leverState;
    }
    
}
