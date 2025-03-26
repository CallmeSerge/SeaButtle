using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering.Universal;
using UnityEngine.U2D;

public class GamePlay : MonoBehaviour
{
    [SerializeField] private Light2D _light;
    [SerializeField] private Light2D _lighning;
    [SerializeField] private ParticleSystem _rainFall;
    [SerializeField] private GameObject _aim;
    [SerializeField] private ParticleSystem _fog;
    [SerializeField] private bool _isNight;
    [SerializeField] private bool _isRaining;
    [SerializeField] private bool _isFog;
    private float _maxTimerForLight;
    private float _timer;

    private void Start()
    {
        if (_isNight)
        {
            _light.intensity = 0.015f;
            _maxTimerForLight = Random.Range(2.1f, 4.1f);
            StartCoroutine(Light());
        }
        if (_isRaining)
        {
            _rainFall.Play();
        }
        if (_isFog)
        {
            _fog.Play();
        }
    }
    
    IEnumerator Light()
    {
        while(true)
        {
            yield return new WaitForSeconds(4);
            Audio.AudioSourceEffects.PlayOneShot(Audio.Grom);
            _lighning.transform.position = new Vector2(Random.Range(_aim.transform.position.x - 7, _aim.transform.position.x + 7), _aim.transform.position.y + 4);
            _lighning.gameObject.SetActive(true);
            yield return new WaitForSeconds(Random.Range(0.5f, 1));
            _lighning.gameObject.SetActive(false);
            _timer = 0;
        }
    }
}
