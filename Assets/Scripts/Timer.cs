using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    private float timeLimit;
    private float currentTime;

    public void StartTimer()
    {
        currentTime = timeLimit;
        // 开始计时逻辑
    }

    public void StopTimer()
    {
        // 停止计时逻辑
    }

    public void SetTimeLimit(float limit)
    {
        timeLimit = limit;
    }

    // 更新时间并可能影响羊的逃逸速度的逻辑
}
