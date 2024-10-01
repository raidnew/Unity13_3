using System;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public static Action OnFinishComplete;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Ball>() != null)
            OnFinishComplete?.Invoke();
    }
}
