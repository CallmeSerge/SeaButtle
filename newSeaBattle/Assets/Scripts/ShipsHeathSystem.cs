using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipsHeathSystem : MonoBehaviour
{
    [SerializeField] private float _hp;
    [SerializeField] private ParticleSystem _shipBoomPrefab;
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
            Audio.AudioSourceEffects.PlayOneShot(Audio.TorpedaBoom);
            _shipsManager.CreateShip();
            ParticleSystem shipBoom = Instantiate(_shipBoomPrefab);
            shipBoom.transform.position = transform.position;
            shipBoom.Play();
            Destroy(gameObject);
        }
    }
}
