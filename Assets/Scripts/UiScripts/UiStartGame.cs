using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiStartGame : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LaunchReturnFonctionStartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LaunchGameScene()
    {
        
    }

    public void LaunchLvl1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LaunchLvl2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void LaunchLvl3()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void LaunchLvl4()
    {
        SceneManager.LoadScene("Level 4");
    }

    public void LaunchLvl5()
    {
        SceneManager.LoadScene("Level 5");
    }

    public void LaunchLvl6()
    {
        SceneManager.LoadScene("Level 6");
    }

    public void ValuePlayerName()
    {

    }

    public void ValueDifficulty()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
