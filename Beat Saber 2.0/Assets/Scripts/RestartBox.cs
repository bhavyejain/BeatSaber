using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartBox : MonoBehaviour
{
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void restartGame()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        gameController.gameRestart();
    }
}
