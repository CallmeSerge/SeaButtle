using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    [SerializeField] private float _speedClouds;
    void Update()
    {
        transform.Translate(Vector2.right * _speedClouds * Time.deltaTime);  
    }
}
