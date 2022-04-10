using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class AddForce : MonoBehaviour
    {
        public Vector3 direction;
        public float magnitude;

        public Rigidbody _rigidbody;
        public Animator _animator;


        
        public Rigidbody[] rigids;
        private Vector3 dir;

        public bool mainPlayer;
        public bool ok = true;
        
        private void Awake()
        {
            dir = _rigidbody.position;
            rigids = GetComponentsInChildren<Rigidbody>();
            SetRB(true);
        }

        public void SetProperties(Rigidbody rb, Animator animator)
        {
            _rigidbody = rb;
            _animator = animator;
        }

        public void RestRb()
        {
            SetRB(true);
            _animator.enabled = true;
        }
        public void SetRB(bool active)
        {
            foreach (var rb in rigids)
            {
                rb.isKinematic = active;
            }
        }
        public void Force(float mag)
        {


            if(!ok) return;
            magnitude = mag;
            StartCoroutine(ADD());

        }

        IEnumerator ADD()
        {
            if (!ok) yield break;
            _animator.enabled = false;

            SetRB(false);
            yield return null;
            _rigidbody.AddForce(-dir.normalized * magnitude * Time.deltaTime, ForceMode.Impulse);
            Debug.DrawLine(_rigidbody.position, _rigidbody.position + (dir.normalized * 10), Color.red, 20f);
            Debug.Log($"Force added to {gameObject.name}");
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            var d = Application.isPlaying ? dir : _rigidbody.position;
            Gizmos.DrawLine(d, direction*10f);
        }
    }
}