using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollision2 : MonoBehaviour
{
    private bool _switchState2 = true;
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
        if (collision.gameObject.tag == "StopCube2")
        {
            _switchState2 = false;
            Debug.Log("Cube2 touche");
        }
    }

    public bool GetSwitchState2()
    {
        return _switchState2;
    }
}
