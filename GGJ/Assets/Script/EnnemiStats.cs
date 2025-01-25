using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiStats : MonoBehaviour
{

    public AudioClip bruitOiseaux;
    public float speed;
    public Sprite sprite;
    // Start is called before the first frame update

    public void OnServerInitialized(Ennemi ennemi)
    {
        speed = ennemi.speed;
        sprite = ennemi.sprite;
        bruitOiseaux = ennemi.bruitOiseaux;

        Debug.Log($"Enemy initialized with Speed: {speed}");

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
