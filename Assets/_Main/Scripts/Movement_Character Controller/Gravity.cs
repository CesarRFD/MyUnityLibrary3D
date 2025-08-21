using UnityEngine;
using UnityEngine.InputSystem;

namespace _Main.Scripts.Movement_Character_Controller
{
    public class Gravity : MonoBehaviour
    {
        private InputActionAsset _inputAsset;
        private InputAction _move;
        private InputAction _run;
        private int _horizontalInt = 0;
        private int _verticalInt = 0;
        private int _runInt = 0;
        [SerializeField] private float velocity = 1;
        
        private UnityEngine.CharacterController _controller;
        private const float GravityValue = -9.81f;

        private float _verticalVelocity = 0f;
        [SerializeField] private float jumpForce = 2f;

        void Awake()
        {
            _inputAsset = Resources.Load<InputActionAsset>("InputSystem_Actions");
            _move = _inputAsset.FindAction("Player/Move");
            _run = _inputAsset.FindAction("Player/Run");
        }
        void Start()
        {
            _controller = GetComponent<UnityEngine.CharacterController>();
        }
        void Update()
        {
            // Reiniciar velocidad si estamos en el suelo
            if (_controller.isGrounded && _verticalVelocity < 0) _verticalVelocity = -1f;
            if (!_move.IsPressed() && _controller.isGrounded) _horizontalInt = 0;
            if (!_move.IsPressed() && _controller.isGrounded) _verticalInt = 0;

            // Aplicar gravedad
            _verticalVelocity += GravityValue * Time.deltaTime;

            // Mover el CharacterController verticalmente
            _controller.Move(new Vector3(_horizontalInt * velocity, _verticalVelocity, _verticalInt * velocity) * Time.deltaTime);
        }

        void OnEnable()
        {
            _move.Enable();
            _move.performed += _OnMove;
            _move.canceled += _OnMoveStop;
            _run.Enable();
            _run.performed += OnRun;
            _run.canceled += OnRunUp;
        }

        void OnDisable()
        {
            _move.canceled -= _OnMove;
            _move.Disable();
            _run.performed -= OnRun;
            _run.canceled -= OnRunUp;
            _run.Disable();
        }
        
        public void Jump()
        {
            if (_controller.isGrounded)
            {
                _verticalVelocity = Mathf.Sqrt(jumpForce * -2f * GravityValue);
            }
        }

        public void _OnMove(InputAction.CallbackContext context)
        {
            if (_controller.isGrounded)
            {
                float horizontal = _move.ReadValue<Vector2>().x;
                _horizontalInt = Mathf.RoundToInt(horizontal);
                float vertical = _move.ReadValue<Vector2>().y;
                _verticalInt = Mathf.RoundToInt(vertical);
            }
        }

        public void _OnMoveStop(InputAction.CallbackContext context)
        {
            if (_controller.isGrounded)
            {
                _horizontalInt = 0;
                _verticalInt = 0;
            }
        }
        
        private void OnRun(InputAction.CallbackContext context)
        {
            if (_controller.isGrounded)
            {
                velocity += 3f;
                _runInt = 1;
            }
        }
        private void OnRunUp(InputAction.CallbackContext context)
        {
            if (_controller.isGrounded)
            {
                velocity -= 3f;
                _runInt = 0;
            }
        }
        public Vector3 GetMovement()
        {
            return new Vector3(_horizontalInt, _verticalInt, _runInt);
        }
    }
}
