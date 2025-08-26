using UnityEngine;
using UnityEngine.InputSystem;

namespace _Main.Scripts.Camera
{
    public class CameraMove : MonoBehaviour
    {
        [Header("References")]
        private InputActionAsset _inputAsset;
        private InputAction _look;
        [SerializeField] private Transform target; 
        [SerializeField] private CharacterController characterController;
        
        [Header("Camera Settings")]
        [SerializeField] private float sensitivity = 2f;   // Sensibilidad de la cámara
        [SerializeField] private float distance = 3f;      // Distancia entre la cámara y el personaje
        [SerializeField] private float smoothTime = 0.1f;  // Suavidad del movimiento
        [SerializeField] private float rotationSpeed = 90f; // Velocidad de rotación en grados por segundo

        
        [Header("Vertical Limits")]
        [SerializeField] private float minVerticalAngle = -30f; // Ángulo mínimo (mirando hacia abajo)
        [SerializeField] private float maxVerticalAngle = 70f;  // Ángulo máximo (mirando hacia arriba)

        [SerializeField] private float _yaw = 0;   // Rotación horizontal (izquierda/derecha)
        [SerializeField] private float _pitch = 0; // Rotación vertical (arriba/abajo)
        private Vector3 _currentVelocity; // Para suavizar el movimiento

        private void Awake()
        {
            _inputAsset = Resources.Load<InputActionAsset>("InputSystem_Actions");
            _look = _inputAsset.FindAction("Player/Look");
        }

        private void OnEnable()
        {
            _look.Enable();
        }

        private void OnDisable()
        {
            _look.Disable();
        }
        
        private void LateUpdate()
        {
            if (!target) return;

            // 1. Obtener movimiento del mouse / stick derecho
            Vector2 lookInput = _look.ReadValue<Vector2>();

            // 2. Actualizar ángulos de rotación
            if (characterController.velocity == Vector3.zero)
            {
                _yaw += lookInput.x * sensitivity;
                _pitch -= lookInput.y * sensitivity;
            }
            else
            {
                _yaw = characterController.transform.rotation.eulerAngles.y;
                _pitch -= lookInput.y * sensitivity;
            }

            // 3. Limitar la rotación vertical
            _pitch = Mathf.Clamp(_pitch, minVerticalAngle, maxVerticalAngle);

            // 4. Calcular la rotación de la cámara
            Quaternion rotation = Quaternion.Euler(_pitch, _yaw, 0f);

            // 5. Calcular posición deseada detrás del personaje
            Vector3 desiredPosition = target.position - rotation * Vector3.forward * distance;

            // 6. Aplicar suavizado
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref _currentVelocity, smoothTime);

            // 7. Hacer que la cámara mire al personaje
            transform.LookAt(target.position + Vector3.up * 1.5f); // Ajusta la altura del "lookAt"}
        }
    }
}