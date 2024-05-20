using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyScript : MonoBehaviour
{

    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private int _badLifeMax = 100;
    [SerializeField] private int _badLifeCurrent = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_badLifeCurrent == 0)
        {
            Destroy(_enemy);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        //if (collision.gameObject.tag == "Bullet")
        //{
        //    Destroy(_enemy);
        //    Debug.Log("Destroy enemy");
        //}

        if (collision.gameObject.tag == "Damage")
        {
            Debug.Log("OnTriggerEnter BadDamage");
            ChangeBadLife(collision.gameObject.GetComponent<Damage>().GetDamageCost());
        }
    }

    public void ChangeBadLife(int point)
    {
        _badLifeCurrent = _badLifeCurrent + point;
        if (_badLifeCurrent < 0)
        {
            _badLifeCurrent = 0;
        }

        if (_badLifeCurrent > _badLifeMax)
        {
            _badLifeCurrent = _badLifeMax;
        }

    }

    public int GetCurrentBadLife()
    {
        return _badLifeCurrent;
    }

    public int GetBadLifeMax()
    {
        return _badLifeMax;
    }




}
