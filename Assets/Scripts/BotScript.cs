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
        //Time.timeScale = 0.1f;
    }

    public void InstantiateBullet()
    {
        StartCoroutine(BulletSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator BulletSpawn()
    {
        yield return new WaitForSeconds(0.0085f);
        
        Vector3 position = _targetBullet.transform.position;
        Quaternion rotation = Quaternion.Euler(0, gameObject.transform.rotation.eulerAngles.y, 0);

        GameObject bulletInstance = Instantiate(_bullet, position, rotation);
    }

}
