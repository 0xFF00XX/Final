using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour
{
    public GameObject player;
    private Vector3 currentPosition;
    private float currentZ;
    private float speed = 5f;
    bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        currentPosition = transform.position;
        currentZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, currentPosition) < 5){
            Debug.Log(transform.position.z);
            if((transform.position.z < currentZ + 5f)){
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                isOpen = true;
            }
            
            
        }
        // else if(Vector3.Distance(player.transform.position, currentPosition) > 5 ){
        //     transform.Translate(Vector3.back * Time.deltaTime * speed);
        // }
    }
}
