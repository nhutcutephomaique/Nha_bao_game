using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerInterac : MonoBehaviour
{
    public GameObject computerUI;

    private void OnMouseDown()
    {
        if (computerUI != null)
        {
            computerUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
