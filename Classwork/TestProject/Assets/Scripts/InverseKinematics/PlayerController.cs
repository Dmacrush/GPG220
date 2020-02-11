using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

namespace InverseKinematics
{
    public class PlayerController : MonoBehaviour
    {
        public float InputX;
        public float InputZ;
        public Vector3 desiredMoveDirection;
        public bool blockRotationPlayer;
        public float desiredRotationSpeed;
        public Animator animator;
        public float moveSpeed;
        public float allowPlayerRotation;
        public Camera cam;
        public CharacterController controller;
        public bool isGrounded;
        private float verticalVel;
        private Vector3 moveVector;

        private void Awake()
        {
            animator = this.GetComponent<Animator>();
            cam = Camera.main;
            controller = this.GetComponent<CharacterController>();
            
        }

        private void Update()
        {
            InputMagnitude();

            isGrounded = controller.isGrounded;
            if (isGrounded)
            {
                verticalVel -= 0;
            }
            else
            {
                verticalVel -= 2;
            }
            //moveVector = new Vector3(0,verticalVel,0);
            
            moveVector = new Vector3(0, verticalVel, 0).normalized;
            
            controller.Move(moveVector);
        }

        void PlayerMoveAndRotation()
        {
            InputX = Input.GetAxisRaw("Horizontal");
            InputZ = Input.GetAxisRaw("Vertical");

            var camera = Camera.main;
            var forward = cam.transform.forward;
            var right = cam.transform.right;

            forward.y = 0f;
            right.y = 0f;
            
            forward.Normalize();
            right.Normalize();

            desiredMoveDirection = forward * InputZ + right * InputX;

            if (blockRotationPlayer == false)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
                //controller.Move(desiredMoveDirection * Time.deltaTime * 2f);
            }
        }

        void InputMagnitude()
        {
            //Calculate input vectors
            InputX = Input.GetAxisRaw("Horizontal");
            InputZ = Input.GetAxisRaw("Vertical");
            
            //change 0.0 values if you want to dampen animation time,
            animator.SetFloat("InputZ", InputZ,0.0f,Time.deltaTime * 2f);
            animator.SetFloat("InputX", InputX,0.0f,Time.deltaTime * 2f);
            
            //Calcute the Input Magnitude
            moveSpeed = new Vector2(InputX, InputZ).normalized.sqrMagnitude;

            if (moveSpeed > allowPlayerRotation)
            {
                animator.SetFloat("InputMagnitude", moveSpeed, 0.0f, Time.deltaTime);
                PlayerMoveAndRotation();
            }
            else if (moveSpeed <= allowPlayerRotation)
            {
                animator.SetFloat("InputMagnitude", moveSpeed, 0.0f, Time.deltaTime);
            }
        }
    }
}
