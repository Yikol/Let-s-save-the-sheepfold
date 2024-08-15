using UnityEngine;
using UnityEngine.UI;

public class ImageScaler : MonoBehaviour
{
    public Image image; // ��Ҫ����ͼƬ
    public float scaleSpeed = 1.0f; // ���Ʊ����ٶ�
    public float maxScale = 2.0f; // ���Ŵ���

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
