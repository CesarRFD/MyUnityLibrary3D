using UnityEngine;

namespace _Main.Scripts.Movement_Character_Controller
{
    public class test : MonoBehaviour
    {
        private CharacterController controller;
    
        private const float GravityValue = -9.81f;

        private float _verticalVelocity = 0f;
        void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log(controller.isGrounded);
        
            // Reiniciar velocidad si estamos en el suelo
            if (controller.isGrounded && _verticalVelocity < 0)
                _verticalVelocity = -1f;

            // Aplicar gravedad
            _verticalVelocity += GravityValue * Time.deltaTime;

            // Mover el CharacterController verticalmente
            controller.Move(Vector3.up * (_verticalVelocity * Time.deltaTime));
        }
    }
}
