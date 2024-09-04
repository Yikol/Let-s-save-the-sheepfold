using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float sheepSpeed = 1.0f;

    public void StartSheepSpawning()
    {
        // 开始生成羊的逻辑
    }

    public void StopSheepSpawning()
    {
        // 停止生成羊的逻辑
    }

    public void SetSheepSpeed(float speed)
    {
        sheepSpeed = speed;
    }

    // 羊的逃逸和返回逻辑
}
