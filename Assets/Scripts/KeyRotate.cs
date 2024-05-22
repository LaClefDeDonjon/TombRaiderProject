using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRotate : MonoBehaviour
{
    [SerializeField] private GameObject _key;
    [SerializeField] private GameObject _keyBack;
    [SerializeField] private PlayerCollision _keyIsTaking;
    private bool _isTaking = false;

    // Start is called before the first frame update
    void Start()
    {
        

        
    }

    // Update is called once per frame
    void Update()
    {
        if (_key != null)
        {
            _key.transform.Rotate(0, 0, 1f);
        }

        

        if (_keyIsTaking.GetKeyState() == true)
        {
            Destroy(_key);
            _isTaking = true;
        }




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
    }

    public bool GetIsTakingKey()
    {
        return _isTaking;
    }


}
