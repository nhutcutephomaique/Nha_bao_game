using UnityEngine;
using UnityEngine.UI;

public class InfiniteScroll : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform contentPanel;

    // Đoạn code này kiểm tra vị trí cuộn, khi gần đến cuối sẽ kéo nội dung về lại phía trên để tạo vòng lặp mượt mà
    void Start()
    {
        if (scrollRect == null) scrollRect = GetComponent<ScrollRect>();
        if (contentPanel == null) contentPanel = GetComponent<RectTransform>();

        scrollRect.onValueChanged.AddListener(OnScroll);
    }

    void OnScroll(Vector2 pos)
    {
        // Nếu người dùng cuộn sát xuống đáy (vị trí y tiến về 0)
        if (pos.y <= 0.05f)
        {
            // Đưa thanh cuộn dịch ngược lên phía trên một chút để tạo cảm giác lặp vô tận
            scrollRect.verticalNormalizedPosition = 0.9f;
        }
    }
}