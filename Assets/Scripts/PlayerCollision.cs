using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private bool _isColliding = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            Debug.Log("collision with groud");
            _isColliding = true;
        }

        //Debug.Log("Collision enter: " + collision.gameObject.name);
    }

    //void OnCollisionStay(Collision collision)
    //{
    //    Debug.Log("Collision stay: " + collision.gameObject.name);
    //}

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            Debug.Log("no more collision with groud");
            _isColliding = false;
        }

    }

    public bool GetColliding ()
    {
        return _isColliding;
    }

}
