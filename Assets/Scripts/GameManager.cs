using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string tooltipText = "";

    [SerializeField] private Text tooltipTextGO;
    [SerializeField] private GameObject tooltipText2;
    [SerializeField] private UnityEngine.Font tooltipFont;
    // Start is called before the first frame update
    void Start()
    {
        tooltipTextGO.text = "Start";
        
    }  

    // Update is called once per frame
    void Update()
    {
        //tooltipTextGO.text = "Update";
        //tooltipTextGO.text = tooltipText;
    }

   
}
