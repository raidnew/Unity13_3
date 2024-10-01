using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleSystemEffect : MonoBehaviour
{
    public Action OnHasCompletedEffect;

    private ParticleSystem _particleSystem;

    public void Play()
    {
        _particleSystem.Play();
    }

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnParticleSystemStopped()
    {
        OnHasCompletedEffect?.Invoke();
    }

}
