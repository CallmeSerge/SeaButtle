using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textGameOver;
    [field:SerializeField] public int _countOfBullet { get; private set; }
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _startTegForBullet;
    [SerializeField] private float _offset;
    [SerializeField] private GameObject _parentForBulletPrefab;
    [SerializeField] private Image _imagePause;
    [SerializeField] private GameObject _buttonReturn;
    [SerializeField] private GameObject _textWin;
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
        _buttonReturn.SetActive(true);
    }

    public void Win()
    {
        _textWin.SetActive(true);
    }

    public void PauseButton()
    {
        if (Time.timeScale == 1)
        {
            _imagePause.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else if (Time.timeScale == 0)
        {
            _imagePause.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void ReturnButton()
    {     
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
