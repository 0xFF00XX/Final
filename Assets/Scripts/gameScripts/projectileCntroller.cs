using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileCntroller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectile;
    
    private float speed = 80f;
    private int obstacleCounter = 0;

    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
   private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("obstacle")){
            obstacleCounter ++;
            
                //Debug.Log("wall hit");
                Destroy(gameObject);
        }
    }

}
