using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyComportement : MonoBehaviour
{
    
    public float speed;
    public float distanceFromGround;
    public float raycastLength;
    public float rotationSpeed; 

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        LayerMask mask = LayerMask.GetMask("Ground");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastLength, mask);

        if (hit.collider != null)
        {

            float targetY = hit.point.y + distanceFromGround;
            
            transform.position = new Vector2(transform.position.x, targetY);

            Vector2 groundNormal = hit.normal;  // Normale du sol détectée


            float targetRotation = Mathf.Atan2(groundNormal.y, groundNormal.x) * Mathf.Rad2Deg - 90f; //calcule l'angl entre l'axe horizontal et la normale du sol / convertit en degrés
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, targetRotation), rotationSpeed * Time.deltaTime);

            Debug.Log("Objet détecté : " + hit.collider.name);      
        }

       
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * raycastLength);
    }

}
