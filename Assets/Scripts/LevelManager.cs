using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager、 : MonoBehaviour
{
    // Start is called before the first frame update
    public SheepManager sheepManager;
    public Timer timer;

    public void SetupLevel(int levelNumber)
    {
        switch(levelNumber)
        {
            case 1:
                timer.SetTimeLimit(30);
                sheepManager.SetSheepSpeed(1.0f);
                break;
            case 2:
                timer.SetTimeLimit(60);
                sheepManager.SetSheepSpeed(2.0f);
                break;
            // 更多关卡设置
        }
    }
}
