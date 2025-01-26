using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : MonoBehaviour
{
    public float speed;
    public float distanceFromGround;
    public float raycastLength;

    private CameraMovement _camMov;
    public bool CanMove = false;

    private Animator _anim;

    private void Awake()
    {
        _camMov = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (CanMove)
        {
            _anim.SetTrigger("trRun");
            float targetY = transform.position.y;
            float targetX = transform.position.x + speed * Time.deltaTime;

            //if (Mathf.Abs(transform.position.x - _camMov.targetX) > 2)
            //targetX = _camMov.targetX;

            LayerMask mask = LayerMask.GetMask("Ground");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastLength, mask);

            if (hit.collider != null)
            {
                targetY = hit.point.y + distanceFromGround;
                transform.position = new Vector2(transform.position.x, targetY);
            }
            transform.position = new Vector3(targetX, targetY, 0);
        }


    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * raycastLength);
    }

}

