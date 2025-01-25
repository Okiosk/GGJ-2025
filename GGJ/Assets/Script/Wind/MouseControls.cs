using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseControls : MonoBehaviour
{
    [Header("Mouse Settings")]
    public float _mouseSpeed;
    private Vector3 _lastMousePos;
    private Vector3 _mousePos;
    public Vector2 _mouseDir;

    public List<Vector2> temporaryWindPoints;
    public float temporaryWindTime;
    public float temporaryWindLifetime = 5f;
    public float setPointTime;
    public float setPointCooldown = .001f;

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

    private void MouseDirUpdate()
    {
        _lastMousePos = _mousePos;
    }

    public void MouseSpeedUpdate(InputAction.CallbackContext context)
    {
        _mouseSpeed = context.ReadValue<Vector2>().sqrMagnitude * 0.01f;
    }

    public void TemporaryWind(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if(setPointTime + setPointCooldown < Time.time)
                temporaryWindPoints.Add(_mousePos);
        }


    }
}
