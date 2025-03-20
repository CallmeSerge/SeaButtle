using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PeriskopMove : MonoBehaviour
{
    [SerializeField] private float _periskopSpeed;
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * _periskopSpeed * Time.deltaTime);
            if (transform.position.x < -21)
            {
                transform.position = new Vector2(-21, transform.position.y);
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * _periskopSpeed * Time.deltaTime);
            if (transform.position.x > 21)
                {
                    transform.position = new Vector2(21, transform.position.y);
                }
        }
    }
}
