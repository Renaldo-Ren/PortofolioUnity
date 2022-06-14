using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    public GameObject GameOverMenu;
    public Player player;
    public static bool isOver;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        GameOverMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.health <= .001f){
            GameOverMenu.SetActive(true);
            Time.timeScale = 0f;
            isOver = true;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void BacktoMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
