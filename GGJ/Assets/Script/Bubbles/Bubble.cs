using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private Transform _spawnPoint;

    public Rigidbody2D Rb;
    private Animator _anim;

    [SerializeField] private float _throwForce = 5;

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _spawnPoint = GameObject.Find("BubbleSpawnPoint").GetComponent<Transform>();
    }

    private void OnEnable()
    {
        Rb.bodyType = RigidbodyType2D.Dynamic;
        _anim.SetTrigger("~live");
        transform.position = _spawnPoint.position;

        //decides direction to throw
        float randomAngle = Random.Range(45, 90);
        Vector3 dir = Quaternion.AngleAxis(randomAngle, Vector3.up) * Vector3.forward;

        //throw the bubble
        Rb.AddForce(new Vector2(dir.x, dir.z).normalized * _throwForce);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if hit other thing than bubble, die
        if(!other.transform.TryGetComponent(out Bubble comp))
        {
            Rb.bodyType = RigidbodyType2D.Static;
            _anim.SetTrigger("~die");
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
