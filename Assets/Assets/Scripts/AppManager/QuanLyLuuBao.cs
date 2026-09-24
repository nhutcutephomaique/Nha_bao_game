using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Video;

public class QuanLyLuuBao : MonoBehaviour
{
    [Header("Các cửa sổ")]
    public GameObject windowSoanBao;
    public GameObject windowAnh;
    public GameObject windowVideo;

    [Header("Giao diện trong Soạn Báo")]
    public TMP_InputField inputNoiDung;
    public TMP_Text textBtnChonAnh;
    public TMP_Text textBtnChonVideo;

    [Header("Khu vực lưu trữ")]
    public Transform contentLuuBao;
    public GameObject itemBaiBaoPrefab;

    // Biến cờ static để phân biệt đang mở từ đâu
    public static bool dangChonMediaChoSoanBao = false;

    private bool daChonAnh = false;
    private bool daChonVideo = false;

    // 1. Mở cửa sổ từ nút "Chọn video" trong bảng Soạn Báo
    public void MoVideoDeChon()
    {
        dangChonMediaChoSoanBao = true; // Đánh dấu là đang mở để chọn đính kèm
        if (windowVideo != null) windowVideo.SetActive(true);
    }

    // 2. Mở cửa sổ từ icon ngoài Desktop (để xem video bình thường)
    public void MoWindowVideoBinhThuong()
    {
        dangChonMediaChoSoanBao = false; // Đánh dấu là mở xem giải trí
        if (windowVideo != null) windowVideo.SetActive(true);
    }

    public void MoAnhDeChon()
    {
        if (windowAnh != null) windowAnh.SetActive(true);
    }

    // 3. Hàm xử lý khi click vào item video con
    public void OnClickItemVideo()
    {
        if (dangChonMediaChoSoanBao)
        {
            // --- NẾU ĐANG TRONG TIẾN TRÌNH SOẠN BÁO ---
            // Chỉ ghi nhận đã chọn video, đổi tên nút, đóng cửa sổ lại và CHẶN không cho phát video
            daChonVideo = true;
            if (textBtnChonVideo != null) textBtnChonVideo.text = "Đã chọn video";
            if (windowVideo != null) windowVideo.SetActive(false);

            // Reset lại cờ ngay sau khi chọn xong
            dangChonMediaChoSoanBao = false;
        }
        else
        {
            // --- NẾU MỞ TỪ DESKTOP ---
            // Không làm gì cả, để mặc kệ cho script quản lý video của bạn tự động phát như bình thường!
        }
    }

    public void ChonAnhThanhCong()
    {
        daChonAnh = true;
        if (textBtnChonAnh != null) textBtnChonAnh.text = "Đã chọn ảnh";
        if (windowAnh != null) windowAnh.SetActive(false);
    }

    // 4. Lưu bài báo vào Window_LuuBao
    public void NhanNutLuu()
    {
        if (inputNoiDung == null || (string.IsNullOrEmpty(inputNoiDung.text) && !daChonAnh && !daChonVideo))
        {
            Debug.LogWarning("Vui lòng nhập nội dung hoặc chọn media!");
            return;
        }

        if (itemBaiBaoPrefab != null && contentLuuBao != null)
        {
            GameObject baiBaoMoi = Instantiate(itemBaiBaoPrefab, contentLuuBao);
            TMP_Text txt = baiBaoMoi.transform.Find("TextNoiDung")?.GetComponent<TMP_Text>();
            if (txt != null)
            {
                string info = inputNoiDung.text;
                if (daChonAnh) info += "\n[Đã đính kèm Ảnh]";
                if (daChonVideo) info += "\n[Đã đính kèm Video]";
                txt.text = info;
            }
        }

        NhanNutClear();
    }

    // 5. Clear / Reset form
    public void NhanNutClear()
    {
        if (inputNoiDung != null) inputNoiDung.text = "";
        daChonAnh = false;
        daChonVideo = false;
        dangChonMediaChoSoanBao = false;

        if (textBtnChonAnh != null) textBtnChonAnh.text = "Chọn ảnh";
        if (textBtnChonVideo != null) textBtnChonVideo.text = "Chọn video";
    }
}