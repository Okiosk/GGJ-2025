using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapCreation : MonoBehaviour
{

    [SerializeField]
    private GameObject _mapCreationStartPoint;
    [SerializeField]
    private GameObject _blocTerrain1;
    [SerializeField]
    private GameObject _blocTerrain2;
    [SerializeField]
    private GameObject _blocTerrain3;
    [SerializeField]
    private GameObject _blocTerrain4;

    private GameObject _previousTerrainEndPoint;
    private GameObject _currentTerrain;

    // Start is called before the first frame update
    void Start()
    {
        _previousTerrainEndPoint = _mapCreationStartPoint;
        for (int i = 0; i < 1; i++)
        {
            _currentTerrain = _blocTerrain1;
            GameObject _newTerrain;
            _newTerrain = Instantiate(_currentTerrain, getEndPoint(_currentTerrain).transform.position + _previousTerrainEndPoint.transform.position,Quaternion.Euler(Vector3.right));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Transform getStartPoint(GameObject _blocTerrain)
    {
        for (int j = 0; j < _blocTerrain.transform.childCount; j++)
        {
            if (_blocTerrain.transform.GetChild(j).name == "startPoint")
            {
                return _blocTerrain.transform.GetChild(j);
            }
        }
        return null;
    }
    private Transform getEndPoint(GameObject _blocTerrain)
    {
        for (int j = 0; j < _blocTerrain.transform.childCount; j++)
        {
            if (_blocTerrain.transform.GetChild(j).name == "endPoint")
            {
                return _blocTerrain.transform.GetChild(j);
            }
        }
        return null;
    }
}
