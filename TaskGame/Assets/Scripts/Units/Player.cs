using UnityEngine;

namespace Units
{
    public class Player : Unit
    {
        [Header("Person")]
        [SerializeField] private SpriteRenderer _head;
        [SerializeField] private SpriteRenderer _body;
        [SerializeField] private SpriteRenderer _armLeft;
        [SerializeField] private SpriteRenderer _armRight;
        [SerializeField] private SpriteRenderer _legLeft;
        [SerializeField] private SpriteRenderer _legRight;
        [Space]
        [Header("Equipment")]
        [SerializeField] private SpriteRenderer _helmet;
        [SerializeField] private SpriteRenderer _bodyArmor;
        [SerializeField] private SpriteRenderer _sleeveLeft;
        [SerializeField] private SpriteRenderer _sleeveRight;
        [SerializeField] private SpriteRenderer _pantLegLeft;
        [SerializeField] private SpriteRenderer _pantLegRight;
        [SerializeField] private SpriteRenderer _bag;
    }
}