using UnityEngine;

namespace _.Features.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Stats", menuName = "Gameplay/Characters", order = 0)]
    public class CharacterData : ScriptableObject
    {
        [Header("Déplacement")]
        [SerializeField] public float _moveSpeed = 1.0f;
        
        [Header("Stats")]
        [SerializeField] public int _health = 50;
        [SerializeField] public int _stamina = 10;
        [SerializeField] public int _strength = 10;
        [SerializeField] public int _dexterity = 10;
        [SerializeField] public int _intelligence = 10;
    }
}