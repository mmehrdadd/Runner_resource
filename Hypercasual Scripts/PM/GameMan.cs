using UnityEngine;
using UnityEngine.Playables;

namespace DefaultNamespace
{
    public class GameMan : MonoBehaviour
    {
        public AddForce player;
        public PlayableDirector tLose;
        public PlayableDirector tWin;

        public float winTime;
        

        public bool win;

        public void Pause()
        {
            if(!win) tLose.Pause();

        }

        public void PlayWin()
        {
            if (tLose.isActiveAndEnabled)
            {
                // tLose.enabled = false;
            }

            // tLose.Stop();
            // tWin.Play();
            // tWin.enabled = true;\
            // tLose.Stop();
            // tLose.timeUpdateMode = DirectorUpdateMode.Manual;
            tLose.time = winTime;    
            // tLose.Play();
            // tLose.enabled = false;
        }

        public void PlayEnd()
        {
            player.ok = !win;
            if(win) PlayWin();
            ;
        }
    }
}