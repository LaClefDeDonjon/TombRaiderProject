using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene("GameRoom");
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
