using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi1 : MonoBehaviour
{

    public GameObject ennemi1;
    public GameObject ennemi2;

    public Ennemi ennemiData;

    public GameObject mainCamera;
    public GameObject spawner;

    [SerializeField]
    private GameObject oiseauxSprite;
    // Start is called before the first frame update
    public float spawnInterval;


    public bool spawn = false;

    void Start()
    {
        StartCoroutine(SpawnEnemyCoroutine());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator SpawnEnemyCoroutine()
    {
        spawnInterval = Random.Range(2f, 5f);

        while(true)
        {
            int choixEnnemi = Random.Range(1, 3);
            SpawnEnnemi(choixEnnemi);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnEnnemi(int choixEnnemi)
    {
        float minY = spawner.transform.position.y - spawner.transform.localScale.y / 2;
        float maxY = spawner.transform.position.y + spawner.transform.localScale.y / 2;
        float spawnX = spawner.transform.position.x;
        float spawnY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);

        switch (choixEnnemi)
        {
            case 1:
                GameObject newEnnemi = Instantiate(ennemi1, spawnPosition, Quaternion.identity);
                EnnemiStats stats = newEnnemi.GetComponent<EnnemiStats>();
                stats.OnServerInitialized(ennemiData);
                print(choixEnnemi);
                break;
            case 2:
                Instantiate(ennemi2, spawnPosition, Quaternion.identity);
                print(choixEnnemi);
                break;
            default:
                print("Pas d'ennemi");
                break;
        }
    }

}
