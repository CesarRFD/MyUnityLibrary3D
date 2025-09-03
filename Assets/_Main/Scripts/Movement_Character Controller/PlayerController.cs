using UnityEngine;

namespace _Main.Scripts.Movement_Character_Controller
{
    [RequireComponent(typeof(Gravity))]
    public class PlayerController : MonoBehaviour
    {
        private Animator _animator;
        private Gravity _gravity;
        private float _horizontal;
        private float _vertical;
        private float _state;
        
        void Start()
        {
            _animator = GetComponentInChildren<Animator>();
            _gravity = GetComponent<Gravity>();
        }
        private void Update()
        {
            _horizontal = _gravity.GetMovement().x;
            _vertical = _gravity.GetMovement().y;
            _state = _gravity.GetMovement().z;
            
            _animator.SetFloat("Horizontal", _horizontal);
            _animator.SetFloat("Vertical", _vertical);
            _animator.SetFloat("State", _state);
        }

        public void JumpAnim()
        {
            if (_horizontal == 0 && _vertical == 0)
            {
                _animator.SetTrigger("Jump");
                return;
            }

            print("Debug_1");
            switch (_state)
            {
                case 0:
                    _animator.SetTrigger("Walk Jump");
                    break;
                case 1:
                    _animator.SetTrigger("Running Jump");
                    break;
            }
        }

        public void IsGrounded()
        {
            _animator.SetTrigger("IsGrounded");
        }
    }
}