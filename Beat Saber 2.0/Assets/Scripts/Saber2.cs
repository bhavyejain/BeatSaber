using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber2 : MonoBehaviour
{
    public LayerMask layer;
    public GameObject explosionBig;

    private GameController gameController;
    private AudioSource bang;
    // Start is called before the first frame update
    void Start()
    {
        bang = GetComponent<AudioSource>();
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
    	if(Physics.Raycast(transform.position, transform.up, out hit, 2, layer) && (gameController.gameOver == false))
    	{
            bang.Play();
            Instantiate(explosionBig, hit.transform.position, hit.transform.rotation);
            Destroy(hit.transform.gameObject);
            gameController.GameOver();
    	}
    }
}