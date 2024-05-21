using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollision1 : MonoBehaviour
{
    private bool _switchState = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "StopCube1")
        {
            _switchState = false;
        }
    }


    public bool GetSwitchState()
    {
        return _switchState;
    }
}
