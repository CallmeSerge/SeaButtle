using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
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
        }
    }
}
