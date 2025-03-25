using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSourceMusic;
    [SerializeField] private AudioSource _audioSourceEffects;
    [SerializeField] private AudioClip _torpedaGo;
    [SerializeField] private AudioClip _torpedaRecharge;
    [SerializeField] private AudioClip _torpedaBoom;
    [SerializeField] private AudioClip _bulletBoom;
    [SerializeField] private AudioClip _grom;

    public static AudioSource AudioSourceEffects;
    public static AudioSource AudioSourceMusic;
    public static AudioClip TorpedaGo;
    public static AudioClip TorpedaRecharge;
    public static AudioClip TorpedaBoom;
    public static AudioClip BulletBoom;
    public static AudioClip Grom;

    private void Start()
    {
        AudioSourceMusic = _audioSourceMusic;
        AudioSourceEffects = _audioSourceEffects;
        TorpedaGo = _torpedaGo;
        TorpedaBoom = _torpedaBoom;
        BulletBoom = _bulletBoom;
        Grom = _grom;
    }
}
