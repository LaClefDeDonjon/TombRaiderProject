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
    private bool _isSecretDoorOpen = false;

    private Vector3 _velocity=Vector3.zero;
    [SerializeField] private float _gravity = 0.098f;

    [SerializeField] private PlayerCollision _scriptCollision;
    [SerializeField] private DoorCollision _scriptDoorCollision;
    [SerializeField] private DoorCollision2 _scriptDoorCollision2;
    //private bool _isJumpPressed = false;
    [SerializeField] private float _jumpImpulse = 1f;

    [SerializeField] private Slider _lifeBar;

    [SerializeField] private GameObject _gun;


    private bool _leverIsPressed;
    private bool _leverIsPressed2;




    // Start is called before the first frame update
    void Start()
    {
        _lifeBar.maxValue = _scriptCollision.GetLifeMax();
        _lifeBar.minValue = 0;
        _lifeBar.value = _scriptCollision.GetCurrentLife();
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
