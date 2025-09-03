using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

namespace _Main.Scripts.Movement_Character_Controller
{
    [RequireComponent(typeof(Gravity))]
    public class Jump : MonoBehaviour
    {
        private Gravity _gravityScript;
        private CharacterController _characterController;
        private PlayerController _playerController;
        private InputActionAsset _inputAsset;
        private InputAction _jumpAction;

        public float tempJumpTime = 0.20f;

        void Awake()
        {
            _inputAsset = Resources.Load<InputActionAsset>("InputSystem_Actions");
            _jumpAction = _inputAsset.FindAction("Player/Jump");
        }
        void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _gravityScript = GetComponent<Gravity>();
            _playerController = GetComponent<PlayerController>();
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
                StartCoroutine(StartJump(tempJumpTime));
                _playerController.JumpAnim();
            }
        }

        IEnumerator StartJump(float time)
        {
            yield return new WaitForSeconds(time);
            _gravityScript.Jump();
        }
    }
}