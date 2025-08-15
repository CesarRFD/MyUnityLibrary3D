using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


namespace _Main.Scripts.Movement_Character_Controller
{
    public class MovementCC : MonoBehaviour
    {
        private Gravity _gravity;
        private InputActionAsset _inputAsset;
        private InputAction _move;
        private InputAction _run;
        private CharacterController _characterController;
        private int _horizontalInt = 0;
        private int _verticalInt = 0;
        private int _runInt = 0;
        private Vector3 _movement = new Vector3(0, 0, 0);
        
        [SerializeField] private float velocity;
        
        void Awake()
        {
            _inputAsset = Resources.Load<InputActionAsset>("InputSystem_Actions");
            _move = _inputAsset.FindAction("Player/Move");
            _run = _inputAsset.FindAction("Player/Run");
        }

        void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _gravity = GetComponent<Gravity>();
        }
        void OnEnable()
        {
            _move.Enable();
            _run.Enable();
            _run.performed += OnRun;
            _run.canceled += OnRunUp;
        }

        void OnDisable()
        {
            _run.performed -= OnRun;
            _run.canceled -= OnRunUp;
            _run.Disable();
            _move.Disable();
        }
        
        private void OnRun(InputAction.CallbackContext context)
        {
            if (_characterController.isGrounded)
            {
                velocity += 3f;
                _runInt = 1;
            }
        }
        private void OnRunUp(InputAction.CallbackContext context)
        {
            if (_characterController.isGrounded)
            {
                velocity -= 3f;
                _runInt = 0;
            }
        }

        void Update()
        {
            float horizontal = _move.ReadValue<Vector2>().x;
            _horizontalInt = Mathf.RoundToInt(horizontal);
            float vertical = _move.ReadValue<Vector2>().y;
            _verticalInt = Mathf.RoundToInt(vertical);
            
            _movement = new Vector3(horizontal * (velocity * Time.deltaTime), _gravity.GetVerticalVelocity(), vertical * (velocity * Time.deltaTime));
            _characterController.Move(_movement);
            
            Debug.Log("IsGrounded: " + _characterController.isGrounded + "\n " + _characterController.velocity.y);
        }

        public Vector3 GetMovement()
        {
            return new Vector3(_horizontalInt, _verticalInt, _runInt);
        }
    }
}
