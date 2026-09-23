using UnityEngine;
using UnityEngine.UI; // Thư viện để dùng UI

public class AppManager : MonoBehaviour
{
    [Header("Giao diện")]
    public Transform contentGrid; // Vị trí chứa các ô lưới
    public GameObject itemPrefab; // Khuôn đúc (Prefab) bạn vừa tạo

    [Header("Dữ liệu thật")]
    public Sprite[] myPhotos; // Danh sách các file ảnh thực tế của bạn

    void Start()
    {
        // Tự động nạp ảnh khi cửa sổ bật lên
        LoadFiles();
    }

    void LoadFiles()
    {
        // Duyệt qua từng bức ảnh có trong danh sách
        foreach (Sprite photo in myPhotos)
        {
            // 1. Sinh ra một ô trắng mới từ khuôn Prefab, đặt vào trong Content
            GameObject newItem = Instantiate(itemPrefab, contentGrid);

            // 2. Thay hình màu trắng bằng bức ảnh thật
            newItem.GetComponent<Image>().sprite = photo;
        }
    }
}