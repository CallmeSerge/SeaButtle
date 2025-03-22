using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipsManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _tegsForShipAwake;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private float _timeForNewShipAwake;
    [field:SerializeField] public List<GameObject> _shipPrefabs { get; private set; }
    [field:SerializeField] public GameObject _newShip { get; private set; }
    private bool _isGameOver = false;
    private void Start()
    {
        StartCoroutine(CreateShip());
    }

    IEnumerator CreateShip()
    {
        if (_shipPrefabs.Count > 0 && _uiManager._bulletsUI.Count > 0)
        {
            if(_isGameOver == false)
            {
                    int selectedShip = Random.Range(0, _shipPrefabs.Count);
                    _newShip = Instantiate(_shipPrefabs[selectedShip], _tegsForShipAwake[Random.Range(0, _tegsForShipAwake.Length)].transform.position, Quaternion.identity);
                    _newShip.GetComponent<ShipsHeathSystem>().Construct(this, _uiManager);
                    _shipPrefabs.RemoveAt(selectedShip);
                    yield return new WaitForSeconds(_timeForNewShipAwake);
                    StartCoroutine(CreateShip()); 
            }
        }
    }

    public void IsGameOver()
    {
        _isGameOver = true;
    }





























    /*public void CreateShipTest()
    {
        if (_shipPrefabs.Count > 0 && _uiManager._bulletsUI.Count > 0)
        {
            if (_isGameOver == false)
            {
                while (true)
                {
                    int selectedShip = Random.Range(0, _shipPrefabs.Count);
                    _newShip = Instantiate(_shipPrefabs[selectedShip], _tegsForShipAwake[Random.Range(0, _tegsForShipAwake.Length)].transform.position, Quaternion.identity);
                    _newShip.GetComponent<ShipsHeathSystem>().Construct(this);
                    _shipPrefabs.RemoveAt(selectedShip);
                    _uiManager.CheckShipCount();

                }
            }
        }
        else if (_shipPrefabs.Count == 0)
        {
            _uiManager.Win();
            _uiManager.CheckShipCount();
        }
        else
        {
            _uiManager.GameOver();
        }
    }*/
}
