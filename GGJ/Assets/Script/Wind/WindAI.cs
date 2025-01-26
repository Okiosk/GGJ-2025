using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindAI : MonoBehaviour
{
    public Vector2 StartPoint;
    public Vector2 EndPoint;
    private float _bornTime;
    [SerializeField] private float _lifeTime;

    [SerializeField] public float Speed = 25f;

    private Coroutine _coroutine;

    private void Awake()
    {
        _bornTime = Time.time;
    }
    private void Update()
    {
        if (_bornTime + _lifeTime < Time.time)
            Destroy(gameObject);

        if (_coroutine == null)
            _coroutine = StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        GetComponent<TrailRendererReset>().TrailReset();
        transform.position = StartPoint;
        float dist = Vector3.Distance(transform.position, EndPoint);
        float startDist = dist;

        //make the wind travel the distance
        while (dist > 0)
        {
            transform.position = Vector3.Lerp(StartPoint, EndPoint, 1 - dist / startDist);
            dist -= Speed * Time.deltaTime;
            yield return null;
        }
        _coroutine = null;
    }
}
