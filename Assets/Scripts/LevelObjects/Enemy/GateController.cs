using UnityEngine;

enum GateState { Open, Close }

public class GateController : MonoBehaviour
{
    [SerializeField] private Animator _gateAnimator;
    [SerializeField] private int _durationOpen;
    [SerializeField] private float _durationOpenRandom;
    [SerializeField] private int _durationRotate;
    [SerializeField] private float _durationRotateRandom;

    private float _timeOpen = 0;
    private float _timeClose = 0;
    private GateState _gateState = GateState.Close;

    void Update()
    {
        if (IsOpenGate())
            OpenGate();
        if (IsCloseGate())
            CloseGate();
    }

    private bool IsOpenGate()
    {
        return (Time.realtimeSinceStartup - _timeClose + _durationRotateRandom) > _durationRotate && _gateState == GateState.Close;

    }
    private bool IsCloseGate()
    {
        return (Time.realtimeSinceStartup - _timeOpen + _durationOpenRandom) > _durationOpen && _gateState == GateState.Open;
    }

    private void OpenGate()
    {
        _timeOpen = Time.realtimeSinceStartup;
        _gateState = GateState.Open;
        _gateAnimator?.SetTrigger("Open");
        _durationOpenRandom = Random.value;
    }

    private void CloseGate()
    {
        _timeClose = Time.realtimeSinceStartup;
        _gateState = GateState.Close;
        _gateAnimator?.SetTrigger("Close");
        _durationRotateRandom = Random.value;
    }

    private void OnDieAnimationFinish()
    {
        Destroy(gameObject);
    }
}
