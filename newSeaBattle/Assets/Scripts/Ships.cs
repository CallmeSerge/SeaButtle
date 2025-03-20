using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ships : MonoBehaviour
{
    [SerializeField] private float _shipSpeed;
    
    void Update()
    {
        transform.Translate(Vector2.right * _shipSpeed * Time.deltaTime);
    }
}
