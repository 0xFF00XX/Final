using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject crosshair;
   
    void Start()
    {
        crosshair = GameObject.FindGameObjectWithTag("crosshair");
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 point = crosshair.transform.position - transform.position;
        // Quaternion rotation = Quaternion.LookRotation(point);
        // transform.rotation = rotation;
        transform.LookAt(new Vector3(crosshair.transform.position.x, transform.position.y, crosshair.transform.position.z));
        
    }
    
}
