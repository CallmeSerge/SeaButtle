using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering.Universal;
using UnityEngine.U2D;

public class GamePlay : MonoBehaviour
{
    [SerializeField] private Light2D _light;
    [SerializeField] private bool _isNight;
    [SerializeField] private ParticleSystem _rainFall;
    private float _maxTimerForLight;
    private float _timer;
    private void Start()
    {
        if (_isNight)
        {
            _rainFall.Play();
            _light.intensity = 0.01f;
            _maxTimerForLight = Random.Range(2.1f, 4.1f);
        }
    }
    void Update()
    {
        if (_isNight)
        {
            _timer += Time.deltaTime;
            if (_timer > _maxTimerForLight)
            {
                StartCoroutine(Light());
            }
        }
    }
    
    IEnumerator Light()
    {
        _light.intensity = 0.2f;
        yield return new WaitForSeconds(Random.Range(0.5f, 0.8f));
        _light.intensity = 0.01f;
        _timer = 0;
    }
}
