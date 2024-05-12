using System.Collections;
using System.Collections.Generic;
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

    private Vector3 _velocity=Vector3.zero;
    [SerializeField] private float _gravity = 0.098f;

    [SerializeField] private PlayerCollision _scriptCollision;
    private bool _isJumpPressed = false;
    [SerializeField] private float _jumpImpulse = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
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

    // Update is called once per frame
    void FixedUpdate()
    {
        

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

        if (_scriptCollision.GetCameraColliding() == false)
        {
            CharacterController.transform.Rotate(Vector3.up * Direction.x * _speedRotate * Time.deltaTime);
        }
        

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

}
