using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipsManager : MonoBehaviour
{
    [SerializeField] private GameObject _tegForShipAwake;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private List<GameObject> _shipPrefabs;
    private void Start()
    {
        CreateShip();
    }

    public void CreateShip()
    {
        if (_shipPrefabs.Count > 0 && _uiManager._bulletsUI.Count > 0)
        {
            int selectedShip = Random.Range(0, _shipPrefabs.Count);
            GameObject newShip = Instantiate(_shipPrefabs[selectedShip], _tegForShipAwake.transform.position, Quaternion.identity);
            newShip.GetComponent<ShipsHeathSystem>().Construct(this);
            _shipPrefabs.RemoveAt(selectedShip);
        }
        else
        {
            _uiManager.GameOver();
        }
    }
}
