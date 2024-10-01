using System.Collections;
using UnityEngine;

public class CanUseGate : MonoBehaviour, IUsableObject
{
    [SerializeField] private Animator _animator;
    [SerializeField] private int _timeOpen;

    private ICanUse _touchedObject;

    public void Use()
    {
        StartCoroutine(GateAction());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_touchedObject == null && other.gameObject.GetComponent<ICanUse>() != null)
            _touchedObject = other.gameObject.GetComponent<ICanUse>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<ICanUse>() == _touchedObject)
            _touchedObject = null;
    }

    private IEnumerator GateAction()
    {
        _animator.SetTrigger("Open");
        yield return new WaitForSeconds(_timeOpen);
        _animator.SetTrigger("Close");
        yield return false;
    }

    private void Update()
    {
        if (Input.GetButtonDown(Constraints.Fire) && _touchedObject != null)
            Use();
    }
}
