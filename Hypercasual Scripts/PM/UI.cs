using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class UI : MonoBehaviour
    {
        public Button[] buttons;
        public Animator[] buttonsAnims;
        public int[] order;
        public CanvasLook canvas1;
        public CanvasLook canvas2;

        private void Awake()
        {
            buttons[0].onClick.AddListener(()=>On(order[0]));
            buttons[1].onClick.AddListener(()=>On(order[1]));
            buttons[2].onClick.AddListener(()=>On(order[2]));

        }

        private int canvasNo;
        public void On(int i)
        {
            if (!canvas1.Finished)
            {
                canvas1.On(i);
            }
            else if(!canvas2.Finished)
            {
                canvas2.On(i);
                Check();

            } 
        }

        public GameMan gameMan;
        private void Check()
        {
            if (canvas2.Finished) gameMan.win = true;
            else
            {
                gameMan.win = false;
            }
        }
    }
}