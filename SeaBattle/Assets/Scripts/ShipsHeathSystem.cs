using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipsHeathSystem : MonoBehaviour
{
    [SerializeField] private float _hp;
    public void TakeDamage(float damage)
    {
        _hp = _hp - damage;

        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
