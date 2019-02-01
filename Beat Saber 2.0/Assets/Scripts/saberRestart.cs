using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saberRestart : MonoBehaviour
{
    public LayerMask layer;
    public GameObject expl;

    private GameController gameController;
    private AudioSource thud;
    // Start is called before the first frame update
    void Start()
    {
        thud = GetComponent<AudioSource>();
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.up, out hit, 2, layer) && (gameController.gameOver == true))
        {
            thud.Play();
            Instantiate(expl, hit.transform.position, hit.transform.rotation);
            Destroy(hit.transform.gameObject);
            gameController.gameRestart();   
        }
    }
}
