using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class live : MonoBehaviour
{
    public GameObject[] hearts; 
    private int lives;
    // Start is called before the first frame update
    void Start()
    {
        lives = hearts.Length; 
        UpdateHearts();
        
    }

    public void LoseLife()
    {
        if (lives > 0)
        {
            lives--;
            UpdateHearts();

            if (lives == 0)
            {
                GameOver();
            }
        }
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < lives)
                hearts[i].SetActive(true);  
            else
                hearts[i].SetActive(false); 
        }
    }

    void GameOver()
    {
      SceneManager.LoadScene("game over");
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
