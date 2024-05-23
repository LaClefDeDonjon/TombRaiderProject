using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    private GameObject _isColliding;
    //private bool _isCameraColliding = false;
    private bool _leverIsOn = false;
    private bool _leverIsOn2 = false;
    private bool _leverIsOn3 = false;
    private bool _leverIsOn4 = false;
    private bool _leverIsOn5 = false;
    private bool _leverIsOn6 = false;
    private bool _switchIsOn = false;
    private bool _switchIsOn2 = false;
    private bool _takeKey = false;
    private bool _takeKey2 = false;
    private bool _takeKey3 = false;
    private bool _takeKey4 = false;
    private bool _keyDoorOpen = false;
    private bool _keyDoorOpen2 = false;
    private bool _keyDoorOpen3 = false;
    private bool _keyDoorOpen4 = false;

    [SerializeField] private int _lifeMax = 100;
    [SerializeField] private int _lifeCurrent = 100;

    [SerializeField] private KeyRotate _scriptIsKeyTaking;
    [SerializeField] private GameObject _keyBack;
    [SerializeField] private GameObject _keyBack2;
    [SerializeField] private GameObject _keyBack3;
    [SerializeField] private GameObject _keyBack4;



    //[SerializeField] private GameObject _badtemp;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            Debug.Log("collision with groud");
            _isColliding = collider.gameObject;
        }

        if (collider.gameObject.tag == "Damage")
        {
            Debug.Log("OnTriggerEnter Damage");
            ChangeLife(collider.gameObject.GetComponent<Damage>().GetDamageCost());
        }
    }


    void OnTriggerEnter(Collider collider)
    {
            if (collider.gameObject.tag == "Ground")
            {
                Debug.Log("collision with groud");
                _isColliding = collider.gameObject;
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

            if (collider.gameObject.tag == "TriggerToLevel3")
            {
                SceneManager.LoadScene("Level 3");
            }

            if (collider.gameObject.tag == "TriggerToLevel4")
            {
                SceneManager.LoadScene("Level 4");
            }

            if (collider.gameObject.tag == "Lever")
            {
                _leverIsOn = true;
                Debug.Log("Lever is True");
            }

            if (collider.gameObject.tag == "Lever2")
            {
                _leverIsOn2 = true;
                Debug.Log("Lever2 is True");
            }

            if (collider.gameObject.tag == "Lever3")
            {
                _leverIsOn3 = true;
                Debug.Log("Lever3 is True");
            }

            if (collider.gameObject.tag == "Lever4")
            {
                _leverIsOn4 = true;
                Debug.Log("Lever4 is True");
            }

            if (collider.gameObject.tag == "Lever5")
            {
                _leverIsOn5 = true;
                Debug.Log("Lever5 is True");
            }

            if (collider.gameObject.tag == "Lever6")
            {
                _leverIsOn6 = true;
                Debug.Log("Lever6 is True");
            }

            if (collider.gameObject.tag == "Switch")
            {
                _switchIsOn = true;
                Debug.Log("Switch is True");
            }

            if (collider.gameObject.tag == "Switch2")
            {
                _switchIsOn2 = true;
                Debug.Log("Switch2 is True");
            }

            if (collider.gameObject.tag == "Key")
            {
                _takeKey = true;
            }

            if (collider.gameObject.tag == "Key2")
            {
                _takeKey2 = true;
            }

            if (collider.gameObject.tag == "Key3")
            {
                _takeKey3 = true;
            }

            if (collider.gameObject.tag == "Key4")
            {
                _takeKey4 = true;
            }

            if (collider.gameObject.tag == "KeyDoor" && _scriptIsKeyTaking.GetIsTakingKey() == true)
            {
                _keyDoorOpen = true;
                _keyBack.SetActive(false);
                Debug.Log("keyDoorOpen est à true");
            }

            if (collider.gameObject.tag == "KeyDoor2" && _scriptIsKeyTaking.GetIsTakingKey2() == true)
            {
                _keyDoorOpen2 = true;
                _keyBack2.SetActive(false);
                Debug.Log("keyDoorOpen2 est à true");
            }

            if (collider.gameObject.tag == "KeyDoor3" && _scriptIsKeyTaking.GetIsTakingKey3() == true)
            {
                _keyDoorOpen3 = true;
                _keyBack3.SetActive(false);
                Debug.Log("keyDoorOpen3 est à true");
            }

            if (collider.gameObject.tag == "KeyDoor4" && _scriptIsKeyTaking.GetIsTakingKey4() == true)
            {
                _keyDoorOpen4 = true;
                _keyBack4.SetActive(false);
                Debug.Log("keyDoorOpen4 est à true");
            }

            if (collider.gameObject.tag == "Damage")
            {
                    Debug.Log("OnTriggerEnter Damage");
                    ChangeLife(collider.gameObject.GetComponent<Damage>().GetDamageCost());
            }



            //Tentative de collision de camera
            /*
            if (collider.gameObject.name == "Main Camera" && collider.gameObject.tag == "Bloc")
            {
                _isCameraColliding = true;
            }
            else
            {
                _isCameraColliding = false;
            }
            */

            //Debug.Log("Collision enter: " + collision.gameObject.name);
    }

    //void OnCollisionStay(Collision collision)
    //{
    //    Debug.Log("Collision stay: " + collision.gameObject.name);
    //}

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Ground" && _isColliding.transform.GetInstanceID() == collider.gameObject.transform.GetInstanceID())
        {
            Debug.Log("no more collision with groud");
            _isColliding = null;
        }

        if (collider.gameObject.tag == "Lever")
        {
            _leverIsOn = false;
            Debug.Log("Lever is False");
        }

        if (collider.gameObject.tag == "Lever2")
        {
            _leverIsOn2 = false;
            Debug.Log("Lever2 is False");
        }

        if (collider.gameObject.tag == "Lever3")
        {
            _leverIsOn3 = false;
            Debug.Log("Lever3 is False");
        }

        if (collider.gameObject.tag == "Lever4")
        {
            _leverIsOn4 = false;
            Debug.Log("Lever4 is False");
        }

        if (collider.gameObject.tag == "Lever5")
        {
            _leverIsOn5 = false;
            Debug.Log("Lever5 is False");
        }

        if (collider.gameObject.tag == "Lever6")
        {
            _leverIsOn6 = false;
            Debug.Log("Lever6 is False");
        }

        if (collider.gameObject.tag == "Switch")
        {
            _switchIsOn = false;
            Debug.Log("Switch is false");
        }

        if (collider.gameObject.tag == "Switch2")
        {
            _switchIsOn2 = false;
            Debug.Log("Switch2 is false");
        }

    }

    public void ChangeLife(int point)
    {
        _lifeCurrent = _lifeCurrent + point;
        if (_lifeCurrent < 0)
        {
            _lifeCurrent = 0;
        }

        if (_lifeCurrent > _lifeMax)
        {
            _lifeCurrent = _lifeMax;
        }

    }



    public bool GetColliding ()
    {
        return _isColliding != null;
    }

    public bool GetLeverState ()
    {
        return _leverIsOn;
    }

    public bool GetLeverState2()
    {
        return _leverIsOn2;
    }

    public bool GetLeverState3()
    {
        return _leverIsOn3;
    }

    public bool GetLeverState4()
    {
        return _leverIsOn4;
    }

    public bool GetLeverState5()
    {
        return _leverIsOn5;
    }

    public bool GetLeverState6()
    {
        return _leverIsOn6;
    }

    public bool GetSwitchState()
    {
        return _switchIsOn;
    }

    public bool GetSwitchState2()
    {
        return _switchIsOn2;
    }

    public int GetCurrentLife()
    {
        return _lifeCurrent;
    }

    public bool GetKeyState()
    {
        return _takeKey;
    }

    public bool GetKeyState2()
    {
        return _takeKey2;
    }

    public bool GetKeyState3()
    {
        return _takeKey3;
    }

    public bool GetKeyState4()
    {
        return _takeKey4;
    }

    public bool GetkeyDoorState()
    {
        return _keyDoorOpen;
    }

    public bool GetkeyDoorState2()
    {
        return _keyDoorOpen2;
    }

    public bool GetkeyDoorState3()
    {
        return _keyDoorOpen3;
    }

    public bool GetkeyDoorState4()
    {
        return _keyDoorOpen4;
    }

    public int GetLifeMax()
    {
        return _lifeMax;
    }



    /*
    public bool GetCameraColliding ()
    {
        return _isCameraColliding;
    }
    */


}
