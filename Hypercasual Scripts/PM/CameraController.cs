using System;
using Cinemachine;
using UnityEngine;

namespace DefaultNamespace
{
    public class CameraController : MonoBehaviour
    {
        public CinemachineBrain brain;

        private float blendDuration;

        private void Start()
        {
            blendDuration = brain.m_DefaultBlend.BlendTime;
        }

        private void Update()
        {
            brain.m_DefaultBlend.m_Time = blendDuration * DeltaTime.EnvDeltaTime;
        }
    }
}