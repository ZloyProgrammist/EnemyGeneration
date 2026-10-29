using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _stopMoveDistance = 0.2f;
    [SerializeField] private Transform _target;
    
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MoveToTarget();
    }

    public void Instantiate(Transform target)
    {
        _target = target;
    }

    private void MoveToTarget()
    {
        if (_target == null)
            return;
        
        Vector3 targetPosition = _target.position - _rigidbody.position;

        if (targetPosition.sqrMagnitude <= _stopMoveDistance * _stopMoveDistance)
            return;

        Vector3 direction = targetPosition.normalized;
        Vector3 newPosition = _rigidbody.position + direction * _speed * Time.deltaTime;

        _rigidbody.MovePosition(newPosition);
        _rigidbody.rotation = Quaternion.LookRotation(direction);
    }
}
