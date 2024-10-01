using System;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] private Transform _followedObject;
    private Vector3 _vectorToObject;

    void Awake()
    {
        _vectorToObject = transform.position - _followedObject.position;
    }

    void FixedUpdate()
    {
        transform.position = _followedObject.position + _vectorToObject;
    }
}
