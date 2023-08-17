using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Movement : MonoBehaviour
{
    private const string Speed = "Speed";

    [SerializeField] private float _speed = 10;
    [SerializeField] private float _rotationSpeed = 240;
    private float _animationSwitch = 0.0f;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) 
            || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            _animationSwitch = 0.05f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * _speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * _rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W) == false && Input.GetKey(KeyCode.S) == false
            && Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false)
        {
            _animationSwitch = 0.0f;
        }

        _animator.SetFloat(Speed, _animationSwitch);
    }
}
