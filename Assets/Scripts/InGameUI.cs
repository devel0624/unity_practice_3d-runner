using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Button pauseButton;

    public GameObject pausePanel;
    public Button returnButton;
    public Button titleButton;

    public Button[] restartButton;
    public Button[] gameTitleButton;

    public SceneChanger changer;

    public GameObject gameOverPanel;
    public GameObject gameClearPanel;

    private void Awake()
    {
        pauseButton.onClick.AddListener(GamePause);
        returnButton.onClick.AddListener(GameResume);
        titleButton.onClick.AddListener(ReturnTitle);

        for(int i = 0; i < restartButton.Length; i++)
        {
            restartButton[i].onClick.AddListener(RestartGame);
            gameTitleButton[i].onClick.AddListener(ReturnTitle);
        }

        GameManager.instance.gameOverPanel = gameOverPanel;
        GameManager.instance.gameClearPanel = gameClearPanel;
    }

    private void Update()
    {
        scoreText.text = $"Score : {GameManager.instance.playerScore}";
    }
    private void GamePause()
    {
        GameManager.instance.isPause = true;
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    private void GameResume()
    {
        GameManager.instance.isPause = false;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    private void ReturnTitle()
    {
        GameManager.instance.playerScore = 0;
        GameManager.instance.isPause = false;
        Time.timeScale = 1f;
        changer.SceneChange("TitleScene");
    }


    private void RestartGame()
    {
        GameManager.instance.playerScore = 0;
        GameManager.instance.isPause = false;
        Time.timeScale = 1f;
        changer.SceneChange("NewObstacle");
    }

}