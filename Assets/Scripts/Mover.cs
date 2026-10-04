using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _inputReader.JumpButtonPressed += Jump;
        _inputReader.MovementButtonPressed += Move;
    }

    private void OnDisable()
    {
        _inputReader.JumpButtonPressed -= Jump;
        _inputReader.MovementButtonPressed -= Move;
    }

    private void Jump()
    {
        _rigidbody2D.linearVelocity = Vector2.up * _speed;
    }

    private void Move(float movementValue)
    {
        Debug.Log(movementValue);
        Vector2 movement = Vector2.right * (movementValue * Time.deltaTime);
        transform.Translate(movement);
    }
}
