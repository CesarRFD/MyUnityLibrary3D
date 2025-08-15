using System;
using UnityEngine;

namespace _Main.Scripts.Movement_Character_Controller
{
    [RequireComponent(typeof(MovementCC))]
    public class Animations : MonoBehaviour
    {
        private Animator _animator;
        private MovementCC _movementCc;
        private float _horizontal;
        private float _vertical;
        private float _run;
        void Start()
        {
            _animator = GetComponentInChildren<Animator>();
            _movementCc = GetComponent<MovementCC>();
        }
        private void Update()
        {
            _horizontal = _movementCc.GetMovement().x;
            _vertical = _movementCc.GetMovement().y;
            _run = _movementCc.GetMovement().z;
            _animator.SetFloat("Horizontal", _horizontal);
            _animator.SetFloat("Vertical", _vertical);
            _animator.SetFloat("Run", _run);
        }
    }
}