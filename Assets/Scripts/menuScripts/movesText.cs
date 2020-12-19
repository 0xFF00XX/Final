using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movesText : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject creditText;
    private Vector3 initPos;
    public void moveText(){
        
        creditText = GameObject.FindGameObjectWithTag("creditsText");
        initPos = creditText.transform.position;
        
        if(creditText.activeSelf)
            StartCoroutine(text());
       
    }
    IEnumerator text(){
        while(creditText.transform.position.y < 900){
            yield return new WaitForSeconds(0.007f);
           creditText.transform.position += transform.up;
          
        }

    }
    public void resetText(){
        creditText.transform.position = initPos;
    }
}
