using PrimeTween;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utils;

namespace UI.Runtime
{
    public class InteractiveButton : Universe, IPointerEnterHandler, IPointerExitHandler
    {
            #region Publics

            //
    
            #endregion


            #region Unity API


            // Start is called once before the first execution of Update after the MonoBehaviour is created
            void Awake()
            {
                _sprite =  GetComponent<Image>();
            }

            private void Start()
            {
                //
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

            public void OnPointerEnter(PointerEventData eventData)
            {
                Tween.Scale(transform, new Vector3(1.2f, 1.2f, 1.2f), 0.2f);
                Tween.Color(_sprite, Color.cyan, 0.2f);
            }

            public void OnPointerExit(PointerEventData eventData)
            {
                Tween.Scale(transform, Vector3.one, 0.2f);
                Tween.Color(_sprite, Color.white, 0.2f);
            }
    
            #endregion

    
            #region Utils
    
            /* Fonctions privées utiles */
    
            #endregion
    
    
            #region Privates and Protected
        
            private Image _sprite;

            #endregion
        
    }
}
