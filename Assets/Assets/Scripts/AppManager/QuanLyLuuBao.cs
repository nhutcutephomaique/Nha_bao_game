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

    [Header("Trình phát video (Màn chiếu)")]
    public VideoPlayer mayPhatVideo; // Kéo Video Player vào đây trên Inspector

    private bool daChonAnh = false;
    private bool daChonVideo = false;
    private static bool dangChonMediaChoSoanBao = false;

    // Lưu trữ VideoClip của từng nút được gắn trực tiếp qua Inspector của nút
    public VideoClip videoTamThoi;

    public void MoVideoDeChon()
    {
        dangChonMediaChoSoanBao = true;
        if (windowVideo != null) windowVideo.SetActive(true);
    }

    public void MoWindowVideoBinhThuong()
    {
        dangChonMediaChoSoanBao = false;
        if (windowVideo != null) windowVideo.SetActive(true);
    }

    public void MoAnhDeChon()
    {
        if (windowAnh != null) windowAnh.SetActive(true);
    }

    // Hàm duy nhất nhận sự kiện khi bấm vào các item video con
    public void OnClickItemVideo(VideoClip clipCuaNut)
    {
        if (dangChonMediaChoSoanBao)
        {
            // --- KHI ĐANG SOẠN BÁO: CHỈ CHỌN ---
            daChonVideo = true;
            if (textBtnChonVideo != null) textBtnChonVideo.text = "Đã chọn video";
            if (windowVideo != null) windowVideo.SetActive(false);
            dangChonMediaChoSoanBao = false;
        }
        else
        {
            // --- KHI XEM BÌNH THƯỜNG: PHÁT VIDEO ---
            if (mayPhatVideo != null && clipCuaNut != null)
            {
                mayPhatVideo.gameObject.SetActive(true);
                mayPhatVideo.enabled = true;
                mayPhatVideo.clip = clipCuaNut;
                mayPhatVideo.Play();
            }
        }
    }

    public void ChonAnhThanhCong()
    {
        daChonAnh = true;
        if (textBtnChonAnh != null) textBtnChonAnh.text = "Đã chọn ảnh";
        if (windowAnh != null) windowAnh.SetActive(false);
    }

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