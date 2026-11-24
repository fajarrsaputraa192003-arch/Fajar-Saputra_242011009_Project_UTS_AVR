using UnityEngine;
using UnityEngine.InputSystem;

public class KlikMejaInfo : MonoBehaviour
{
    [Header("Masukkan PanelDeskripsi_Meja ke sini")]
    public GameObject panelDeskripsi;

    void Update()
    {
        bool adaSentuhan = false;
        Vector2 posisiLayar = Vector2.zero;

        // Deteksi sentuhan layar HP Android
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            adaSentuhan = true;
            posisiLayar = Touchscreen.current.primaryTouch.position.ReadValue();
        }
        // Deteksi klik mouse (untuk pengujian di Unity Editor PC)
        else if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            adaSentuhan = true;
            posisiLayar = Mouse.current.position.ReadValue();
        }

        if (adaSentuhan)
        {
            Camera cam = Camera.main;
            if (cam == null) return;

            Ray ray = cam.ScreenPointToRay(posisiLayar);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform || hit.transform.IsChildOf(transform))
                {
                    if (panelDeskripsi != null)
                    {
                        panelDeskripsi.SetActive(!panelDeskripsi.activeSelf);
                    }
                }
            }
        }
    }
}