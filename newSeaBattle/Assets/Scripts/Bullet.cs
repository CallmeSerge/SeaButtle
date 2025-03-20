using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour
{ 
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _damage;
    private void Start()
    {
        Tween bulletScale = transform.DOScale(0.01f, 4);
        bulletScale.SetLink(gameObject);
    }
    void Update()
    {
        transform.Translate(Vector2.up * _bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ship"))
        {
            collision.GetComponent<ShipsHeathSystem>().TakeDamage(_damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.name == "Horizont")
        {
            Destroy(gameObject);    
        }
    }
}
