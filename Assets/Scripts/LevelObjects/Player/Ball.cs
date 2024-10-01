using System;
using UnityEngine;

public class Ball : MonoBehaviour, ICanUse
{
    public static Action OnDie;
    public static Action OnStartDie;
    private Rigidbody _ball;

    [SerializeField] private ParticleSystemEffect _diesEffect;
    private bool _isAlive = true;

    private void Awake()
    {
        _diesEffect.OnHasCompletedEffect += OnDieEffectComplete;
        _ball = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IDamager>() != null)
        {
            Die();
        }
    }

    private void Die()
    {
        if (!_isAlive) return;
        _isAlive = false;
        OnStartDie?.Invoke();
        GetComponent<Renderer>().enabled = false;
        if (_diesEffect == null) 
            OnDie?.Invoke();
        else
            _diesEffect.Play();

    }

    private void OnDieEffectComplete()
    {
        OnDie?.Invoke();
    }

}
