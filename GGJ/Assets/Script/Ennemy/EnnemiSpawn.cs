using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi1 : MonoBehaviour
{

    public GameObject ennemi1;
    public GameObject ennemi2;
    public GameObject ennemi3;
    public GameObject ennemi4;

    public GameObject mainCamera;
    public GameObject spawner;

    // Start is called before the first frame update
    public float spawnInterval;

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
        spawnInterval = Random.Range(15f, 25f);

        while(true)
        {
            int choixEnnemi = Random.Range(1, 5);
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
                Instantiate(ennemi1, spawnPosition, Quaternion.identity);
                print(choixEnnemi);
                break;
            case 2:
                Instantiate(ennemi2, spawnPosition, Quaternion.identity);
                print(choixEnnemi);
                break;
            case 3:
                Instantiate(ennemi3, spawnPosition, Quaternion.identity);
                print(choixEnnemi);
                break;
            case 4:
                Instantiate(ennemi4, spawnPosition, Quaternion.identity);
                print(choixEnnemi);
                break;
            default:
                print("Pas d'ennemi");
                break;
        }
    }

}
