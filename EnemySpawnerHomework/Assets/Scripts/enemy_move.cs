using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_move : MonoBehaviour
{
    private Vector2 _movementDirection;

    private float _speed = 5f;

    public void SetMovementDirection(Vector2 direction)
    {
        _movementDirection = direction.normalized;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(_movementDirection * _speed * Time.deltaTime);
    }

}
