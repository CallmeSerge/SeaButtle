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

    public static AudioSource AudioSourceEffects;
    public static AudioClip TorpedaGo;
    public static AudioClip TorpedaRecharge;
    public static AudioClip TorpedaBoom;

    private void Start()
    {
        AudioSourceEffects = _audioSourceEffects;
        TorpedaGo = _torpedaGo;
        TorpedaBoom = _torpedaBoom;
    }
}
