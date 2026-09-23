using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Video;

public class AppPostVideo : MonoBehaviour
{
    [Header("Thông tin bài viết")]
    public TMP_Text authorText;
    public TMP_Text contentText;
    public TMP_Text likeCountText;
    public Image avatarImage;
    public Image mediaImage;
    public GameObject mediaVideoObject; // Object chứa Raw Image / Video

    [Header("Dữ liệu Video cho bài này")]
    public VideoClip videoCuaBaiNay;    // File mp4 gắn cho bài viết này

    [Header("Kết nối sang Cửa sổ Xem Video có sẵn")]
    public GameObject windowXemVideo;   // Kéo "Window_xemVideo" từ ngoài vào đây
    public VideoPlayer mayPhatVideoChung; // Kéo object "ManChieu" (có VideoPlayer) vào đây

    private int likeCount = 0;
    private bool isLiked = false;

    // 1. Xử lý nút Like
    public void OnClickLike()
    {
        if (!isLiked)
        {
            likeCount++;
            isLiked = true;
        }
        else
        {
            likeCount--;
            isLiked = false;
        }
        if (likeCountText != null)
            likeCountText.text = likeCount.ToString();
    }

    // 2. Xử lý khi bấm vào Video -> Mở "Window_xemVideo" đã làm
    public void OnClickOpenVideoWindow()
    {
        if (windowXemVideo != null && mayPhatVideoChung != null && videoCuaBaiNay != null)
        {
            // Bật cửa sổ xem video lên
            windowXemVideo.SetActive(true);

            // Nạp đúng video của bài này vào máy phát chung
            mayPhatVideoChung.clip = videoCuaBaiNay;

            // Phát video
            mayPhatVideoChung.Play();
        }
        else
        {
            Debug.LogWarning("Chưa gán đầy đủ Window xem video hoặc VideoClip!");
        }
    }

    // 3. Xử lý nút Bình luận
    public void OnClickComment()
    {
        Debug.Log("Mở khung bình luận của bài viết này!");
    }
}