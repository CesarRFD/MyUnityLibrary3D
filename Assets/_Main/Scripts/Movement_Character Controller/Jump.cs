using UnityEngine;
using UnityEngine.InputSystem;

namespace _Main.Scripts.Movement_Character_Controller
{
    [RequireComponent(typeof(Gravity))]
    public class Jump : MonoBehaviour
    {
        private Gravity _gravityScript;
        private UnityEngine.CharacterController _characterController;
        private InputActionAsset _inputAsset;
        private InputAction _jumpAction;

        void Awake()
        {
            _inputAsset = Resources.Load<InputActionAsset>("InputSystem_Actions");
            _jumpAction = _inputAsset.FindAction("Player/Jump");
        }
        void Start()
        {
            _characterController = GetComponent<UnityEngine.CharacterController>();
            _gravityScript = GetComponent<Gravity>();
        }
        void OnEnable()
        {
            _jumpAction.Enable();
            _jumpAction.performed += OnJump;
        }
        void OnDisable()
        {
            _jumpAction.performed -= OnJump;
            _jumpAction.Disable();
        }
        private void OnJump(InputAction.CallbackContext context)
        {
            if (_characterController.isGrounded)
            {
                _gravityScript.Jump();
            }
        }
    }
}