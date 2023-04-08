using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{   public static UImanager instance;
     public GameObject PauseMenu;
    public GameObject FinishMenu;
    public GameObject gameOver;
  private void Awake()
    {
        if (instance==null)
        {
            instance =this;
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
     
    }
   
    public void Resume()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
       
    }
    public void LevelFinish()
    {
       
      
        FinishMenu.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
    }
    
}
