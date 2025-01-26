using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string GameState = "waitStart";

    private void Update()
    {
        if (GameState == "waitStart")
        {

        }
        if (GameState == "starting")
        {

        }
        if (GameState == "playing")
        {
            Pool listebubble = GetComponent<Pool>();
            mapCreation map = GetComponent<mapCreation>();
            if (listebubble._objPool.Count == 0)
            {
                GameState = "badend";
            }
            else
            {
                foreach (var bubble in listebubble._objPool)
                {
                    if (bubble.transform.position.x > map.tailleMap)
                    {
                        GameState = "goodend";
                    }
                }
            }
        }
        if (GameState == "goodend")
        {
            uiManager ui = GetComponent<uiManager>();
            ui.afficheEnd();
        }
        if (GameState == "badend")
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
}
