using UnityEngine;

namespace _Main.Scripts.Camera
{
    public class BlockCursor : MonoBehaviour
    {
        void Start()
        {
            // Oculta el cursor
            Cursor.visible = false;

            // Bloquea el cursor al centro de la pantalla
            Cursor.lockState = CursorLockMode.Locked;
        }
        void Update()
        {
            // Ejemplo: presiona Escape para liberar el cursor
            /*if (Input.GetKeyDown(KeyCode.L))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }*/
        }
    }
}