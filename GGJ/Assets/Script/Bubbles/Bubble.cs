using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;

    private Rigidbody2D _rb;

    [SerializeField] private float _throwForce = 5;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        transform.position = spawnPoint.position;

        //decides direction to throw
        float randomAngle = Random.Range(45, 90);
        Vector3 dir = Quaternion.AngleAxis(randomAngle, Vector3.up) * Vector3.forward;

        //throw the bubble
        _rb.AddForce(new Vector2(dir.x, dir.z).normalized * _throwForce);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if hit other thing than bubble, die
        if(!other.transform.TryGetComponent<Bubble>(out Bubble comp))
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
