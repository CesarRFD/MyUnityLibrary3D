using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Main.Scripts.Movement_Character_Controller
{
    public class PlayerYawRotation : MonoBehaviour
    {
        [Header("References")]
        private InputActionAsset _inputAsset;
        private InputAction _look;
        private Transform _player;
        private CharacterController _characterController;

        private float _yaw;
        [SerializeField] private float sensitivity = 2f;
        
        private void Awake()
        {
            _inputAsset = Resources.Load<InputActionAsset>("InputSystem_Actions");
            _look = _inputAsset.FindAction("Player/Look");
            _player = GetComponent<Transform>();
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            if (_characterController.velocity != Vector3.zero) {
                Vector2 lookInput = _look.ReadValue<Vector2>();
                _yaw += lookInput.x * sensitivity;
                Quaternion rotation = Quaternion.Euler(0f, _yaw, 0f);
                _player.transform.rotation = rotation;
            }
        }
    }
}