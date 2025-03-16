using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{ 
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _damage;
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
    }
}
