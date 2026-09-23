using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

// Cấu trúc này giúp bạn gộp 1 Ảnh và 1 Video thành 1 cặp để dễ quản lý trong Inspector
[System.Serializable]
public class ThongTinVideo
{
    public Sprite anhBia;
    public VideoClip filePhim;
}

public class QuanLyVideo : MonoBehaviour
{
    [Header("Thành phần UI")]
    public GameObject nutVideoPrefab; // Cái khuôn (Prefab) bạn vừa tạo
    public Transform contentGrid;     // Object Content (Nơi chứa danh sách lưới)

    [Header("Màn chiếu chung")]
    public GameObject cuaSoXemVideo;  // Cửa sổ "Window_xemVideo"
    public VideoPlayer mayPhatVideo;  // Object "ManChieu"

    [Header("Danh Sách Phim (Kéo thả vào đây)")]
    public ThongTinVideo[] danhSachPhim;

    void Start()
    {
        // Khi bật lên, duyệt qua toàn bộ phim bạn đã thêm vào danh sách
        foreach (ThongTinVideo phim in danhSachPhim)
        {
            // 1. Tự động đẻ ra 1 nút mới từ khuôn, nhét vào trong Content
            GameObject nutMoi = Instantiate(nutVideoPrefab, contentGrid);

            // 2. Thay hình ảnh Thumbnail cho nút đó
            nutMoi.GetComponent<Image>().sprite = phim.anhBia;

            // 3. Nạp dữ liệu phim và màn chiếu vào Script VideoClick của nút đó
            VideoClick lenhCuaNut = nutMoi.GetComponent<VideoClick>();
            lenhCuaNut.videoCuaToi = phim.filePhim;
            lenhCuaNut.cuaSoXemVideo = cuaSoXemVideo;
            lenhCuaNut.mayPhatVideo = mayPhatVideo;
        }
    }
}