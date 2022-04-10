using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class SlowMotion : MonoBehaviour
    {    
        public float transitionSpeed = 1f;
        public float playerWeight = 0.2f;
        public float enemyWeight = 0.2f;
        public float envWeight = 0.3f;

        public float duration;
        private bool _slowCommand;
        private bool _slowed;

        private bool CanSlow => _slowCommand && !_slowed;

        public void RestSlow()
        {
           DeltaTime.RestAll();
           _slowCommand = false;
           _slowed = false;
        }
        public void SlowMo()
        {
            _slowCommand = true;
        }
        private void SetToSlowMotion()
        {
            if (CanSlow) StartCoroutine(StartSlowMotion());
        }

        private IEnumerator StartSlowMotion()
        {
            _slowed = true;
            yield return LerpToSlow();
            yield return new WaitForSecondsRealtime(duration);
            yield return LerpToDefault();
            _slowed = false;
            _slowCommand = false;
        }

        private IEnumerator LerpToSlow() => LerpSlowVariable(playerWeight, enemyWeight, envWeight);

        private IEnumerator LerpToDefault() => LerpSlowVariable(DeltaTime.DefaultDelta);

        private IEnumerator LerpSlowVariable(float weight) => LerpSlowVariable(weight, weight, weight);
        private IEnumerator LerpSlowVariable(float player, float agent, float env)
        {
            float i = 0f;
            var playerCurrent = DeltaTime.PlayerDeltaTime;
            var agentsCurrent = DeltaTime.AgentDeltaTime;
            var envCurrent = DeltaTime.EnvDeltaTime;
            
            while (i < 1f)
            {
                i += Time.deltaTime * transitionSpeed;
                DeltaTime.PlayerDeltaTime = Mathf.Lerp(playerCurrent, player, i);
                DeltaTime.AgentDeltaTime = Mathf.Lerp(agentsCurrent, agent, i);
                DeltaTime.EnvDeltaTime = Mathf.Lerp(envCurrent, env, i);
                yield return null;
            }
        }
    }
}