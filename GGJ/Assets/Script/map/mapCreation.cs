using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapCreation : MonoBehaviour
{

    [SerializeField]
    private GameObject _mapCreationStartPoint;
    [SerializeField]
    private GameObject _cloud;
    [SerializeField]
    private GameObject _tree1;
    [SerializeField]
    private GameObject _tree2;
    [SerializeField]
    private GameObject _tree3;
    [SerializeField]
    private GameObject _blocTerrain1;
    [SerializeField]
    private GameObject _blocTerrain2;
    [SerializeField]
    private GameObject _blocTerrain3;
    [SerializeField]
    private GameObject _blocTerrain4;
    [SerializeField]
    private GameObject _blocTerrain5;
    [SerializeField]
    private GameObject _blocTerrain6;
    [SerializeField]
    private GameObject _blocTerrain7;

    private List<GameObject> _terrainList = new List<GameObject>();
    private List<GameObject> _treeList = new List<GameObject>();
    private GameObject _previousTerrainEndPoint;
    private GameObject _currentTerrain;



    // Ne cherche pas à comprendre pourquoi je la declare ici
    private float posY;

    // Start is called before the first frame update
    void Start()
    {
        _terrainList.Add(_blocTerrain1);
        _terrainList.Add(_blocTerrain2);
        _terrainList.Add(_blocTerrain3);
        _terrainList.Add(_blocTerrain4);
        _terrainList.Add(_blocTerrain5);
        _terrainList.Add(_blocTerrain6);
        _terrainList.Add(_blocTerrain7);

        _treeList.Add(_tree1);
        _treeList.Add(_tree2);
        _treeList.Add(_tree3);

        _previousTerrainEndPoint = _mapCreationStartPoint;

        ////////////////// création du terrain de début
        for (int i = 0; i < 3; i++)
        {
            _currentTerrain = _blocTerrain1;
            GameObject _newTerrain;
            _newTerrain = Instantiate(_currentTerrain, _previousTerrainEndPoint.transform.position - getStartPoint(_currentTerrain).transform.position, Quaternion.Euler(Vector3.right));
            _newTerrain.transform.SetParent(transform);
            _previousTerrainEndPoint.transform.position = _newTerrain.transform.position + getEndPoint(_currentTerrain).transform.position;
        }

        for (int i = 0; i < 35; i++)
        {
            ////////////////// création du bloc de terrain
            _currentTerrain = _terrainList[Random.Range(0, _terrainList.Count)];
            GameObject _newTerrain;
            _newTerrain = Instantiate(_currentTerrain, _previousTerrainEndPoint.transform.position - getStartPoint(_currentTerrain).transform.position, Quaternion.Euler(Vector3.right));
            _newTerrain.transform.SetParent(transform);

            ////////////////// création d'obstacle static
            Vector3 rangeStaticSpawnStart;
            Vector3 rangeStaticSpawnEnd;
            rangeStaticSpawnStart = new Vector3(_previousTerrainEndPoint.transform.position.x, _previousTerrainEndPoint.transform.position.y, _previousTerrainEndPoint.transform.position.z);
            _previousTerrainEndPoint.transform.position = _newTerrain.transform.position + getEndPoint(_currentTerrain).transform.position;
            rangeStaticSpawnEnd = new Vector3(_previousTerrainEndPoint.transform.position.x, _previousTerrainEndPoint.transform.position.y, _previousTerrainEndPoint.transform.position.z);
            ////////////////// création d'un arbre
            if (Random.Range(0, 2) == 0)
            {
                GameObject _tree = _treeList[Random.Range(0, _treeList.Count)]; ;
                float posX = Random.Range(rangeStaticSpawnStart.x, rangeStaticSpawnEnd.x);
                if (rangeStaticSpawnStart.y < rangeStaticSpawnEnd.y)
                {
                    posY = rangeStaticSpawnStart.y;
                }
                else
                {
                    posY = rangeStaticSpawnEnd.y;
                }
                posY -= 10;
                RaycastHit2D hit = Physics2D.Raycast(new Vector2(posX, posY), Vector2.up, 1000);
                if (hit)
                {
                    GameObject _newTree;


                    if ((Mathf.Atan2(hit.normal.y, hit.normal.x) * Mathf.Rad2Deg) + 90 < 30 && (Mathf.Atan2(hit.normal.y, hit.normal.x) * Mathf.Rad2Deg) + 90 > -30)
                    {
                        _newTree = Instantiate(_tree, new Vector3(posX, hit.point.y - getStartPoint(_tree).transform.position.y), Quaternion.Euler(Vector3.right));
                        _newTree.transform.up = -hit.normal;
                        _newTree.transform.SetParent(transform);
                    }

                }
            }
            else
            {
                ////////////////// création d'un nuage
                float posX = Random.Range(rangeStaticSpawnStart.x, rangeStaticSpawnEnd.x);
                if (rangeStaticSpawnStart.y < rangeStaticSpawnEnd.y)
                {
                    posY = rangeStaticSpawnStart.y;
                }
                else
                {
                    posY = rangeStaticSpawnEnd.y;
                }
                posY -= 10;
                RaycastHit2D hit = Physics2D.Raycast(new Vector2(posX, posY), Vector2.up, 1000);
                if (hit)
                {
                    GameObject _newCloud;
                    _newCloud = Instantiate(_cloud, new Vector3(posX, hit.point.y - getStartPoint(_cloud).transform.position.y+ Random.Range(10,15)), Quaternion.Euler(Vector3.right));
                }
            }
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
