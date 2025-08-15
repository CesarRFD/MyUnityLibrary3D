using UnityEngine;

namespace _Main.Scripts.Movement_Character_Controller
{
    public class Gravity : MonoBehaviour
    {
        private CharacterController _controller;
        private const float GravityValue = -9.81f;

        private float _verticalVelocity = 0f;
        [SerializeField] private float jumpForce = 2f;

        void Start()
        {
            _controller = GetComponent<CharacterController>();
        }
        void Update()
        {
            // Reiniciar velocidad si estamos en el suelo
            if (_controller.isGrounded && _verticalVelocity < 0) _verticalVelocity = -1f;

            // Aplicar gravedad
            _verticalVelocity += GravityValue * Time.deltaTime;

            // Mover el CharacterController verticalmente
            _controller.Move(Vector3.up * (_verticalVelocity * Time.deltaTime));
        }
        
        public void Jump()
        {
            if (_controller.isGrounded)
            {
                _verticalVelocity = Mathf.Sqrt(jumpForce * -2f * GravityValue);
            }
        }

        public float GetVerticalVelocity()
        {
            return _verticalVelocity;
        }
    }
}
