using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int playerScore;
    public bool isOver = false;
    public bool isPause = false;

    public GameObject gameOverPanel;
    public GameObject gameClearPanel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }


    private void Update()
    {
        if (isOver)
        {
            GameOver();
        }
    }

    public void GameClear()
    {
        isPause = true;
        gameClearPanel.SetActive(true);
    }

    public void GameOver()
    {
        isPause = true;
        isOver = false;
        gameOverPanel.SetActive(true);
    }

}