using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testett : MonoBehaviour
{
    public float speed = 1000f;

    void Update()
    {
        // Déplace l'objet à gauche avec une vitesse contrôlable
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
