using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Saber : MonoBehaviour
{
    private const int V = 130;
    public LayerMask layer;
	private Vector3 previousPos;
    public GameObject explosion;

    private GameController gameController;
    private AudioSource thud;

    void Start()
    {
        thud = GetComponent<AudioSource>();
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.up,out hit, 2, layer) && (gameController.gameOver == false))
    	{
    		if(Vector3.Angle(transform.position-previousPos, hit.transform.up) > V)
    		{
                thud.Play();
                Instantiate(explosion, hit.transform.position, hit.transform.rotation);
    			Destroy(hit.transform.gameObject);
                gameController.addScore();
    		}
    	}
        previousPos = transform.position;
    }
}