using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textGameOver;
    [field:SerializeField] public int _countOfBullet { get; private set; }
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _startTegForBullet;
    [SerializeField] private float _offset;
    [SerializeField] private GameObject _parentForBulletPrefab;
    public Stack<GameObject> _bulletsUI { get; private set; }

    private void Awake()
    {
        _bulletsUI = new Stack<GameObject>(_countOfBullet);
        for (int i = 0; i < _countOfBullet; i++)
        {
            GameObject bulletUI = Instantiate(_bulletPrefab, _startTegForBullet.transform.position, Quaternion.identity);
            bulletUI.transform.SetParent(_parentForBulletPrefab.transform);
            _bulletsUI.Push(bulletUI);
            _startTegForBullet.transform.position = new Vector2(_startTegForBullet.transform.position.x + _offset, _startTegForBullet.transform.position.y);
        }
    }
    public void GameOver()
    {
        _textGameOver.gameObject.SetActive(true);
    }
}
