using UnityEngine;
using UnityEngine.Video; // Gọi thư viện Video

public class VideoClick : MonoBehaviour
{
    [Header("Dữ liệu của nút này")]
    public VideoClip videoCuaToi; // File mp4 sẽ phát khi bấm nút này

    [Header("Kết nối với Màn chiếu")]
    public GameObject cuaSoXemVideo; // Cửa sổ "Window_xemVideo" đã làm ban nãy
    public VideoPlayer mayPhatVideo; // Object "ManChieu" chứa VideoPlayer ban nãy

    // Hàm này sẽ chạy khi bạn click chuột vào nút hồng
    public void MoVaPhatVideo()
    {
        // 1. Bật cửa sổ popup xem video lên
        if (cuaSoXemVideo == null || mayPhatVideo == null || videoCuaToi == null)
        {
            Debug.LogWarning("VideoClick chưa được gán cửa sổ, VideoPlayer hoặc VideoClip.");
            return;
        }

        cuaSoXemVideo.SetActive(true);
        mayPhatVideo.gameObject.SetActive(true);
        mayPhatVideo.enabled = true;

        // 2. Nạp đúng file mp4 của nút này vào máy phát
        mayPhatVideo.clip = videoCuaToi;

        // 3. Ra lệnh phát video
        mayPhatVideo.Play();
    }
}