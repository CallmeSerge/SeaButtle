using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _imageGameOverRussian, _imageGameOverEnglish;
    [SerializeField] private GameObject _imageWinRussian, _imageWinEnglish;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _startTegForBullet;
    [SerializeField] private GameObject _parentForBulletPrefab;
    [SerializeField] private Image _imagePause;
    [SerializeField] private GameObject _buttonReturn;
    [SerializeField] private ShotsManager _shotsManager;
    [SerializeField] private ShipsManager _shipManager;
    [SerializeField] private TextMeshProUGUI _textShipCount;
    [SerializeField] private Image _redX;
    [SerializeField] private GameObject _buttonNextLevel;
    [SerializeField] private TextMeshProUGUI _textLevelName;
    [SerializeField] private GameObject _imageStrelkaLeft, _imageStrelkaRight;
    [SerializeField] private GameObject _buttonRussian, _buttonEnglish;
    [SerializeField] private GameObject _buttonRight, _buttonLeft;
    [SerializeField] private GameObject _buttonPause;
    [SerializeField] private GameObject _buttonMusic;
    [SerializeField] private GameObject _startTextRussian, _startTextEnglish;
    [SerializeField] private ParticleSystem _confettiPrefab;
    [SerializeField] private GameObject _aim;
    public Stack<GameObject> _bulletsUI { get; private set; }
    public bool _isMovingRight { get; private set; } = false;
    public bool _isMovingLeft { get; private set; } = false;
    public bool _isGameOver { get; private set; } = false;
    private int _shipCount;
    private bool _isMusicOff = false;
    private string _currentLanguage;
    private float _offset = 50;

    private void Awake()
    {
        if (YandexGame.savesData.saveLanguage == null)
        {
                _buttonRussian.SetActive(true);
                _textLevelName.text = "Уровень " + SceneManager.GetActiveScene().buildIndex;
                YandexGame.savesData.saveLanguage = "ru";
                YandexGame.SaveProgress();
                _startTextRussian.SetActive(true);
        }
        else
        {
                if (YandexGame.savesData.saveLanguage == "ru")
                    {
                        _buttonRussian.SetActive(true);
                        _textLevelName.text = "Уровень " + SceneManager.GetActiveScene().buildIndex;
                        _startTextRussian.SetActive(true);

            }
            else if (YandexGame.savesData.saveLanguage == "en")
                    {
                        _buttonEnglish.SetActive(true);
                        _textLevelName.text = "Level " + SceneManager.GetActiveScene().buildIndex;
                        _startTextEnglish.SetActive(true);  
                    }
        }


        if (YandexGame.EnvironmentData.isMobile)
        {
            _buttonLeft.SetActive(true);
            _buttonRight.SetActive(true);
        }

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

    public IEnumerator GameOver()
    {
        if (_isGameOver == false)
        {
            if (_currentLanguage == "ru")
            {
                _imageGameOverRussian.SetActive(true);
            }
            else
            {
                _imageGameOverEnglish.SetActive(true);
            }
            Audio.AudioSourceWinFall.PlayOneShot(Audio.GameOver);
            _buttonPause.SetActive(false);
            _buttonMusic.SetActive(false);
            _buttonRussian.SetActive(false);
            _buttonEnglish.SetActive(false);
            Audio.AudioSourceMusic.enabled = false;
            Audio.AudioSourceEffects.enabled = false;
            _isGameOver = true;
            yield return new WaitForSeconds(2);
            _buttonReturn.SetActive(true);
        }
    }

    IEnumerator Win()
    {
        if (_currentLanguage == "ru")
        {
            _imageWinRussian.SetActive(true);
        }
        else
        {
            _imageWinEnglish.SetActive(true);
        }
        ParticleSystem confetti = Instantiate(_confettiPrefab, _aim.transform.position, Quaternion.identity);
        confetti.Play();
        Audio.AudioSourceWinFall.PlayOneShot(Audio.Win);
        _buttonPause.SetActive(false);
        _buttonMusic.SetActive(false);
        _buttonRussian.SetActive(false);
        _buttonEnglish.SetActive(false);
        Audio.AudioSourceMusic.enabled = false;
        Audio.AudioSourceEffects.enabled = false;
        YandexGame.savesData.sceneForLoad = SceneManager.GetActiveScene().buildIndex + 1;
        YandexGame.SaveProgress();
        yield return new WaitForSeconds(4);
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

            if ( _shipCount == 0 && _bulletsUI.Count >= 0)
            {
                StartCoroutine(Win());
            }
    } 
    public void CheckFail()
    {
        if (_shipCount > 0 && _bulletsUI.Count == 0)
        {
            StartCoroutine(GameOver());
        }
    }

    public void ButtonNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex != 20)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            YandexGame.FullscreenShow();
        }
        else
        {
            SceneManager.LoadScene("EndGame");
        }
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

    public void ButtonLanguage()
    {
        if (_buttonRussian.activeSelf == true)
        {
            YandexGame.savesData.saveLanguage = "en";
            _textLevelName.text = "Level " + SceneManager.GetActiveScene().buildIndex;
            _buttonEnglish.SetActive(true);
            _buttonRussian.SetActive(false);
        }
        else if (_buttonEnglish.activeSelf == true)
        {
            YandexGame.savesData.saveLanguage = "ru";
            _textLevelName.text = "Уровень " + SceneManager.GetActiveScene().buildIndex;
            _buttonEnglish.SetActive(false);
            _buttonRussian.SetActive(true);
        }
    }

    public void StartTextOff()
    {
        _startTextRussian?.SetActive(false);
        _startTextEnglish?.SetActive(false);
    }

    public void AimMoveRight()
    {
        _isMovingRight = true;
    }
    public void AimMoveLeft()
    {
        _isMovingLeft = true;
    }
    public void AimStop()
    {
        _isMovingLeft = false;
        _isMovingRight = false;
    }
}
