using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    private bool _isColliding = false;
    public bool _isCameraColliding = false;

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

        if (collider.gameObject.tag == "TriggerToGameRoom")
        {
            Debug.Log("collision with TriggerGameRoom");

            SceneManager.LoadScene("GameRoom");
        }

        if (collider.gameObject.tag == "TriggerToLevel1")
        {
            SceneManager.LoadScene("Level 1");
        }

        if (collider.gameObject.tag == "TriggerToLevel2")
        {
            SceneManager.LoadScene("Level 2");
        }


        if (collider.gameObject.name == "Main Camera" && collider.gameObject.tag == "Bloc")
        {
            _isCameraColliding = true;
        }
        else
        {
            _isCameraColliding = false;
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

    public bool GetCameraColliding ()
    {
        return _isCameraColliding;
    }

    

}
