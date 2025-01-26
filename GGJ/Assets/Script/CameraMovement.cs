using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Pool _bubblePool;
    [SerializeField] private Transform _child;
    private float _yOffset;

    [SerializeField] private mapCreation _map;

    public float targetX;

    [SerializeField] float _speed = 6;

    private void Start()
    {
        _yOffset = Mathf.Abs(transform.position.y - _child.position.y);

        InvokeRepeating("TargetX", 0, 1);
    }
    private void TargetX()
    {
        /*float sumX = 0;
        int nbActive = 0;
        foreach (var bubble in _bubblePool._objPool)
        {
            if (bubble.activeSelf)
            {
                sumX += bubble.transform.position.x;
                nbActive++;
            }
        }
        targetX = sumX/nbActive;*/
        targetX = _child.position.x;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float yMove = _child.position.y + _yOffset;
        float xMove = transform.position.x;

        
        if (transform.position.x < targetX)
            xMove += _speed * Time.deltaTime;
        else if (transform.position.x > targetX)
            xMove -= _speed * Time.deltaTime;

        xMove = Mathf.Clamp(xMove, 0, _map.tailleMap - 5);

        Vector3 targetPos = new Vector3(xMove, yMove, -10);
        targetPos = Vector3.Lerp(transform.position, targetPos, .3f);
        targetPos.z = -10;
        transform.position = targetPos;
    }
}
