using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testett : MonoBehaviour
{
    public float speed = 1000f;

    void Update()
    {
        // D�place l'objet � gauche avec une vitesse contr�lable
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
