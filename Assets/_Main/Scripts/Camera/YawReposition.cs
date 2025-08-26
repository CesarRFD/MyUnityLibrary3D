using UnityEngine;

namespace _Main.Scripts.Camera
{
    public class YawReposition : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform target; // Personaje al que sigue la cámara
        [SerializeField] private CharacterController characterController;
        
        [Header("Camera Settings")]
        [SerializeField] private float distance = 3f;       // Distancia de la cámara al personaje
        [SerializeField] private float smoothTime = 0.1f;   // Suavidad del movimiento
        [SerializeField] private float rotationSpeed = 90f; // Velocidad de rotación en grados por segundo
        
        [Header("Rotation Control")]
        [SerializeField] private bool rotateCamera = false; // Booleano que controla si la cámara debe rotar

        private float _yaw;   // Rotación horizontal
        private Vector3 _currentVelocity;
        
        void Start()
        {
            _yaw = target.eulerAngles.y;
        }

        void LateUpdate()
        {
            
        }
    }
}
