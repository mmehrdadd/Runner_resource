using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

namespace DefaultNamespace
{
    public class TimelineContrller : MonoBehaviour
    {
        public PlayableDirector defaultTimeline;

        private bool isPlaying;
        public bool startOnAwake;
        private float _time;

        private float _timeUnit = 0.01f;

        private float WeightedUnit => _timeUnit * DeltaTime.EnvDeltaTime;
        private void Start()
        {
            defaultTimeline.timeUpdateMode = DirectorUpdateMode.Manual;
            if (startOnAwake)
            {
                Play();
            }
        }

        private void Update()
        {
            
        Playback();
        }

        public void Playback()
        {
            if(!isPlaying) return;
            var t = WeightedUnit;
            _time += t;
            defaultTimeline.time = _time;
            defaultTimeline.Evaluate();

        }
        public void Play()
        {
            isPlaying = true;
        }

        public void Pause()
        {
            isPlaying = false;
        }

        public void Stop()
        {
            isPlaying = false;
            _time = 0f;
            defaultTimeline.time = _time;
        }

        private IEnumerator Pass()
        {
            while (_time < defaultTimeline.duration)
            {
                var t = WeightedUnit;
                _time += t;
                defaultTimeline.time = _time;
                yield return new WaitForSecondsRealtime(t);
            }

        }
    }
}