using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailRendererReset : MonoBehaviour
{
    private TrailRenderer _trail;
    private float _bornTime;

    private void Awake()
    {
        _trail = GetComponent<TrailRenderer>();
    }
    void Start()
    {
        TrailReset();
    }

    void Update()
    {
        if (_bornTime + .1f < Time.time)
            _trail.time = .2f;
    }

    public void TrailReset()
    {
        _trail.time = 0;
        _bornTime = Time.time;
    }
}