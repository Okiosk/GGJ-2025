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
    [SerializeField] GameObject _wind;
    public Vector2 WindStartPoint = Vector2.zero;
    public Vector2 WindEndPoint = Vector2.zero;

    private void Start()
    {
        PosUpdate();
        InvokeRepeating("MouseDirUpdate", 0, .001f);
    }

    private void Update()
    {
        PosUpdate();
        _mouseDir = (new Vector2(_mousePos.x, _mousePos.y) - new Vector2(_lastMousePos.x, _lastMousePos.y));

        if (WindStartPoint != Vector2.zero && WindEndPoint != Vector2.zero)
            SpawnWind();
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
        _mouseSpeed = context.ReadValue<Vector2>().sqrMagnitude * 0.1f;
        _mouseSpeed = Mathf.Clamp(_mouseSpeed, 0, 30);
    }

    public void TemporaryWind(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            WindStartPoint = _mousePos;
        }

        if(context.canceled)
        {
            WindEndPoint = _mousePos;
        }
    }

    private void SpawnWind()
    {
        var wind = Instantiate(_wind);
        wind.GetComponent<WindAI>().StartPoint = WindStartPoint;
        wind.GetComponent<WindAI>().EndPoint = WindEndPoint;

        WindStartPoint = Vector2.zero;
        WindEndPoint = Vector2.zero;
    }
}
