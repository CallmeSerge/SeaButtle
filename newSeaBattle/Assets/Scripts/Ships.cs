using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ships : MonoBehaviour
{
    private Vector2 _tegForShipPosition;
    
    void Update()
    {
        if (_tegForShipPosition.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        transform.Translate(Vector2.right * Random.Range(1, 3) * Time.deltaTime);
    }

    public void Construct(Vector2 tegForShipPosition)
    {
        _tegForShipPosition = tegForShipPosition;
    }
}
