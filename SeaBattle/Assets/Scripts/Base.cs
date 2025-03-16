using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private ShipsManager _shipsManager;
    [SerializeField] private UIManager _uiManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ship"))
        {
            Destroy(collision.gameObject);
            if (_shipsManager._shipPrefabs.Count > 0)
            {
                _shipsManager.CreateShip();
            }
            else if (_shipsManager._shipPrefabs.Count == 0)
            {
                _uiManager.GameOver();
            }
        }
    }
}
