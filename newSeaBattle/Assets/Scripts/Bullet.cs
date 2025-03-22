using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour
{ 
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _damage;
    [SerializeField] private ParticleSystem _bulletBoom;
    private UIManager _uiManager;
    private void Start()
    {
        Tween bulletScale = transform.DOScale(0.01f, 4);
        bulletScale.SetLink(gameObject);
    }
    void Update()
    {
        transform.Translate(Vector2.up * _bulletSpeed * Time.deltaTime);
    }

    public void Construct(UIManager uiManager)
    {
        _uiManager = uiManager;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ship"))
        {
            collision.GetComponent<ShipsHeathSystem>().TakeDamage(_damage);
            Destroy(gameObject);
        }
        if (collision.CompareTag("rock"))
        {
            Audio.AudioSourceEffects.PlayOneShot(Audio.BulletBoom);
            ParticleSystem bulletBoom = Instantiate(_bulletBoom, transform.position, Quaternion.identity);
            bulletBoom.Play();
            _uiManager.CheckFail();
            Destroy(gameObject);
        }
        if (collision.CompareTag("horizont"))
        {
            _uiManager.CheckFail();
            Destroy(gameObject);
        }
    }
}
