using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private Vector3 _moveDirection;

    private void Update()
    {
        transform.position += _moveDirection * _speed * Time.deltaTime;
    }

    public void Instantiate(Vector3 moveDirection)
    {
        _moveDirection = moveDirection.normalized;

        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }
    }
}
