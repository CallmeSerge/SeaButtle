using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ships : MonoBehaviour
{
    //[SerializeField] private float _shipSpeed;
    
    void Update()
    {
        transform.Translate(Vector2.right * Random.Range(1,3) * Time.deltaTime);
    }
}
