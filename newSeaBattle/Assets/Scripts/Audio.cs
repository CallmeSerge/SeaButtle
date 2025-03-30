using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSourceMusic;
    [SerializeField] private AudioSource _audioSourceEffects;
    [SerializeField] private AudioSource _audioSourceWinFall;
    [SerializeField] private AudioClip _torpedaGo;
    [SerializeField] private AudioClip _torpedaRecharge;
    [SerializeField] private AudioClip _torpedaBoom;
    [SerializeField] private AudioClip _bulletBoom;
    [SerializeField] private AudioClip _grom;
    [SerializeField] private AudioClip _win;
    [SerializeField] private AudioClip _gameOver;

    public static AudioSource AudioSourceEffects;
    public static AudioSource AudioSourceMusic;
    public static AudioSource AudioSourceWinFall;
    public static AudioClip TorpedaGo;
    public static AudioClip TorpedaRecharge;
    public static AudioClip TorpedaBoom;
    public static AudioClip BulletBoom;
    public static AudioClip Grom;
    public static AudioClip Win;
    public static AudioClip GameOver;

    private void Start()
    {
        AudioSourceMusic = _audioSourceMusic;
        AudioSourceEffects = _audioSourceEffects;
        AudioSourceWinFall = _audioSourceWinFall;
        TorpedaGo = _torpedaGo;
        TorpedaBoom = _torpedaBoom;
        BulletBoom = _bulletBoom;
        Grom = _grom;
        Win = _win;
        GameOver = _gameOver;
    }
}
