using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    private Pool _pool;
    [SerializeField] private float _spawnInterval = .1f;
    private float _spawnedCount = 0;

    public bool IsBlowing = true;

    private void Awake()
    {
        _pool = GetComponent<Pool>();
    }

    private void Spawn()
    {
        _spawnedCount++;
        _pool.AddObj();
        if(_spawnedCount >= _pool.Count)
        {
            CancelInvoke();
            GameObject.Find("Child").GetComponent<Girl>().CanMove = true;
            IsBlowing = false;
        }
    }

    //call it to spawn all bubbles
    public void StartGame()
    {
        InvokeRepeating("Spawn", 0, _spawnInterval);
    }
}
