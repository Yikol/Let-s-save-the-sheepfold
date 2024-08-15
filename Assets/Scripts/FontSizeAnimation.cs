using UnityEngine;
using UnityEngine.UI;

public class ImageScaler : MonoBehaviour
{
    public Image image; // 需要变大的图片
    public float scaleSpeed = 1.0f; // 控制变大的速度
    public float maxScale = 2.0f; // 最大放大倍数

    private Vector3 originalScale;

    void Start()
    {
        if (image != null)
        {
            originalScale = image.rectTransform.localScale;
        }
    }

    void Update()
    {
        if (image != null && image.rectTransform.localScale.x < maxScale)
        {
            image.rectTransform.localScale += Vector3.one * scaleSpeed * Time.deltaTime;
            if (image.rectTransform.localScale.x > maxScale)
            {
                image.rectTransform.localScale = Vector3.one * maxScale;
            }
        }
    }
}
