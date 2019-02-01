using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivenRotation : MonoBehaviour
{
    public Transform ARCamTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = ARCamTransform.transform.localRotation.eulerAngles.x;
        float y = ARCamTransform.transform.localRotation.eulerAngles.y;
        float z = ARCamTransform.transform.localRotation.eulerAngles.z;
        transform.localEulerAngles = new Vector3(x, y, z);

    }
}
