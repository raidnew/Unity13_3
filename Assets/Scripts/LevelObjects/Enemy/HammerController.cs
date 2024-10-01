using UnityEngine;

enum HammerState { Rocking, Crush, Relax }
public class HammerController : MonoBehaviour
{
    [SerializeField] private Animator _hammerAnimator;
    [SerializeField] private int _delayBeetweenCrush = 10;
    [SerializeField] private float _delayRandomBeetweenCrush = 3;
    [SerializeField] private int _relaxTime = 3;
    [SerializeField] private float _relaxTimeRandom = 3;

    private float _lastTimeCrush = 0;
    private float _startRelaxTime = 0;
    private HammerState _state = HammerState.Rocking;

    private void Update()
    {
        if (IsCrush())
        {
            StartCrush();
            StartRelax();
        }
        else if (IsStopRelax())
        {
            StopRelax();
        }
    }

    private void StartCrush()
    {
        _lastTimeCrush = Time.realtimeSinceStartup;
        _hammerAnimator.SetTrigger("Crush");
        _state = HammerState.Crush;
    }

    private void StopRelax()
    {
        _hammerAnimator.SetBool("IsRelax", false);
        _state = HammerState.Rocking;
        _delayRandomBeetweenCrush = Random.value;
    }

    private void StartRelax()
    {
        _startRelaxTime = Time.realtimeSinceStartup;
        _hammerAnimator.SetBool("IsRelax", true);
        _state = HammerState.Relax;
        _relaxTimeRandom = Random.value;
    }

    private bool IsCrush()
    {
        return (Time.realtimeSinceStartup - _lastTimeCrush + _delayRandomBeetweenCrush) > _delayBeetweenCrush && _state == HammerState.Rocking;
    }

    private bool IsStopRelax()
    {
        return (Time.realtimeSinceStartup - _startRelaxTime + _relaxTimeRandom) > _relaxTime && _state == HammerState.Relax;
    }

    private void OnDieAnimationFinish()
    {
        Destroy(gameObject);
    }
}
