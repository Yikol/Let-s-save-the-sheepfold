using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public LevelManager levelManager;
    public SheepManager sheepManager;
    public UIManager uiManager;
    public Timer timer;

    void Start()
    {
        levelManager.SetupLevel(1); // 初始化第一关
        uiManager.ShowStartScreen();
    }

    public void StartGame()
    {
        timer.StartTimer();
        sheepManager.StartSheepSpawning();
        uiManager.HideStartScreen();
    }

    public void EndGame(bool hasWon)
    {
        timer.StopTimer();
        sheepManager.StopSheepSpawning();
        uiManager.ShowEndScreen(hasWon);
    }
}
