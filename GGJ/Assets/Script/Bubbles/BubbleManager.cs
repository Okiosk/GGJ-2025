using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    private Pool _pool;
    [SerializeField] private float _spawnInterval = .1f;
    private float _spawnedCount = 0;

    private void Awake()
    {
        _pool = GetComponent<Pool>();
    }

    private void Start()
    {
        StartGame();
    }

    private void Spawn()
    {
        _spawnedCount++;
        _pool.AddObj();
        if(_spawnedCount >= _pool.Count)
            CancelInvoke();
    }

    //call it to spawn all bubbles
    public void StartGame()
    {
        InvokeRepeating("Spawn", 0, _spawnInterval);
    }
}
