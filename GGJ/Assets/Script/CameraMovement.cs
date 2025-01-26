using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Pool _bubblePool;
    [SerializeField] private Transform _child;
    private float _yOffset;

    [SerializeField] float _speed;

    private void Start()
    {
        _yOffset = Mathf.Abs(transform.position.y - _child.position.y);
    }
    private float TargetX()
    {
        float sumX = 0;
        int nbActive = 0;
        foreach (var bubble in _bubblePool._objPool)
        {
            if (bubble.activeSelf)
            {
                sumX += bubble.transform.position.x;
                nbActive++;
            }
        }
        return sumX/nbActive;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float yMove = _child.position.y + _yOffset;
        float xMove = transform.position.x;

        float targetX = TargetX();
        if (transform.position.x < targetX)
            xMove += _speed * Time.deltaTime;
        else if (transform.position.x > targetX)
            xMove -= _speed * Time.deltaTime;

        transform.position = new Vector2 (xMove, yMove);
    }
}
