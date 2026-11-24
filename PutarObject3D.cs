using UnityEngine;
using UnityEngine.InputSystem;

public class PutarObjek3D : MonoBehaviour
{
    [Tooltip("Kecepatan putaran meja saat digeser")]
    public float kecepatanPutar = 0.4f;

    void Update()
    {
        // Kontrol geseran jari di layar HP (Android)
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 geseran = Touchscreen.current.primaryTouch.delta.ReadValue();
            transform.Rotate(0f, -geseran.x * kecepatanPutar, 0f, Space.Self);
        }
        // Kontrol geseran mouse untuk uji coba di Unity Editor
        else if (Mouse.current != null && Mouse.current.leftButton.isPressed)
        {
            Vector2 geseranMouse = Mouse.current.delta.ReadValue();
            transform.Rotate(0f, -geseranMouse.x * kecepatanPutar, 0f, Space.Self);
        }
    }
}