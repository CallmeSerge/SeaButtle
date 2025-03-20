using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipsManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _tegsForShipAwake;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private List<GameObject> _shipPrefabs;
    private bool _isGameOver = false;
    private void Start()
    {
        CreateShip();
    }

    public void CreateShip()
    {
        if (_shipPrefabs.Count > 0 && _uiManager._bulletsUI.Count > 0)
        {
            if(_isGameOver == false)
            {
                int selectedShip = Random.Range(0, _shipPrefabs.Count);
                GameObject newShip = Instantiate(_shipPrefabs[selectedShip], _tegsForShipAwake[Random.Range(0, _tegsForShipAwake.Length)].transform.position, Quaternion.identity);
                newShip.GetComponent<ShipsHeathSystem>().Construct(this);
                _shipPrefabs.RemoveAt(selectedShip);
            }
        }
        else if (_shipPrefabs.Count == 0)
        {
            _uiManager.Win();
        }
        else
        {
            _uiManager.GameOver();
        }
    }

    public void IsGameOver()
    {
        _isGameOver = true;
    }
}
