using PrimeTween;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UI.Runtime
{
    public class MainMenu: MonoBehaviour
    {
            #region Publics

            //
    
            #endregion


            #region Unity API


            // Start is called once before the first execution of Update after the MonoBehaviour is created
            void Awake()
            {
                _rectTransform =  GetComponent<RectTransform>();
            }

            private void Start()
            {
                _canShowMenu = false;
            }

            // Update is called once per frame
            void Update()
            {
                //
            }

            private void FixedUpdate()
            {
                //
            }

            #endregion
            

            #region Main Methods

            public void OpenClose(InputAction.CallbackContext context)
            {
                if (context.performed)
                {
                    
                    _canShowMenu = !_canShowMenu;
                    _displayMenu(); 
                }
            }

            public void SpaceTouch()
            {
                Debug.Log("SpaceTouch Menu");
            }
    
            #endregion

    
            #region Utils

            private void _displayMenu()
            {
                if (_canShowMenu)
                {
                    Tween.UIAnchoredPosition(_rectTransform, new Vector3(0, 0, 0), 0.5f);
                }
                else
                {
                    Tween.UIAnchoredPosition(_rectTransform, new Vector3(-450, 0, 0), 0.5f);
                }
            }
    
            #endregion
    
    
            #region Privates and Protected
        
            private bool _canShowMenu;
            private RectTransform _rectTransform;

            #endregion
    }
}
