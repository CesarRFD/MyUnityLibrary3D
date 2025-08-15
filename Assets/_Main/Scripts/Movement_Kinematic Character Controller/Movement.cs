using KinematicCharacterController;
using Unity.CharacterController;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using static Unity.CharacterController.CharacterControlUtilities;

namespace _Main.Scripts.Movement_Kinematic_Character_Controller
{
    public class Movement : MonoBehaviour
    {
        private KinematicCharacterMotor _characterMotor;
        [SerializeField] private KinematicCharacterBody characterBody;
        public float3 jumpVel = new float3(0f, 5f, 0f);
        
        public InputActionAsset inputActionAsset;
        public InputAction jumpAction;

        private void Awake()
        {
            jumpAction = inputActionAsset.FindAction("Player/Jump");
        }

        void Start()
        {
            _characterMotor = GetComponent<KinematicCharacterMotor>();
            characterBody = GetComponent<KinematicCharacterBody>();
        }

        void Update()
        {
            //StandardJump(ref characterBody, jumpVel, true, new float3(0, 1, 0));
            /*if (Gamepad.current.buttonSouth.wasPressedThisFrame)
            {
                Debug.Log("Jump");
            }*/
        }

        void OnEnable()
        {
            jumpAction.Enable();
            jumpAction.performed += OnJump;
        }

        void OnDisable()
        {
            jumpAction.performed -= OnJump;
            jumpAction.Disable();
        }
        
        private void OnJump(InputAction.CallbackContext context)
        {
            Debug.Log("OnJump");
            if (characterBody.IsGrounded)
            {
                StandardJump(ref characterBody, jumpVel, true, new float3(0, 1, 0));
            }
        }
    }
}
