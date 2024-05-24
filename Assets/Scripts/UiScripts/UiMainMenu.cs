using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UiMainMenu : MonoBehaviour

{
    [SerializeField] private RectTransform SizePlayButton;
    [SerializeField] private RectTransform RotationCreditsButton;
    private float SpeedScale = 0.001f;
    private bool IsGrowing = false;

    private bool IsRotate = false;
    private float SpeedRotate = 0.01f;

    [SerializeField] private RectTransform LogoBeat;
    private float SpeedBeat = 0.001f;
    private bool Logosize = false;
 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        //Bounce du Boutton Jouer
        if (SizePlayButton.localScale.x <= 1.5f)
        {
            IsGrowing = true;
        }
        else if (SizePlayButton.localScale.x >= 2f)
        {
            IsGrowing = false;
        }

        if (IsGrowing == true)
        {
            SizePlayButton.localScale = new Vector3(SizePlayButton.localScale.x + SpeedScale, SizePlayButton.localScale.y + SpeedScale, SizePlayButton.localScale.z + SpeedScale);
        }
        else if (IsGrowing == false)
        {
            SizePlayButton.localScale = new Vector3(SizePlayButton.localScale.x - SpeedScale, SizePlayButton.localScale.y - SpeedScale, SizePlayButton.localScale.z - SpeedScale);
        }

        //Rotation du bouton Credit
        
        //if (RotationCreditsButton.localRotation.z <= 3f)
        //{
        //    IsRotate = true;
        //}
        //else if (RotationCreditsButton.localRotation.z >= 4f)
        //{
        //    IsRotate = false;
        //}

        //if (IsRotate == true)
        //{
        //    RotationCreditsButton.localRotation = Quaternion.Euler(0f, 0f, RotationCreditsButton.localRotation.z + SpeedRotate);
        //    SpeedRotate = SpeedRotate + 0.5f;
        //}
        //else if (IsRotate == false)
        //{
        //    RotationCreditsButton.localRotation = Quaternion.Euler(0f, 0f, RotationCreditsButton.localRotation.z - SpeedRotate);
        //    SpeedRotate = SpeedRotate - 0.5f;
        //}
        

        //Battement du logo
        
        if (Logosize == false)
        {
            LogoBeat.localScale = new Vector3(1f, 1f, 1f);

            Logosize = true;
        }

        if (Logosize == true)
        {
            LogoBeat.localScale = new Vector3(LogoBeat.localScale.x - SpeedBeat, LogoBeat.localScale.y - SpeedBeat, LogoBeat.localScale.z - SpeedBeat);
        }

        if (Logosize == true && LogoBeat.localScale.x <= 0.8f)
        {
            Logosize = false;
        }
        
    }

    public void LaunchMusicScene() 
    {
        SceneManager.LoadScene("Music");
    }

    public void LaunchOptionsScene()
    {
        SceneManager.LoadScene("Settings");
    }

    public void LaunchCreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }

    public void LaunchQuitGame()
    {
        Application.Quit();
    }

    public void LaunchGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    // Update is called once per frame

}
