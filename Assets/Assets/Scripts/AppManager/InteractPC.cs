using UnityEngine;

public class InteractPC : MonoBehaviour
{
    [Header("Gán các object vào đây")]
    public Camera playerCamera; // Kéo Main Camera của nhân vật vào đây
    public Transform pcViewPoint; // Kéo cái PC_CameraPoint vừa tạo vào đây

    // Các biến để nhớ vị trí cũ của nhân vật
    private Transform originalCameraParent;
    private Vector3 originalLocalPos;
    private Quaternion originalLocalRot;

    private bool isUsingPC = false;

    // Hàm này tự động chạy khi bạn click chuột trái vào Box Collider của object này
    void OnMouseDown()
    {
        if (!isUsingPC)
        {
            EnterPC();
        }
    }

    void Update()
    {
        // Bấm phím E để thoát máy tính (giống chữ E - Leave của bạn)
        if (isUsingPC && Input.GetKeyDown(KeyCode.Escape))
        {
            ExitPC();
        }
    }

    void EnterPC()
    {
        isUsingPC = true;

        // Lưu lại vị trí cũ của camera để lát trả về
        originalCameraParent = playerCamera.transform.parent;
        originalLocalPos = playerCamera.transform.localPosition;
        originalLocalRot = playerCamera.transform.localRotation;

        // Tháo camera khỏi người chơi, dịch chuyển tức thời đến trước màn hình
        playerCamera.transform.SetParent(null);
        playerCamera.transform.position = pcViewPoint.position;
        playerCamera.transform.rotation = pcViewPoint.rotation;

        // (Tùy chọn) Mở khóa chuột để bấm các icon
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void ExitPC()
    {
        isUsingPC = false;

        // Gắn camera trả lại vào người chơi
        playerCamera.transform.SetParent(originalCameraParent);
        playerCamera.transform.localPosition = originalLocalPos;
        playerCamera.transform.localRotation = originalLocalRot;

        // (Tùy chọn) Khóa chuột lại vào giữa màn hình để đi lại
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}