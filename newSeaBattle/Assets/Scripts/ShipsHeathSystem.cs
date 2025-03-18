using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipsHeathSystem : MonoBehaviour
{
    [SerializeField] private float _hp;
    private ShipsManager _shipsManager;

    public void Construct(ShipsManager shipsManager)
    {
        _shipsManager = shipsManager;
    }
    public void TakeDamage(float damage)
    {
        _hp = _hp - damage;

        if (_hp <= 0)
        {
            _shipsManager.CreateShip();
            Destroy(gameObject);
        }
    }
}
