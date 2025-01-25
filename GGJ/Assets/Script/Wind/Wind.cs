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

    [Header("Mouse Settings")]
    private float _mouseSpeed;
    private Vector3 _lastMousePos;
    private Vector3 _mousePos;
    private Vector2 _mouseDir;
    private void Start()
    {
        PosUpdate();
        InvokeRepeating("MouseDirUpdate", 0, .001f);
    }
    private void Update()
    {
        PosUpdate();
        _mouseDir = (new Vector2(_mousePos.x, _mousePos.y) - new Vector2(_lastMousePos.x, _lastMousePos.y));
        WindForce();
    }

    private void PosUpdate()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        _mousePos.z = 0;

        transform.position = _mousePos;
    }

    public void MouseSpeedUpdate(InputAction.CallbackContext context)
    {
        _mouseSpeed = context.ReadValue<Vector2>().sqrMagnitude * 0.02f;
    }

    private void MouseDirUpdate()
    {
        _lastMousePos = _mousePos;
    }

    private void WindForce()
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, _radius);

        foreach (Collider2D target in targets)
        {
            if(target.TryGetComponent(out Bubble comp))
            {
                comp.Rb.AddForce(_mouseDir * _mouseSpeed);
            }
        }
    }
}