using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace DefaultNamespace
{
    public class FrameFreezer : MonoBehaviour
    {

        public VolumeProfile vintageProfile;
        public float vingateIntesity = 0.5f;
        public float duration = 0.4f;
        public float slowmoScale = 0.1f;
        public float slowmoDur = 2f;
        public float slowmoSpeed = 2f;
        private bool freeze;
        private bool freezed;

        private bool slowed;
        private bool slowCommand;

        private Vignette _vignette;

        private void Start()

        {
            vintageProfile.TryGet(out _vignette);
            
        }

        private void Update()
        {
            if(slowCommand && !slowed  )                StartCoroutine(Slow());

            if (freeze && !freezed)
            {
                StartCoroutine(FreezWait());
            }
            
        }

        public void Freeze()
        {
            freeze = true;
        }

        public void SlowMotion()
        {
            slowCommand = true;
        }

        private IEnumerator FreezWait()
        {
            freezed = true;
            var scale = Time.timeScale;

            Time.timeScale = 0f;

            yield return new WaitForSecondsRealtime(duration);

            Time.timeScale = scale;
            freezed = false;
            freeze = false;
        }
    
        private IEnumerator Slow()
        {
            slowed = true;
            var scale = Time.timeScale;


            // DOVirtual.Float(_vignette.intensity.value, vingateIntesity, slowmoDur, i => _vignette.intensity.value = i).timeScale = 1f;
            yield return ToSlow(1, slowmoScale, vingateIntesity);
            yield return new WaitForSecondsRealtime(slowmoDur);
            yield return ToSlow(slowmoScale, 1, 0f);
            // DOVirtual.Float(_vignette.intensity.value, 0f, 0.3f, i => _vignette.intensity.value = i);

            slowed = false;
            slowCommand = false;
        }


        private IEnumerator ToSlow(float var1, float var2, float var3 )
        {
            float i = 0f;
            var val = _vignette.intensity.value;
            while (i < 1f)
            {
                i += Time.unscaledDeltaTime * slowmoSpeed;
                _vignette.intensity.value = Mathf.Lerp(val, var3, i);
                Time.timeScale = Mathf.Lerp(var1, var2, i);
                
                yield return null;
            }
        }
    }
}