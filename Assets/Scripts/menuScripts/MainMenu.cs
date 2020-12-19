using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject creditText;
    public void Start(){
        Time.timeScale = 1;
    }
    public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    public void loadLevel0(){
        SceneManager.LoadScene(1);
    }
    public void loadLevel1(){
        SceneManager.LoadScene(2);
    }
    public void loadLevel2(){
        SceneManager.LoadScene(3);
    }
    public void sources(){
        Application.OpenURL("https://github.com/0xFF00XX/Alpha");
    }

   
   
    
}
