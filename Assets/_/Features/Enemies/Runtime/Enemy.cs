using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy.Runtime
{
    public class Enemy : MonoBehaviour
    {
            #region Publics

            //
    
            #endregion


            #region Unity API


            // Start is called once before the first execution of Update after the MonoBehaviour is created
            void Awake()
            {
                
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
                _CanvasLookPlayer();
                _RotationFollowPlayer();
            }

            #endregion
    


            #region Main Methods

            // 
    
            #endregion

    
            #region Utils

            private void _CanvasLookPlayer()
            {
                var direction = _player.transform.forward;
                var rotation = Quaternion.LookRotation(direction);
                _nameEnemy.transform.rotation = rotation;
            }
            
            private void _RotationFollowPlayer()
            {
                var direction = _player.transform.position - transform.position;
                var rotationX = new Vector3(direction.x, 0, direction.z);
                _baseCanon.rotation = Quaternion.RotateTowards(_baseCanon.rotation, Quaternion.LookRotation(-rotationX), _rotationSpeed * Time.deltaTime);
            }
    
            #endregion
    
    
            #region Privates and Protected

            private bool _viewPlayer = false;

            [SerializeField] private GameObject _player;
            [SerializeField] private TMP_Text _nameEnemy;
            [SerializeField] private Transform _baseCanon;
            [SerializeField] private float _rotationSpeed = 15;

            #endregion
    }
}
