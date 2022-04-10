using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField]
    public ParticleSystem bluePillEffect,
                          redpillEffect,
                          fullComboEffect;
    [SerializeField]
    public GameObject canvas;
    private UIdisplay _uiDisplay;
    bool stopEffect = true;

    private void Start()
    {
        _uiDisplay = canvas.GetComponent<UIdisplay>();
    }
    private void Update()
    {
        if(_uiDisplay.comboBar.fillAmount == 1 && stopEffect)
        {           
            fullComboEffect.Play();             
            stopEffect = false;
            CinemachineShake.instanse.CameraShake(3f, 0.2f);
        }
    }
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag(TagHolder.bluePill))
        {
            bluePillEffect.Play();
        }
        if (obj.CompareTag(TagHolder.redPill))
        {
            redpillEffect.Play();
        }
    }
}
