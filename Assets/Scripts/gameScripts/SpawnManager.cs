using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update\
    public GameObject projectilePrefab;
    public GameObject m4;
    public GameObject muzzleDirectFlash;
    public GameObject muzzleAmbientFlash;
    public GameObject head;
    public AudioSource shotSource;
    
    //public AudioClip shotSound;
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {   

        // Debug.Log(spawnPos);
        Vector3 spawnPos = m4.transform.position;
        //Vector3 spawnRotaion = new Vector3(projectilePrefab.transform.rotation.x, m4.transform.rotation.y,projectilePrefab.transform.rotation.z);
        
        float rotY = head.transform.eulerAngles.y;
        //Debug.Log(rotY + " ---- <");
        if(Input.GetMouseButtonDown(0)){
                Instantiate(projectilePrefab, spawnPos, Quaternion.Euler(90,rotY,90));
                muzzleDirectFlash.SetActive(true);
                muzzleAmbientFlash.SetActive(true);
                StartCoroutine(flashFire());
                shotSource.PlayOneShot(shotSource.clip, 0.1f);
            
            
            //Quaternion.Euler(projectilePrefab.transform.rotation.x, m4.transform.rotation.y, projectilePrefab.transform.rotation.z)
        }

    }
    IEnumerator flashFire(){
        yield return new WaitForSeconds(0.03f);
        muzzleDirectFlash.SetActive(false);
            muzzleAmbientFlash.SetActive(false);
    }
 
}
