using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRotate : MonoBehaviour
{
    [SerializeField] private GameObject _key;
    [SerializeField] private GameObject _key2;
    [SerializeField] private GameObject _key3;
    [SerializeField] private GameObject _key4;
    [SerializeField] private GameObject _keyBack;
    [SerializeField] private GameObject _keyBack2;
    [SerializeField] private GameObject _keyBack3;
    [SerializeField] private GameObject _keyBack4;
    [SerializeField] private PlayerCollision _keyIsTaking;
    private bool _isTaking = false;
    private bool _isTaking2 = false;
    private bool _isTaking3 = false;
    private bool _isTaking4 = false;

    // Start is called before the first frame update
    void Start()
    {
        

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_key != null)
        {
            _key.transform.Rotate(0, 0, 1f);
        }

        if (_key2 != null)
        {
            _key2.transform.Rotate(0, 0, 1f);
        }

        if (_key3 != null)
        {
            _key3.transform.Rotate(0, 0, 1f);
        }

        if (_key4 != null)
        {
            _key4.transform.Rotate(0, 0, 1f);
        }


        if (_keyIsTaking.GetKeyState() == true)
        {
            Destroy(_key);
            _isTaking = true;
        }

        if (_keyIsTaking.GetKeyState2() == true)
        {
            Destroy(_key2);
            _isTaking2 = true;
        }

        if (_keyIsTaking.GetKeyState3() == true)
        {
            Destroy(_key3);
            _isTaking3 = true;
        }

        if (_keyIsTaking.GetKeyState4() == true)
        {
            Destroy(_key4);
            _isTaking4 = true;
        }

        //1

        if (_keyIsTaking.GetKeyState() == false ) //clef pas prise, début
        {
            _keyBack.SetActive(false);
        }

        if (_keyIsTaking.GetkeyDoorState() == true) //porte touche, la clef disparait du dos
        {
            _keyBack.SetActive(false);
        }
        else if (_keyIsTaking.GetKeyState() == true) //clef prise, s'affiche dans le dos
        {
            _keyBack.SetActive(true);
        }

        //2

        if (_keyIsTaking.GetKeyState2() == false) //clef pas prise, début
        {
            _keyBack2.SetActive(false);
        }

        if (_keyIsTaking.GetkeyDoorState2() == true) //porte touche, la clef disparait du dos
        {
            _keyBack2.SetActive(false);
        }
        else if (_keyIsTaking.GetKeyState2() == true) //clef prise, s'affiche dans le dos
        {
            _keyBack2.SetActive(true);
        }


        //3

        if (_keyIsTaking.GetKeyState3() == false) //clef pas prise, début
        {
            _keyBack3.SetActive(false);
        }

        if (_keyIsTaking.GetkeyDoorState3() == true) //porte touche, la clef disparait du dos
        {
            _keyBack3.SetActive(false);
        }
        else if (_keyIsTaking.GetKeyState3() == true) //clef prise, s'affiche dans le dos
        {
            _keyBack3.SetActive(true);
        }



        //4

        if (_keyIsTaking.GetKeyState4() == false) //clef pas prise, début
        {
            _keyBack4.SetActive(false);
        }

        if (_keyIsTaking.GetkeyDoorState4() == true) //porte touche, la clef disparait du dos
        {
            _keyBack4.SetActive(false);
        }
        else if (_keyIsTaking.GetKeyState4() == true) //clef prise, s'affiche dans le dos
        {
            _keyBack4.SetActive(true);
        }
    }

    public bool GetIsTakingKey()
    {
        return _isTaking;
    }

    public bool GetIsTakingKey2()
    {
        return _isTaking2;
    }

    public bool GetIsTakingKey3()
    {
        return _isTaking3;
    }

    public bool GetIsTakingKey4()
    {
        return _isTaking4;
    }
}
