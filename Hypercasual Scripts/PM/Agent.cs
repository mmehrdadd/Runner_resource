using System;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class Agent : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Animator _animator;
        [SerializeField] private AddForce _motor;
        protected abstract float DeltaTime { get; }

        private void Start()
        {
            // _motor.SetProperties(_rigidbody, _animator);
        }

        protected void UpdateDeltaTime()
        {
            _animator.speed = DeltaTime;
        }

        public void RagdollOn()
        {
            _motor.SetRB(true);
        }

        public void RagdollOff()
        {
            _motor.SetRB(false);
        }
        
        
        private void Update()
        {    
            UpdateDeltaTime();
        }
    }
}