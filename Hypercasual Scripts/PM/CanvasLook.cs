using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CanvasLook : MonoBehaviour
{

    public Camera cam;

    public Transform attach;

    public Vector3 offset;

    public Animator panel;

    public Animator[] buttons;

    public int[] order;
    public float interval = 0.2f;

    private Dictionary<int, Animator> dic;
    public int ons;

    private void Awake(){
        dic = new Dictionary<int, Animator>();
        for (int i = 0; i < order.Length; i++)
        {
            dic.Add(order[i], buttons[i]);
            
        }
}

    // Start is called before the first frame update
    void Start()
    {
        if(cam == null)
            cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cam.transform.position);
        transform.position = attach.position + offset;
    }

    private void OnValidate()
    {
        transform.LookAt(cam.transform.position);
        transform.position = attach.position + offset;
        
    }

    public bool Finished => ons > 2;

    public void On(int index)
    {
        if(index != order[ons]) return;

        if(Finished) return;
        dic[index].gameObject.SetActive(false);
        // dic[index].SetTrigger("On");
        ons++;
        if (ons >= 3)
        {
            DOVirtual.DelayedCall(1f, () =>
            {
                // panel.gameObject.SetActive(false);;
                // panel.SetTrigger("Approve")

            }).timeScale = 1;

        }






    }
    public void PlayCanvas() => StartCoroutine(Play());
    IEnumerator Play()
    {
        panel.enabled = false;
        foreach (var button in buttons)
        {
            button.SetTrigger("On");
            yield return new WaitForSeconds(interval);
        }

        yield return new WaitForSeconds(interval);

        panel.enabled = true;
        panel.SetTrigger("Approve");

        yield return new WaitForSeconds(.5f);

        foreach (var button in buttons)
        {
                button.SetTrigger("Off");
        }

    }
}
