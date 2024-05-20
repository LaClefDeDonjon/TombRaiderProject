using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float _speedShoot = 1f;
    [SerializeField] private float _timerBullet = 0f;
    [SerializeField] private float _timerBulletLifeTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timerBullet = _timerBullet + Time.deltaTime;
        transform.Translate(new Vector3(0, 1f, 0) /*gameObject.transform.forward*/ * _speedShoot * Time.deltaTime);

        if (_timerBullet > _timerBulletLifeTime)
        {
            Destroy(gameObject );
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        } 
    }

}
