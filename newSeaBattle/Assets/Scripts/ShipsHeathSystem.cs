using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipsHeathSystem : MonoBehaviour
{
    [SerializeField] private float _hp;
    [SerializeField] private ParticleSystem _shipBoomPrefab;
    [SerializeField] private ParticleSystem _shipFire;
    private ShipsManager _shipsManager;
    private UIManager _uiManager;

    public void Construct(ShipsManager shipsManager, UIManager uiManager)
    {
        _shipsManager = shipsManager;
        _uiManager = uiManager;
    }
    public void TakeDamage(float damage)
    {
        _hp = _hp - damage;
        _uiManager.CheckFail();
        if (_hp <= 0)
        {
            Audio.AudioSourceEffects.PlayOneShot(Audio.TorpedaBoom);
            //_shipsManager.CreateShip();
            ParticleSystem shipBoom = Instantiate(_shipBoomPrefab);
            shipBoom.transform.position = transform.position;
            shipBoom.Play();
            _uiManager.CheckShipCountAndCheckWin();
            Destroy(gameObject);
        }
        else 
        {
            Audio.AudioSourceEffects.PlayOneShot(Audio.BulletBoom);
            ParticleSystem shipFire = Instantiate(_shipFire, transform.position, Quaternion.identity);
            shipFire.transform.SetParent(transform);
            shipFire.Play(); 
        }
    }
}
