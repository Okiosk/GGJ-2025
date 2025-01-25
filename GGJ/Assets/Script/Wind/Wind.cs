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

    private Vector2 _force;
    private MouseControls _controls;
    private WindAI _ai;
    private bool _isPlayer = false;

    private void Awake()
    {
        if(TryGetComponent(out _controls))
            _isPlayer = true;
        else
            _ai = GetComponent<WindAI>();
    }

    private void Update()
    {
        if (_isPlayer)
            _force = _controls._mouseDir * _controls._mouseSpeed;
        else
        {
            _force = (_ai.EndPoint - _ai.StartPoint).normalized * 0.1f;
        }

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