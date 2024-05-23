using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouletMove : MonoBehaviour
{
    [SerializeField] private GameObject _boulet;
    [SerializeField] private GameObject _boulet2;
    [SerializeField] private GameObject _boulet3;
    [SerializeField] private GameObject _boulet4;
    [SerializeField] private GameObject _boulet5;
    private int _bouletState = 1;
    private int _bouletState2 = 1;
    private int _bouletState3 = 1;
    private int _bouletState4 = 1;
    [SerializeField] private float _speedBoulet = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Boulet1

        if (_bouletState == 0)
        {
            _boulet.transform.Rotate(-_speedBoulet, 0, 0);
            Debug.Log("0 Rot x " + _boulet.transform.rotation.eulerAngles.x);
        }
        if (_boulet.transform.rotation.eulerAngles.x >= 90f && _boulet.transform.rotation.eulerAngles.x < 180f)
        {
            Debug.Log("BouletState1");
            _bouletState = 1;
        }
        if (_bouletState == 1)
        {
            _boulet.transform.Rotate(_speedBoulet, 0, 0);
            Debug.Log("1 Rot x " + _boulet.transform.rotation.eulerAngles.x);
        }
        if (_boulet.transform.rotation.eulerAngles.x <= 270f && _boulet.transform.rotation.eulerAngles.x > 180f)
        {
            Debug.Log("BouletState0");
            _bouletState = 0;
        }


        //Boulet2


        if (_bouletState2 == 0)
        {
            _boulet2.transform.Rotate(-_speedBoulet, 0, 0);
            Debug.Log("(2) 0 Rot x " + _boulet2.transform.rotation.eulerAngles.x);
        }
        if (_boulet2.transform.rotation.eulerAngles.x >= 90f && _boulet2.transform.rotation.eulerAngles.x < 180f)
        {
            Debug.Log("BouletState2 (1)");
            _bouletState2 = 1;
        }
        if (_bouletState2 == 1)
        {
            _boulet2.transform.Rotate(_speedBoulet, 0, 0);
            Debug.Log("(2) 1 Rot x " + _boulet2.transform.rotation.eulerAngles.x);
        }
        if (_boulet2.transform.rotation.eulerAngles.x <= 270f && _boulet2.transform.rotation.eulerAngles.x > 180f)
        {
            Debug.Log("BouletState2 (0)");
            _bouletState2 = 0;
        }


        //Boulet3


        if (_bouletState3 == 0)
        {
            _boulet3.transform.Rotate(-_speedBoulet, 0, 0);
            Debug.Log("(3) 0 Rot x " + _boulet3.transform.rotation.eulerAngles.x);
        }
        if (_boulet3.transform.rotation.eulerAngles.x >= 90f && _boulet3.transform.rotation.eulerAngles.x < 180f)
        {
            Debug.Log("BouletState3 (1)");
            _bouletState3 = 1;
        }
        if (_bouletState3 == 1)
        {
            _boulet3.transform.Rotate(_speedBoulet, 0, 0);
            Debug.Log("(3) 1 Rot x " + _boulet3.transform.rotation.eulerAngles.x);
        }
        if (_boulet3.transform.rotation.eulerAngles.x <= 270f && _boulet3.transform.rotation.eulerAngles.x > 180f)
        {
            Debug.Log("BouletState0 (3)");
            _bouletState3 = 0;
        }




        _boulet4.transform.Rotate(0, 0, -2f);



        _boulet5.transform.Rotate(0, 0, 2f);

    }
}
