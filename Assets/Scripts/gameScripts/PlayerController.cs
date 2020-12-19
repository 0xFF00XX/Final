using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{

    public Slider healthBar;
    private float horizon;
    private float vertical;
    private float speed = 5.0f;
    private Rigidbody playerRb;
    public Vector3 movement;
     public float MyHealth = 100f; ////////////////////////////////////////// -------
     bool isCollided = false;
     float heal = 50f;
     public MeshRenderer rend;
     public GameObject canvas;
     public GameObject spawnManager;
     public GameObject crossHairs;
  
    void Start()
    {
        Time.timeScale = 1;
        healthBar.value = MyHealth;
        playerRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        //check in the begining if im dead
        if(MyHealth<=0){
            //some logs
            Debug.Log("YOU DIED!");
            //disable shooting
            spawnManager.GetComponent<SpawnManager>().enabled = false;
            //disable crosshair movement
            crossHairs.GetComponent<crosshairController>().enabled = false;
            //freeze time
            Time.timeScale = 0;
            //activate overlay
            canvas.SetActive(true);
  

        }
        //get input from keyboard for movement
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        movement = new Vector3(hor, 0 ,ver);
        //if shift pressed - speed up
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            speed = 15.0f;
        }
        //released - slow down
        if(Input.GetKeyUp(KeyCode.LeftShift)){
            speed = 5.0f;
        }
        
        
    }
    void FixedUpdate()
    {
        //move player after fixed amount of time
        moveCharacter(movement);
    }
     void moveCharacter(Vector3 direction)
    {
        //move player
        playerRb.velocity = direction * speed;

    }
  
    private void OnCollisionEnter(Collision collision)
    {
        isCollided = true;
        if(isCollided){
            //detect collision with projectile
            if(collision.gameObject.CompareTag("enemyProjectile")){
                MyHealth -= 10;
                healthBar.value = MyHealth;
                Debug.Log("my health " + MyHealth);
                //destroy projectile
                Destroy(collision.gameObject);

            }
            //detect exit door
            if(collision.gameObject.CompareTag("exitDoor")){
                //check if not last scene
                if(SceneManager.GetActiveScene().buildIndex !=3)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
                else{
                    SceneManager.LoadScene(0);
                }
            }
            
        isCollided = false;
        }
        
    }
    private void OnTriggerEnter(Collider collider){
        //heal when steped on heart and health below 100
        if(collider.gameObject.CompareTag("heal") && MyHealth < 100){
            Destroy(collider.gameObject);
                if(MyHealth + heal > 100){
                    MyHealth = 100;
                }
                else{
                    MyHealth+=heal;
                }
                healthBar.value = MyHealth;
        }
    }
  
}
