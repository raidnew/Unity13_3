using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]
public class InteractiveObject : MonoBehaviour, IControlledObject
{
    [SerializeField] private int _maxCountJump = 2;
    [SerializeField] private Transform _viewsObject;
    [SerializeField] private float _jumpPower = 400;
    [SerializeField] private float _speed = 2;
    private bool _isAlive = true;
    private int _countJump = 0;
    private Rigidbody _rbBall;
    private Vector3 _vectorForce;
    private Vector3 _vectorForward;

    public void SetHorisontal(float horisontal)
    {
        _vectorForce.x = horisontal;
    }

    public void SetVertical(float vertical)
    {
        _vectorForce.z = vertical;
    }

    public void AddForce(Vector3 force)
    {
        _vectorForce = force;
    }

    public void Jump()
    {
        if (_countJump++ < _maxCountJump)
            _rbBall.AddForce(Vector3.up * _jumpPower);
    }

    private void OnEnable()
    {
        Ball.OnStartDie += OnPlayerStartDie;
    }

    private void OnDisable()
    {
        Ball.OnStartDie -= OnPlayerStartDie;
    }

    private void Awake()
    {
        _rbBall = GetComponent<Rigidbody>();
        FollowAndLookObject.OnSetViewsVector += OnSetForwardVector;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.GetComponent<IGround>() != null)
            _countJump = 0;
    }

    private void FixedUpdate()
    {
        _rbBall.AddForce(GetForceVector());
    }

    private void OnSetForwardVector(Vector3 forwardVector)
    {
        _vectorForward = forwardVector;
    }

    private void OnPlayerStartDie()
    {
        _isAlive = false;
        _rbBall.velocity = Vector3.zero;
        _rbBall.angularVelocity = Vector3.zero;
        _rbBall.isKinematic = false;
    }

    private Vector3 GetForceVector()
    {
        if(!_isAlive) 
            return Vector3.zero;
        Vector3 forwardVector = transform.position - _viewsObject.position;
        Vector3 sideVelocityDirection = Vector3.Cross(Vector3.up, _vectorForward);
        Vector3 forwardVelocityDirection = new Vector3(_vectorForward.x, 0, _vectorForward.z);
        sideVelocityDirection *= _vectorForce.x;
        forwardVelocityDirection *= _vectorForce.z;
        Vector3 _forceDirection = sideVelocityDirection + forwardVelocityDirection;
        _forceDirection.Normalize();
        _forceDirection *= _speed;
        return _forceDirection;
    }
}
