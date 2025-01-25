using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseControls : MonoBehaviour
{
    [Header("Mouse Settings")]
    public float _mouseSpeed;
    private Vector3 _lastMousePos;
    private Vector3 _mousePos;
    public Vector2 _mouseDir;
    private void Start()
    {
        PosUpdate();
        InvokeRepeating("MouseDirUpdate", 0, .001f);
    }
    private void Update()
    {
        PosUpdate();
        _mouseDir = (new Vector2(_mousePos.x, _mousePos.y) - new Vector2(_lastMousePos.x, _lastMousePos.y));
    }

    private void PosUpdate()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        _mousePos.z = 0;

        transform.position = _mousePos;
    }

    public void MouseSpeedUpdate(InputAction.CallbackContext context)
    {
        _mouseSpeed = context.ReadValue<Vector2>().sqrMagnitude * 0.01f;
    }

    private void MouseDirUpdate()
    {
        _lastMousePos = _mousePos;
    }
}
