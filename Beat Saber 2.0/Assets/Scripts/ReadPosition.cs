using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadPosition : MonoBehaviour
{
    public Transform t;
    
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(t.position.x, t.position.y, t.position.z);   
    }
}
