using System;
using UnityEngine;

public class FollowAndLookObject : MonoBehaviour
{
    public static Action<Vector3> OnSetViewsVector;

    [SerializeField] private Transform _followedObject;

    private Vector3 _vectroFromObjectToCamera;
    private float _distanceToObject;

    void Awake()
    {
        _vectroFromObjectToCamera = transform.position - _followedObject.position;
        _distanceToObject = _vectroFromObjectToCamera.magnitude;
    }

    void FixedUpdate()
    {
        Vector3 vectorFromCameraToObject = _followedObject.position - transform.position;
        vectorFromCameraToObject.Normalize();
        vectorFromCameraToObject *= _distanceToObject;
        transform.position = _followedObject.position - vectorFromCameraToObject;
        if (transform.position.y < _followedObject.position.y)
        {
            transform.position = new Vector3(transform.position.x, _followedObject.position.y, transform.position.z);
        }
        transform.LookAt(_followedObject.position);

        Vector3 look = transform.TransformDirection(Vector3.forward);
        OnSetViewsVector?.Invoke(look);
    }
}
