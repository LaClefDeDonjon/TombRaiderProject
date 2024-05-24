using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tresor : MonoBehaviour
{
    [SerializeField] private GameObject _treasure;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _treasure.transform.Rotate(0, 1f, 0);
    }

}
