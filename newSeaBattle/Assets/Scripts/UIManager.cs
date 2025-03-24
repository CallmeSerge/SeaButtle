using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textGameOver;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _startTegForBullet;
    [SerializeField] private float _offset;
    [SerializeField] private GameObject _parentForBulletPrefab;
    [SerializeField] private Image _imagePause;
    [SerializeField] private GameObject _buttonReturn;
    [SerializeField] private GameObject _textWin;
    [SerializeField] private ShotsManager _shotsManager;
    [SerializeField] private ShipsManager _shipManager;
    [SerializeField] private TextMeshProUGUI _textShipCount;
    [SerializeField] private Image _redX;
    [SerializeField] private GameObject _buttonNextLevel;
    [SerializeField] private TextMeshProUGUI _textLevelName;
    [SerializeField] private GameObject _imageStrelkaLeft, _imageStrelkaRight;
    public Stack<GameObject> _bulletsUI { get; private set; }
    private int _shipCount;
    private bool _isMusicOff = false;

    private void Awake()
    {
        _textLevelName.text = SceneManager.GetActiveScene().name;
        _bulletsUI = new Stack<GameObject>(_shotsManager.CountOfBullet);
        for (int i = 0; i < _shotsManager.CountOfBullet; i++)
        {
            GameObject bulletUI = Instantiate(_bulletPrefab, _startTegForBullet.transform.position, Quaternion.identity);
            bulletUI.transform.SetParent(_parentForBulletPrefab.transform);
            _bulletsUI.Push(bulletUI);
            _startTegForBullet.transform.position = new Vector2(_startTegForBullet.transform.position.x + _offset, _startTegForBullet.transform.position.y);
        }
        _shipCount = _shipManager._shipPrefabs.Count;
        _textShipCount.text = _shipCount.ToString();
    }

    private void Start()
    {
        Invoke("StrelkiAwake", _shipManager.TimeForNewShipAwake);
        Invoke("StrelkiDelete", _shipManager.TimeForNewShipAwake + 3); 
    }

    public void GameOver()
    {
        _textGameOver.gameObject.SetActive(true);
        _buttonReturn.SetActive(true);
    }

    public void Win()
    {
        _textWin.SetActive(true);
        _buttonNextLevel.SetActive(true);
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

    public void MusicButton()
    {
        if ( _isMusicOff == false)
        {
            Audio.AudioSourceMusic.enabled = false;
            Audio.AudioSourceEffects.enabled = false;
            _redX.gameObject.SetActive(true);
            _isMusicOff = true;
        }
        else if ( _isMusicOff == true)
        {
            Audio.AudioSourceMusic.enabled = true;
            Audio.AudioSourceEffects.enabled = true;
            _redX.gameObject.SetActive(false);
            _isMusicOff = false;
        }

    }

    public void ReturnButton()
    {     
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CheckShipCountAndCheckWin()
    {
        _shipCount -= 1;
        _textShipCount.text = _shipCount.ToString();

            if ( _shipCount == 0 && _bulletsUI.Count > 0)
            {
                Win();
            }
    } 
    public void CheckFail()
    {
        if (_shipCount > 0 && _bulletsUI.Count == 0)
        {
            GameOver();
        }
    }

    public void ButtonNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void StrelkiAwake()
    {
        if (_shipManager._tegsForShipAwake[0].transform.position.x < 0)
        {
            _imageStrelkaLeft.SetActive(true);
        }
        else
        {
            _imageStrelkaRight.SetActive(true);
        }
    }

    private void StrelkiDelete()
    {
        _imageStrelkaLeft?.SetActive(false);
        _imageStrelkaRight?.SetActive(false);
    }
}
