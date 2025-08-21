using System;
using UnityEngine;

namespace _Main.Scripts.Movement_Character_Controller
{
    [RequireComponent(typeof(Gravity))]
    public class CharacterController : MonoBehaviour
    {
        private Animator _animator;
        private Gravity _gravity;
        private float _horizontal;
        private float _vertical;
        private float _run;
        void Start()
        {
            _animator = GetComponentInChildren<Animator>();
            _gravity = GetComponent<Gravity>();
        }
        private void Update()
        {
            _horizontal = _gravity.GetMovement().x;
            _vertical = _gravity.GetMovement().y;
            _run = _gravity.GetMovement().z;
            _animator.SetFloat("Horizontal", _horizontal);
            _animator.SetFloat("Vertical", _vertical);
            _animator.SetFloat("Run", _run);
        }
    }
}