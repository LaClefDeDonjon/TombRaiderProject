using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotScript : MonoBehaviour
{

    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _targetBullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void InstantiateBullet()
    {
        GameObject bulletInstance = Instantiate(_bullet);
        bulletInstance.transform.position = _targetBullet.transform.position;
        bulletInstance.transform.rotation = _targetBullet.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
