using _.Features.ScriptableObjects;
using PlasticPipe.PlasticProtocol.Messages;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
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
            }

            private void Start()
            {
                //
            }

            // Update is called once per frame
            private void FixedUpdate()
            {
                _direction = _camera.transform.forward;
                _direction.y = 0;
                Quaternion lookRotation = Quaternion.LookRotation(_direction);
                transform.rotation = Quaternion.Lerp(Transform.rotation, lookRotation, Time.fixedDeltaTime);
                
                
                Vector3 localMovement = transform.TransformDirection(_movement);
                _characterController.SimpleMove(localMovement * _playerData._moveSpeed);
            }

            #endregion
            

            #region Main Methods

            public void OnMove(InputAction.CallbackContext context)
            {
                if (context.performed)
                {
                    _inputValue = context.ReadValue<Vector2>();
                    _movement = new Vector3(_inputValue.x, 0, _inputValue.y);
                }
                else
                {
                    _movement = Vector3.zero;
                }
            }
    
            #endregion

    
            #region Utils
    
            /* Fonctions privées utiles */
    
            #endregion
    
    
            #region Privates and Protected

            private Camera _camera;
            private Vector3 _direction;
            private Vector3 _movement;
            private CharacterController _characterController;
            private Vector2 _inputValue;
            
            [SerializeField] private CharacterData _playerData;

            #endregion
    }
}
