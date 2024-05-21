using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UiGameRoom : MonoBehaviour
{
    [SerializeField] private float ForceMove = 100f;
    [SerializeField] private Transform BotTransform;
    private Vector2 Direction;
    [SerializeField] private float SpeedMove = 1f;
    [SerializeField] private float _speedRotate = 1f;
    [SerializeField] private CharacterController CharacterController;
    [SerializeField] private Animator _animatorPlayer;
    [SerializeField] private GameObject _effectLever;
    [SerializeField] private GameObject _rotateLever;
    [SerializeField] private GameObject _effectLever2;
    [SerializeField] private GameObject _rotateLever2;
    [SerializeField] private GameObject _secretDoor;
    [SerializeField] private GameObject _effectLever3;
    [SerializeField] private GameObject _rotateLever3;
    [SerializeField] private GameObject _effectLever4;
    [SerializeField] private GameObject _effectLever5;
    [SerializeField] private GameObject _rotateLever4;
    [SerializeField] private GameObject _rotateLever5;
    [SerializeField] private GameObject _cube1;
    [SerializeField] private GameObject _rotateSwitch;
    [SerializeField] private GameObject _cube2;
    [SerializeField] private GameObject _rotateSwitch2;

    private Vector3 _velocity=Vector3.zero;
    [SerializeField] private float _gravity = 0.098f;

    [SerializeField] private PlayerCollision _scriptCollision;
    [SerializeField] private DoorCollision _scriptDoorCollision;
    [SerializeField] private DoorCollision2 _scriptDoorCollision2;
    [SerializeField] private DorrCollision3 _scriptDoorCollision3;
    [SerializeField] private DoorCollision4 _scriptDoorCollision4;
    [SerializeField] private DoorCollision5 _scriptDoorCollision5;
    [SerializeField] private BadGuyScript _badGuyScript;
    [SerializeField] private CubeCollision1 _scriptCubeCollision1;
    [SerializeField] private CubeCollision2 _scriptCubeCollision2;

    //private bool _isJumpPressed = false;
    [SerializeField] private float _jumpImpulse = 1f;

    [SerializeField] private Slider _lifeBar;
    [SerializeField] private Slider _badGuyLifeBar;

    [SerializeField] private GameObject _gun;


    private bool _leverIsPressed;
    private bool _leverIsPressed2;
    private bool _leverIsPressed3;
    private bool _leverIsPressed4;
    private bool _leverIsPressed5;
    private bool _switchIsPressed;
    private bool _switchIsPressed2;
    private bool _stopCube1 = false;
    private bool _stopCube2 = false;




    // Start is called before the first frame update
    void Start()
    {
        _lifeBar.maxValue = _scriptCollision.GetLifeMax();
        _lifeBar.minValue = 0;
        _lifeBar.value = _scriptCollision.GetCurrentLife();

        _badGuyLifeBar.maxValue = _badGuyScript.GetBadLifeMax();
        _badGuyLifeBar.minValue = 0;
        _badGuyLifeBar.value = _badGuyScript.GetCurrentBadLife();
    }


    /*
    public void PressedForward()
    {
        //BotTransform.Translate(0f, 0f, 0.5f);
        BotTransform.position = new Vector3(BotTransform.position.x, BotTransform.position.y, BotTransform.position.z + 0.5f);
    }

    public void PressedRight()
    {
        //BotTransform.Translate(0.5f, 0f, 0f);
        BotTransform.position = new Vector3(BotTransform.position.x + 0.5f, BotTransform.position.y, BotTransform.position.z);
    }

    public void PressedBackward()
    {
        //BotTransform.Translate(0f, 0f, -0.5f);
        BotTransform.position = new Vector3(BotTransform.position.x, BotTransform.position.y, BotTransform.position.z - 0.5f);
    }

    public void PressedLeft()
    {
        //BotTransform.Translate(-0.5f, 0f, 0f);
        BotTransform.position = new Vector3(BotTransform.position.x - 0.5f, BotTransform.position.y, BotTransform.position.z);
    }
    */






    public void Move(InputAction.CallbackContext Context)      //"Context" est un ptit nom temporaire
    {
        Direction = Context.ReadValue<Vector2>();
    }

    //Jump

    public void Jump(InputAction.CallbackContext Context)
    {
        if (Context.phase == InputActionPhase.Started && _scriptCollision.GetColliding() == true)
        {
            Debug.Log("press");
            _animatorPlayer.SetBool("IsJumping", true);
            _velocity.y = _velocity.y + _jumpImpulse;

            StartCoroutine(StopJumping());
            //_isJumpPressed = true;
        }
        //else if (Context.phase == InputActionPhase.Canceled)
        //{
        //    _isJumpPressed = false;
        //}

        /*
        if (_isJumpPressed == false)
        {
            _isJumpPressed = true;
        }
        else
        {
            _isJumpPressed = false;
        }
        */

        //_isJumpPressed = !_isJumpPressed;  <-- On peut aussi faire ça, le "!" indique l'inverse de la variable
    }


    public void Lever(InputAction.CallbackContext Context)
    {
        if (_scriptCollision.GetLeverState() == true)
        {
            _leverIsPressed = true;
            
            Debug.Log("leverPressed est a true");
        }

        if (_scriptCollision.GetLeverState2() == true)
        {
            _leverIsPressed2 = true;

            Debug.Log("leverPressed2 est a true");
        }

        if (_scriptCollision.GetLeverState3() == true)
        {
            _leverIsPressed3 = true;

            Debug.Log("leverPressed3 est a true");
        }

        if (_scriptCollision.GetLeverState4() == true)
        {
            _leverIsPressed4 = true;

            Debug.Log("leverPressed4 est a true");
        }

        if (_scriptCollision.GetLeverState5() == true)
        {
            _leverIsPressed5 = true;

            Debug.Log("leverPressed5 est a true");
        }

        if (_scriptCollision.GetSwitchState() == true)
        {
            _switchIsPressed = true;

            Debug.Log("_switchIsPressed est a true");
        }

        if (_scriptCollision.GetSwitchState2() == true)
        {
            _switchIsPressed2 = true;

            Debug.Log("_switchIsPressed2 est a true");
        }

    }

    public void Shoot(InputAction.CallbackContext Context)
    {
        if (Context.phase == InputActionPhase.Started && _scriptCollision.GetColliding() == true)
        {
            
            Debug.Log("press");
            _animatorPlayer.SetBool("IsShooting", true);

            StartCoroutine(StopShooting());
            
        }
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (_leverIsPressed == true && _scriptDoorCollision.GetLeverStateFinal() == true && (_effectLever.transform.rotation.eulerAngles.y > 270f || _effectLever.transform.rotation.eulerAngles.y < 5f))
        {
            Debug.Log("Rot y "+_effectLever.transform.rotation.eulerAngles.y);
            _effectLever.transform.Rotate(new Vector3(0, -5f, 0));
            _rotateLever.transform.Rotate(new Vector3(5f, 0, 0));
        }

        if (_leverIsPressed2 == true && _scriptDoorCollision2.GetLeverStateFinal2() == true && (_effectLever2.transform.rotation.eulerAngles.y > 185f || _effectLever2.transform.rotation.eulerAngles.y < 5f))
        {
            Debug.Log("Rot y " + _effectLever2.transform.rotation.eulerAngles.y);
            _effectLever2.transform.Rotate(new Vector3(0, -5f, 0));
            _rotateLever2.transform.Rotate(new Vector3(-5f, 0, 0));
            Destroy(_secretDoor);
            
        }

        if (_leverIsPressed3 == true && _scriptDoorCollision3.GetLeverStateFinal3() == true && (_effectLever3.transform.rotation.eulerAngles.y > 90f || _effectLever3.transform.rotation.eulerAngles.y < 5f))
        {
            Debug.Log("Rot y " + _effectLever3.transform.rotation.eulerAngles.y);
            _effectLever3.transform.Rotate(new Vector3(0, -5f, 0));
            _rotateLever3.transform.Rotate(new Vector3(5f, 0, 0));

        }


        if (_leverIsPressed4 == true /*&& _scriptDoorCollision4.GetLeverStateFinal4() == true*/ && (_effectLever4.transform.rotation.eulerAngles.x > -1f && _effectLever4.transform.rotation.eulerAngles.x < 90f))
        {
            Debug.Log("Rot y " + _effectLever4.transform.rotation.eulerAngles.y);
            _effectLever4.transform.Rotate(new Vector3(1f, 0, 0));
            _rotateLever4.transform.Rotate(new Vector3(0.25f, 0, 0));

        }

        if (_leverIsPressed5 == true /*&& _scriptDoorCollision5.GetLeverStateFinal5() == true*/ && (_effectLever5.transform.rotation.eulerAngles.y > 0f /*|| _effectLever5.transform.rotation.eulerAngles.y < 5f*/))
        {
            Debug.Log("Rot y " + _effectLever5.transform.rotation.eulerAngles.y);
            _effectLever5.transform.Rotate(new Vector3(0, -5f, 0));
            _rotateLever5.transform.Rotate(new Vector3(5f, 0, 0));

        }

        if (_switchIsPressed == true && _stopCube1 == false)
        {
            _cube1.transform.position = new Vector3(_cube1.transform.position.x, _cube1.transform.position.y + 0.05f, _cube1.transform.position.z);
            _rotateSwitch.transform.Rotate(new Vector3(0, 0, 2f));
            Debug.Log("Cube1 Monte");

        }

        if (_scriptCubeCollision1.GetSwitchState() == false)
        {
            _stopCube1 = true;
            Debug.Log("Cube1 stop");
        }


        if (_switchIsPressed2 == true && _stopCube2 == false)
        {
            _cube2.transform.position = new Vector3(_cube2.transform.position.x, _cube2.transform.position.y + 0.05f, _cube2.transform.position.z);
            _rotateSwitch2.transform.Rotate(new Vector3(0, 0, 0.5f));
            Debug.Log("Cube2 Monte");

        }

        if (_scriptCubeCollision2.GetSwitchState2() == false)
        {
            _stopCube2 = true;
            Debug.Log("Cube2 stop");
        }



        //if (_isSecretDoorOpen == true)
        //{
        //    _secretDoor.transform.Translate(new Vector3(0, -5f, 0));
        //}

        //if (_scriptDoorCollision.GetLeverStateFinal() == false)
        //{
        //    _effectLever.transform.Rotate(new Vector3(0, 0, 0));
        //    Debug.Log("ça arrive ici");
        //}


        //Gravity
        if (_scriptCollision.GetColliding() == true && _velocity.y <= 0)
        {
            Debug.Log("colliding with ground or velocity <= 0");
            _velocity.y = 0f;
        }
        else if(_scriptCollision.GetColliding() == false)
        {
            Debug.Log("no colliding with ground");
            _velocity.y = _velocity.y - _gravity * Time.deltaTime;
        }
        
        Debug.Log("Velocity Y " + _velocity.y);

        Vector3 movement = CharacterController.transform.forward * Direction.y * SpeedMove * Time.deltaTime;
        movement.y = _velocity.y;

        CharacterController.Move(movement);
        CharacterController.transform.Rotate(Vector3.up * Direction.x * _speedRotate * Time.deltaTime);
        /*
        if (_scriptCollision.GetCameraColliding() == false)
        {
            CharacterController.transform.Rotate(Vector3.up * Direction.x * _speedRotate * Time.deltaTime);
        }
        */

        if (Direction.magnitude > 0.1 && _animatorPlayer.GetCurrentAnimatorStateInfo(0).IsName("Jump") == false) 
        {
            //BotTransform.position = new Vector3((BotTransform.position.x + Direction.x) * SpeedMove, BotTransform.position.y, (BotTransform.position.z + Direction.y) * SpeedMove);
            
            //Vector3 verticality = CharacterController.transform.up * _velocity.y;

            //CharacterController.Move(movement + verticality);

            _animatorPlayer.SetBool("IsRunning", true);

            //Quaternion targetRotation = Quaternion.LookRotation(new Vector3(Direction.x, 0, Direction.y));
            //CharacterController.transform.rotation = targetRotation;            
        }
        else
        {
            _animatorPlayer.SetBool("IsRunning", false);
            CharacterController.Move(CharacterController.transform.up *_velocity.y);
        }


        //Pour les dégâts
        _lifeBar.value = _scriptCollision.GetCurrentLife();

        _badGuyLifeBar.value = _badGuyScript.GetCurrentBadLife();



        //if (_isJumpPressed == true)
        //{
        //    Debug.Log("jumping press update");
        //    _animatorPlayer.SetBool("IsJumping", true);
        //    _velocity.y = _velocity.y + _jumpImpulse * Time.deltaTime;

        //    StartCoroutine(StopJumping());
        //    _isJumpPressed = false;
        //}

    }


    IEnumerator StopJumping()
    {
        yield return new WaitForSeconds(0.1f);
        _animatorPlayer.SetBool("IsJumping", false);
        
    }

    IEnumerator StopShooting()
    {
        yield return new WaitForSeconds(0.1f);
        _animatorPlayer.SetBool("IsShooting", false);

    }

}
