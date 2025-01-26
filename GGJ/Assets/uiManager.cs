using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    [SerializeField]
    private Image _start;
    [SerializeField]
    private Image _end;
    [SerializeField]
    private float _speed;

    private string _moveUI = "";

    private void Start()
    {
        afficheStart();
    }
    public void enleveStart()
    {
        _moveUI = "es";
    }
    public void afficheStart()
    {
        _moveUI = "as";
    }
    public void enleveEnd()
    {
        _moveUI = "ee";
    }
    public void afficheEnd()
    {
        _moveUI = "ae";
    }
    private void Update()
    {
        if (_moveUI == "es") 
        {
            _start.transform.position = Vector3.Lerp(_start.transform.position, new Vector3(_start.transform.position.x, 3000,0), _speed * Time.deltaTime);
        }
        if (_moveUI == "as")
        {
            _start.transform.position = Vector3.Lerp(_start.transform.position, new Vector3(_start.transform.position.x, 540), _speed * Time.deltaTime);
        }
        if (_moveUI == "ee")
        {
            _end.transform.position = Vector3.Lerp(_end.transform.position, new Vector3(_end.transform.position.x, -460), _speed * Time.deltaTime);
        }
        if (_moveUI == "ae")
        {
            _end.transform.position = Vector3.Lerp(_end.transform.position, new Vector3(_end.transform.position.x, 540), _speed * Time.deltaTime);
        }
    }
}
