using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.PlayerLoop;

public class Wind : MonoBehaviour
{
    [Header("Wind settings")]
    [SerializeField] private float _radius = 2f;
    [SerializeField] private float _speed = 5f;

    private Vector2 _force;
    private MouseControls _controls;

    private void Awake()
    {
        _controls = GetComponent<MouseControls>();
    }

    private void Update()
    {
        _force = _controls._mouseDir * _controls._mouseSpeed;
        WindForce(_force);
    }

    private void WindForce(Vector2 force)
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, _radius);

        foreach (Collider2D target in targets)
        {
            if(target.TryGetComponent(out Bubble comp))
            {
                comp.Rb.AddForce(force);
            }
        }
    }


}