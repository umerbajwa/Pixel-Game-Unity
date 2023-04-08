using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerLife : MonoBehaviour
{
    private Animator animator;
    public int totalLives = 3;
    public int livesCount;
            
    public GameObject[] livesIcon;
    public GameObject spawnPoint;

    private bool isDead;
    public static PlayerLife instance;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        livesCount = totalLives;
    }

    public void ApplyDamage()
    {
        if (!isDead)
        {
            animator.SetTrigger("death");
            livesCount--;
            isDead = true;
        }
        if(livesCount == 0)
        {
            UImanager.instance.gameOver.SetActive(true);
            Time.timeScale = 0;

        }
    }
    public void Disappear()
    {
        if (livesCount > 0)
        {
            transform.position = spawnPoint.transform.position;
            ResetLives();
        }
        else
        { //Game over
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void ResetLives()
    {
        for (int i = 0; i < totalLives; i++)
        {
            livesIcon[i].SetActive(false);
        }

        for (int i = 0; i < livesCount; i++)
        {
            livesIcon[i].SetActive(true);
        }
        isDead = false;
        animator.SetTrigger("reset");
    }
}
