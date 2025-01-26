using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : MonoBehaviour
{

    public float speed;
    public float distanceFromGround;
    public float raycastLength;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        LayerMask mask = LayerMask.GetMask("Ground");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastLength, mask);

        if (hit.collider != null)
        {

            float targetY = hit.point.y + distanceFromGround;

            transform.position = new Vector2(transform.position.x, targetY);

            Vector2 groundNormal = hit.normal;  // Normale du sol détectée

            Debug.Log("Objet détecté : " + hit.collider.name);
        }


    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * raycastLength);
    }

}

