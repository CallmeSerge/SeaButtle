using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotsManager : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _gun;
    [SerializeField] private float _timeRechargeInInspector;
    [SerializeField] private Image _rechargeImageLeft, _rechargeImageRight;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private Audio _audio;
    private Stack<GameObject> _bulletsUIInShotsManager;
    private float _timeRecharge;

    private void Start()
    {
        //_rechargeImage.color = Color.green;
        _bulletsUIInShotsManager = new Stack<GameObject>(_uiManager._countOfBullet);
        _bulletsUIInShotsManager = _uiManager._bulletsUI;
        _timeRecharge = _timeRechargeInInspector;
    }
    void Update()
    {
        if (_rechargeImageLeft.fillAmount == 1)
        {
            _rechargeImageLeft.color = Color.green;
        }
        else
        {
            _rechargeImageLeft.color = Color.red;
        }
        if (_rechargeImageRight.fillAmount == 1)
        {
            _rechargeImageRight.color = Color.green;
        }
        else
        {
            _rechargeImageRight.color = Color.red;
        }

        if (_timeRecharge < _timeRechargeInInspector)
        {
            _timeRecharge += Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.K) && _timeRecharge >= _timeRechargeInInspector && _bulletsUIInShotsManager.Count > 0)
        {
            Instantiate(_bulletPrefab, _gun.transform.position, Quaternion.identity);
            Audio.AudioSourceEffects.PlayOneShot(Audio.TorpedaGo);
            GameObject vibraniiBulletUI = _bulletsUIInShotsManager.Pop();
            vibraniiBulletUI.SetActive(false);
            _timeRecharge = 0;
        }
        _rechargeImageLeft.fillAmount = _timeRecharge / _timeRechargeInInspector;
        _rechargeImageRight.fillAmount = _timeRecharge / _timeRechargeInInspector;
        
    }
}
