using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private string GameState = "waitStart";
    [SerializeField]
    private uiManager ui;
    [SerializeField]
    private BubbleManager bubbleMana;
    [SerializeField]
    private mapCreation map;
    [SerializeField]
    private Pool listebubble;


    private int total;
    private bool start = false;

    public void input(InputAction.CallbackContext context)
    {
        Debug.Log("sdfbrdfqs");
        if (context.started)
        {
            start = true;
        }
    }

    private void Update()
    {
        Debug.Log(GameState);
        if (GameState == "waitStart")
        {
            ui.afficheStart();
            if (start)
            {
                GameState = "starting";
                ui.enleveStart();
            }
        }
        if (GameState == "starting")
        {
            
            bubbleMana.StartGame();
            
            GameState = "starting2";
        }
        if (GameState == "starting2")
        {
            total = 0;
            foreach (var bubble in listebubble._objPool)
            {
                if (bubble.activeSelf)
                {
                    total++;
                }

            }
            if (total > 10)
            {
                GameState = "playing";
            }

        }
        if (GameState == "playing")
        {
            total = 0;
            foreach (var bubble in listebubble._objPool)
            {
                if (bubble.activeSelf)
                {
                    total++;
                    if (bubble.transform.position.x > map.tailleMap)
                    {
                        GameState = "goodend";
                    }
                }
                    
            }
            if (total == 0)
            {
                GameState = "badend";
            }
            Debug.Log(total);

        }
        if (GameState == "goodend")
        {
            ui.afficheEnd();
        }
        if (GameState == "badend")
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
}
