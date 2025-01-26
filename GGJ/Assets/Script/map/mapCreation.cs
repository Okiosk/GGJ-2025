using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapCreation : MonoBehaviour
{

    [SerializeField]
    private GameObject _mapCreationStartPoint;
    [SerializeField]
    private GameObject _cloud1;
    [SerializeField]
    private GameObject _cloud2;
    [SerializeField]
    private GameObject _cloud3;
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
    [SerializeField]
    private int _mapNbBloc;

    private List<GameObject> _terrainList = new List<GameObject>();
    private List<GameObject> _treeList = new List<GameObject>();
    private List<GameObject> _cloudList = new List<GameObject>();
    private GameObject _previousTerrainEndPoint;
    private GameObject _currentTerrain;

    public float tailleMap;

    // Ne cherche pas � comprendre pourquoi je la declare ici
    private float posY;

    // Start is called before the first frame update
    void Start()
    {
        tailleMap = _mapCreationStartPoint.transform.position.x;
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

        _cloudList.Add(_cloud1);
        _cloudList.Add(_cloud2);
        _cloudList.Add(_cloud3);

        _previousTerrainEndPoint = _mapCreationStartPoint;

        ////////////////// cr�ation du terrain de d�but
        for (int i = 0; i < 3; i++)
        {
            _currentTerrain = _blocTerrain1;
            GameObject _newTerrain;
            _newTerrain = Instantiate(_currentTerrain, _previousTerrainEndPoint.transform.position - getStartPoint(_currentTerrain).transform.position, Quaternion.Euler(Vector3.right));
            _newTerrain.transform.SetParent(transform);
            _previousTerrainEndPoint.transform.position = _newTerrain.transform.position + getEndPoint(_currentTerrain).transform.position;
        }
        ////////////////// cr�ation du terrain de jeu partie 1
        for (int i = 0; i < (_mapNbBloc/3); i++)
        {
            ////////////////// cr�ation du bloc de terrain
            _currentTerrain = _terrainList[Random.Range(0, _terrainList.Count)];
            GameObject _newTerrain;
            _newTerrain = Instantiate(_currentTerrain, _previousTerrainEndPoint.transform.position - getStartPoint(_currentTerrain).transform.position, Quaternion.Euler(Vector3.right));
            _newTerrain.transform.SetParent(transform);

            ////////////////// cr�ation d'obstacle static
            Vector3 rangeStaticSpawnStart;
            Vector3 rangeStaticSpawnEnd;
            rangeStaticSpawnStart = new Vector3(_previousTerrainEndPoint.transform.position.x, _previousTerrainEndPoint.transform.position.y, _previousTerrainEndPoint.transform.position.z);
            _previousTerrainEndPoint.transform.position = _newTerrain.transform.position + getEndPoint(_currentTerrain).transform.position;
            rangeStaticSpawnEnd = new Vector3(_previousTerrainEndPoint.transform.position.x, _previousTerrainEndPoint.transform.position.y, _previousTerrainEndPoint.transform.position.z);
            ////////////////// cr�ation d'un arbre
            if (Random.Range(0, 2)==1)
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
        }
        ////////////////// cr�ation du terrain de jeu partie 2
        for (int i = 0; i < (_mapNbBloc/3); i++)
        {
            ////////////////// cr�ation du bloc de terrain
            _currentTerrain = _terrainList[Random.Range(0, _terrainList.Count)];
            GameObject _newTerrain;
            _newTerrain = Instantiate(_currentTerrain, _previousTerrainEndPoint.transform.position - getStartPoint(_currentTerrain).transform.position, Quaternion.Euler(Vector3.right));
            _newTerrain.transform.SetParent(transform);

            ////////////////// cr�ation d'obstacle static
            Vector3 rangeStaticSpawnStart;
            Vector3 rangeStaticSpawnEnd;
            rangeStaticSpawnStart = new Vector3(_previousTerrainEndPoint.transform.position.x, _previousTerrainEndPoint.transform.position.y, _previousTerrainEndPoint.transform.position.z);
            _previousTerrainEndPoint.transform.position = _newTerrain.transform.position + getEndPoint(_currentTerrain).transform.position;
            rangeStaticSpawnEnd = new Vector3(_previousTerrainEndPoint.transform.position.x, _previousTerrainEndPoint.transform.position.y, _previousTerrainEndPoint.transform.position.z);
            ////////////////// cr�ation d'un arbre
            if (Random.Range(0, 2) == 0)
            {
                GameObject _tree = _treeList[Random.Range(0, _treeList.Count)];
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
                ////////////////// cr�ation d'un nuage
                GameObject _cloud = _cloudList[Random.Range(0, _cloudList.Count)];
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
                    _newCloud = Instantiate(_cloud, new Vector3(posX, hit.point.y - getStartPoint(_cloud).transform.position.y + Random.Range(10, 15)), Quaternion.Euler(Vector3.right));
                }
            }
        }
        ////////////////// cr�ation du terrain de jeu partie 3
        for (int i = 0; i < (_mapNbBloc/3)+(_mapNbBloc%3); i++)
        {
            ////////////////// cr�ation du bloc de terrain
            _currentTerrain = _terrainList[Random.Range(0, _terrainList.Count)];
            GameObject _newTerrain;
            _newTerrain = Instantiate(_currentTerrain, _previousTerrainEndPoint.transform.position - getStartPoint(_currentTerrain).transform.position, Quaternion.Euler(Vector3.right));
            _newTerrain.transform.SetParent(transform);

            ////////////////// cr�ation d'obstacle static
            Vector3 rangeStaticSpawnStart;
            Vector3 rangeStaticSpawnEnd;
            rangeStaticSpawnStart = new Vector3(_previousTerrainEndPoint.transform.position.x, _previousTerrainEndPoint.transform.position.y, _previousTerrainEndPoint.transform.position.z);
            _previousTerrainEndPoint.transform.position = _newTerrain.transform.position + getEndPoint(_currentTerrain).transform.position;
            rangeStaticSpawnEnd = new Vector3(_previousTerrainEndPoint.transform.position.x, _previousTerrainEndPoint.transform.position.y, _previousTerrainEndPoint.transform.position.z);
            ////////////////// cr�ation d'un arbre
            if (Random.Range(0, 10) < 4)
            {
                GameObject _tree = _treeList[Random.Range(0, _treeList.Count)];
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
            else if (Random.Range(0, 1) == 0)
            {
                ////////////////// cr�ation d'un nuage
                GameObject _cloud = _cloudList[Random.Range(0, _cloudList.Count)];
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
                    _newCloud = Instantiate(_cloud, new Vector3(posX, hit.point.y - getStartPoint(_cloud).transform.position.y + Random.Range(10, 15)), Quaternion.Euler(Vector3.right));
                }
            }
        }

        tailleMap = _previousTerrainEndPoint.transform.position.x - tailleMap;

        for (int i = 0; i < 6; i++)
        {
            _currentTerrain = _blocTerrain1;
            GameObject _newTerrain;
            _newTerrain = Instantiate(_currentTerrain, _previousTerrainEndPoint.transform.position - getStartPoint(_currentTerrain).transform.position, Quaternion.Euler(Vector3.right));
            _newTerrain.transform.SetParent(transform);
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
