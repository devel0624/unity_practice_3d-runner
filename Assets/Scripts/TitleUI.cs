using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour
{
    public SceneChanger changer;
    public Button startButton;
    public Button endButton;

    private void Awake()
    {
        startButton.onClick.AddListener(GameStart);
        endButton.onClick.AddListener(GameEnd);
    }

    private void GameStart()
    {
        changer.SceneChange("NewObstacle");
    }

    public void GameEnd()
    {
        Debug.Log("GameEnd");
        Application.Quit();
    }

}