using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    public GameObject diss;

    private GameController gameController;
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }

    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * 3;
        if (gameController.gameOver == true)
        {
            dissolve();
        }
    }

    void dissolve()
    {
        Instantiate(diss, transform.position, transform.rotation);  
        Destroy(gameObject);
    }
}
