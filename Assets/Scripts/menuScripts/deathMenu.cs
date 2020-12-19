using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource deathAudio;
    public void Start(){
        deathAudio.Play();
    }
   public void restartScene(){
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
   public void backToMenu(){
       SceneManager.LoadScene(0);
   }
}
