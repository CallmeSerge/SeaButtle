using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotsManager : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _gun;
    [SerializeField] private float _timeRechargeInInspector;
    [SerializeField] private Image _rechargeImage;
    [SerializeField] private UIManager _uiManager;
    private Stack<GameObject> _bulletsUIInShotsManager;
    private float _timeRecharge;

    private void Start()
    {
        _bulletsUIInShotsManager = new Stack<GameObject>(_uiManager._countOfBullet);
        _bulletsUIInShotsManager = _uiManager._bulletsUI;
        _timeRecharge = _timeRechargeInInspector;
    }
    void Update()
    {
        if (_timeRecharge < _timeRechargeInInspector)
        {
            _timeRecharge += Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.K) && _timeRecharge >= _timeRechargeInInspector && _bulletsUIInShotsManager.Count > 0)
        {
            Instantiate(_bulletPrefab, _gun.transform.position, Quaternion.identity);
            GameObject vibraniiBulletUI = _bulletsUIInShotsManager.Pop();
            vibraniiBulletUI.SetActive(false);
            _timeRecharge = 0;
        }
        _rechargeImage.fillAmount = _timeRecharge / _timeRechargeInInspector;
    }
}
