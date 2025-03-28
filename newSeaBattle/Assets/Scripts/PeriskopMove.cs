using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PeriskopMove : MonoBehaviour
{
    [SerializeField] private float _periskopSpeed;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private UIManager _uiManager;
    void FixedUpdate()
    {
        if (_uiManager._isGameOver == false)
        {
            if (Input.GetKey(KeyCode.A))
            {
                _rb.AddForce(Vector2.left * _periskopSpeed);
            }
            if (transform.position.x < -21)
            {
                transform.position = new Vector2(-21, transform.position.y);
            }

            if (Input.GetKey(KeyCode.D))
            {
                _rb.AddForce(Vector2.right * _periskopSpeed);
            }
            if (transform.position.x > 21)
            {
                transform.position = new Vector2(21, transform.position.y);
            }
        }
    }
}
