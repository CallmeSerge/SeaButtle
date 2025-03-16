using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipsManager : MonoBehaviour
{
    [SerializeField] private GameObject _tegForShipAwake;
    [field: SerializeField] public List<GameObject> _shipPrefabs { get; private set; }
    private void Start()
    {
        StartCoroutine(CreateShip());
    }

    IEnumerator CreateShip()
    {
        while (_shipPrefabs.Count > 0)
        {
            int selectedShip = Random.Range(0, _shipPrefabs.Count);
            Instantiate(_shipPrefabs[selectedShip], _tegForShipAwake.transform.position, Quaternion.identity);
            _shipPrefabs.RemoveAt(selectedShip);
            yield return new WaitForSeconds(5);
        }
    }
}
