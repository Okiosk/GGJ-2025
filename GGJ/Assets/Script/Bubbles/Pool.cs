using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] GameObject obj;

    [SerializeField] public int Count = 50;
    public List<GameObject> _objPool = new List<GameObject>();

    public void Awake()
    {
        for (int i = 0; i < Count; i++)
        {
            var newObj = Instantiate(obj, new Vector3(0, 1, 0), Quaternion.identity, transform);
            newObj.SetActive(false);
            _objPool.Add(newObj);
        }
    }

    public void AddObj()
    {
        foreach (var obj in _objPool)
        {
            if (!obj.activeSelf)
            {
                obj.SetActive(true);
                break;
            }
        }
    }
}
