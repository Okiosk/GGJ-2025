using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName ="GGJ/Ennemi")]

public class Ennemi : ScriptableObject
{
    public AudioClip bruitOiseaux;
    public float speed;
    public Sprite sprite;

}
