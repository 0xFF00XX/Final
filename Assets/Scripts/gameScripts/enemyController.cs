using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 100f;
    public Material midHealth, lowHealth;
    public Renderer Object;
    public GameObject aimTarget;
    private float spawnInterval;
    public GameObject projectilePrefab;
    public GameObject m4;
    public GameObject head;
    public Rigidbody enemyBody;
    public float enemySpeed = 3f;
    private bool isCoroutineExecuting = false;
    bool isTriggered = false; 
    public GameObject muzzleDirectFlash;
    public GameObject muzzleAmbientFlash;
    public AudioSource shotSound;
  
    void Start()
    {
        Time.timeScale = 1;
        aimTarget = GameObject.FindGameObjectWithTag("legs");
    }

    // Update is called once per frame
    void Update()
    {
        spawnInterval = Random.Range(0.1f,2f);
        //stops close and triggers at target
        if(Vector3.Distance(aimTarget.transform.position, gameObject.transform.position) < 10){
            isTriggered = true;
            StartCoroutine(executeAfter());
            enemySpeed = 0;
        }
        //moves towards target once triggered 
        else if(Vector3.Distance(aimTarget.transform.position, gameObject.transform.position) > 10 && isTriggered){
            transform.position += transform.forward * Time.deltaTime * enemySpeed;
            StartCoroutine(executeAfter());
            enemySpeed = 3f;
        }
        //looses target
        if(Vector3.Distance(aimTarget.transform.position, gameObject.transform.position) > 25 && isTriggered){
            isTriggered = false; 
            enemySpeed = 0;
        }
        changeColorAndDie();
        if(isTriggered)
            transform.LookAt(aimTarget.transform.position);
        

         


    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject);
        if(collision.gameObject.CompareTag("projectile")){
            isTriggered = true;
            health -= 20;
            Debug.Log("IM HIT!!! " + health);
            Destroy(collision.gameObject);
        }
    }
    private void changeColorAndDie(){
        if(health <= 80){
            Object.material = midHealth; 
        }
        if(health <= 50){
            Object.material = lowHealth; 
        }
        if(health <= 0){
            Destroy(gameObject);
        }
    }
    private void fire(){
        //Debug.Log("rate:  " + spawnInterval);
        
        Vector3 spawnPos = m4.transform.position;
        float rotY = head.transform.eulerAngles.y;
        muzzleDirectFlash.SetActive(true);
        muzzleAmbientFlash.SetActive(true);
        StartCoroutine(flashFire());
        shotSound.PlayOneShot(shotSound.clip, 0.1f);
        Instantiate(projectilePrefab, spawnPos, Quaternion.Euler(90,rotY,90));
        
    }
    IEnumerator executeAfter(){
        if(isCoroutineExecuting)
            yield break;
        isCoroutineExecuting = true;
        
        yield return new WaitForSeconds(spawnInterval);
        fire();
        isCoroutineExecuting = false;

    }
    IEnumerator flashFire(){
        yield return new WaitForSeconds(0.03f);
        muzzleDirectFlash.SetActive(false);
        muzzleAmbientFlash.SetActive(false);
    }

}
