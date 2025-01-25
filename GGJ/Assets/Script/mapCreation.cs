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

    private List<GameObject> terrainList = new List<GameObject>();
    private GameObject _previousTerrainEndPoint;
    private GameObject _currentTerrain;

    // Start is called before the first frame update
    void Start()
    {
        terrainList.Add(_blocTerrain1);
        terrainList.Add(_blocTerrain2);
        terrainList.Add(_blocTerrain3);
        terrainList.Add(_blocTerrain4);


        _previousTerrainEndPoint = _mapCreationStartPoint;
        for (int i = 0; i < 8; i++)
        {
            _currentTerrain = _blocTerrain1;
            GameObject _newTerrain;
            Debug.Log(getStartPoint(_currentTerrain).transform.position);
            Debug.Log(getEndPoint(_currentTerrain).transform.position);
            _newTerrain = Instantiate(_currentTerrain, _previousTerrainEndPoint.transform.position - getStartPoint(_currentTerrain).transform.position, Quaternion.Euler(Vector3.right));
            _previousTerrainEndPoint.transform.position = _newTerrain.transform.position + getEndPoint(_currentTerrain).transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private GameObject getStartPoint(GameObject _blocTerrain)
    {
        for (int j = 0; j < _blocTerrain.transform.childCount; j++)
        {
            if (_blocTerrain.transform.GetChild(j).name == "startPoint")
            {
                return _blocTerrain.transform.GetChild(j).gameObject;
            }
        }
        return null;
    }
    private GameObject getEndPoint(GameObject _blocTerrain)
    {
        for (int j = 0; j < _blocTerrain.transform.childCount; j++)
        {
            if (_blocTerrain.transform.GetChild(j).name == "endPoint")
            {
                return _blocTerrain.transform.GetChild(j).gameObject;
            }
        }
        return null;
    }
}
