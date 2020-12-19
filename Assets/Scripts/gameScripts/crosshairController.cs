using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crosshairController : MonoBehaviour
{
    // Start is called before the first frame update
    //public Camera cam;
    Vector3 worldPosition;
    public GameObject player;
    float aimDistance = 10;
    void Start()
    {
        Time.timeScale = 1;
        //cam = GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("legs");
    }

    // Update is called once per frame
    void Update()
    {
        Plane plane = new Plane(Vector3.up, -11f);
        
        //Debug.Log(Vector3.Distance(player.transform.position, transform.position));
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Input.GetKeyDown(KeyCode.LeftShift)){
            aimDistance = 5f;
        }
         if(Input.GetKeyUp(KeyCode.LeftShift)){
            aimDistance = 10;
        }
        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
            transform.position = Vector3.MoveTowards(player.transform.position, worldPosition, aimDistance);
         
            
           
        }
       
        

    }
    void OnCollisionEnter(Collision col){
        if(col.gameObject == GameObject.FindGameObjectWithTag("obstacle")){
            Debug.Log("touched Wall");
        }
    }
}
