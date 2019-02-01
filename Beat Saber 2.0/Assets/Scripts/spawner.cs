using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
	public GameObject[] cubes;
	public Transform[] points;
    public GameObject redSaber;
    public GameObject blueSaber;
    public GameObject greenSaber;

	public float beat;

	private float timer;
	private int pt;
	private int rot;

	private bool valid = true; 
	private float speed = 4;
	private int bt = 0;
	private int update = 5;

    private GameController gameController;

    void Start()
    {
        redSaber.SetActive(true);
        blueSaber.SetActive(false);
        greenSaber.SetActive(false);

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }

    void Update()
    {
        if((timer>(beat*speed)) && (gameController.gameOver == false))
        {
        	pt = Random.Range(0,2);
        	rot = Random.Range(0, 4);
        	GameObject cube = Instantiate(cubes[Random.Range(0,6)], points[pt]);
        	cube.transform.localPosition = Vector3.zero;
        	if(pt == 0)
        	{
        		if(rot == 1)
        		{
        			valid = false;
        		}
        		while(valid == false)
        		{
        			rot = Random.Range(0, 4);
        			if(rot != 1)
        			{
        				valid = true;
        			}
        		}
        	}
        	else if(pt == 1)
        	{
        		if(rot == 3)
        		{
        			valid = false;
        		}
        		while(valid == false)
        		{
        			rot = Random.Range(0, 4);
        			if(rot != 3)
        			{
        				valid = true;
        			}
        		}
        	}
        	cube.transform.Rotate(transform.forward, 90 * rot); 
        	timer -= (beat*speed);
        	bt += 1;

        	if(speed>1.1 && bt > update)
        	{
        		speed = speed/2;
        		update *= 3;
        		bt = 0;
                if(speed == 2)
                {
                    redSaber.SetActive(false);
                    blueSaber.SetActive(true);
                }else if(speed == 1)
                {
                    blueSaber.SetActive(false);
                    greenSaber.SetActive(true);
                }
        	}
        }

        timer += Time.deltaTime;
    }
}
