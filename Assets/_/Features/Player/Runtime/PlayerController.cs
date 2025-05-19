using System;
using _.Features.ScriptableObjects;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

namespace Player.Runtime
{
    public class PlayerController : Universe
    {
            #region Publics

            //
    
            #endregion


            #region Unity API


            // Start is called once before the first execution of Update after the MonoBehaviour is created
            void Awake()
            {
                _camera = Camera.main;
                _characterController = GetComponent<CharacterController>();
                _isGrounded = GetComponent<CharacterController>().isGrounded;
            }

            // Update is called once per frame
            private void FixedUpdate()
            {
                if (_isGrounded)
                {
                    _velocity.y = 0;
                }
                _velocity.y += _gravity;
                _UpdateMovement();
                _CheckState();
            }

            #endregion
            

            #region Main Methods

            public void OnMove(InputAction.CallbackContext context)
            {
                _state = PlayerStateEnum.State.WALK;
                _inputValue = context.ReadValue<Vector2>();
            }
            
            public void OnJump(InputAction.CallbackContext context)
            {
                if (context.performed)
                {
                    _state = PlayerStateEnum.State.JUMP;
                }
            }
    
            #endregion

    
            #region Utils

            private void _CheckState()
            {
                if (_inputValue == Vector2.zero)
                {
                    _state = PlayerStateEnum.State.IDLE;
                }
                
                switch (_state)
                {
                    case PlayerStateEnum.State.IDLE:
                        Info("On ne bouge pas");
                        break;
                    case PlayerStateEnum.State.WALK:
                        Info("Marche");
                        break;
                    case PlayerStateEnum.State.JUMP:
                        _ApplyState(PlayerStateEnum.State.JUMP);
                        break;
                }
            }

            private void _ApplyState(PlayerStateEnum.State state)
            {
                if (state == PlayerStateEnum.State.JUMP && _isGrounded)
                {
                    //Rigidbody.AddForce(Vector3.up * 10,  ForceMode.Impulse);
                    _velocity.y = Mathf.Sqrt(_playerData._jumpHeight * _playerData._jumpSpeed * _gravity);
                    
                }
            }

            private void _UpdateMovement()
            {
                /*_direction = _camera.transform.forward;
                _direction.y = 0;
                Quaternion lookRotation = Quaternion.LookRotation(_direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);

                //var moveVector = _inputValue.x * transform.right + _inputValue.y * transform.forward;
                var moveVector = transform.TransformDirection(input_direction);*/
                Vector3 input_direction = new Vector3(_inputValue.x, 0, _inputValue.y);
                input_direction = Vector3.ClampMagnitude(input_direction, 1f);
                
                Vector3 movePlayer = (input_direction * _playerData._moveSpeed) + (_velocity.y * Vector3.up);
                _characterController.Move(movePlayer);
            }
    
            #endregion
    
    
            #region Privates and Protected

            private Camera _camera;
            private Vector3 _direction;
            private Vector3 _movement;
            private CharacterController _characterController;
            private Vector2 _inputValue;
            private bool _isGrounded;
            private PlayerStateEnum.State _state;
            
            [SerializeField] private CharacterData _playerData;
            [Header("Forces exterieurs")]
            [SerializeField] private float _gravity = 1.0f;
            [SerializeField] private Vector2 _velocity = new Vector2(0, 0);

            #endregion
    }
}
