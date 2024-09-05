using UnityEngine;
using UnityEngine.AI;

public class SheepController : MonoBehaviour
{
    public Transform[] targetPoints; // 目标点数组
    private NavMeshAgent navMeshAgent;
    private Transform currentTarget;
    private bool isDragged = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        ChooseNewTargetPoint();
    }

    void Update()
    {
        if (isDragged)
        {
            navMeshAgent.ResetPath(); // 停止导航路径
            return;
        }

        // 如果羊已经接近目标点，则选择下一个目标点
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            ChooseNewTargetPoint();
        }
    }

    void ChooseNewTargetPoint()
    {
        if (targetPoints.Length == 0)
            return;

        // 随机选择一个目标点
        int randomIndex = Random.Range(0, targetPoints.Length);
        currentTarget = targetPoints[randomIndex];

        // 设置新的目标点为NavMeshAgent的目的地
        navMeshAgent.SetDestination(currentTarget.position);
    }

    private void OnMouseDown()
    {
        isDragged = true;
        navMeshAgent.ResetPath(); // 停止寻路
    }

    private void OnMouseDrag()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
    }

    private void OnMouseUp()
    {
        isDragged = false;

        // 判断是否放回了羊圈
        if (IsInPen())
        {
            Debug.Log("Sheep returned to the pen.");
            // 可以在这里处理羊回到羊圈后的逻辑
        }
        else
        {
            // 继续选择新的目标点并移动
            ChooseNewTargetPoint();
        }
    }

    private bool IsInPen()
    {
        // 检测羊是否在羊圈里
        // 你可以根据羊圈的位置和范围实现这个函数
        // 例如：
        // return Vector2.Distance(transform.position, pen.position) < penRadius;

        // 这里需要替换为实际的羊圈检测逻辑
        return false;
    }
}