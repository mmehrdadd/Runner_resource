using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    
    public float comboValue;
    public bool isComboFull;
    
    public Canvas canvas;
    private UIdisplay _uiDisplay;
    private float tempCombo , lerpDuration = 3f;
    void Start()
    {
        _uiDisplay = canvas.GetComponent<UIdisplay>();
        _uiDisplay.comboBar.fillAmount = 0f;
        comboValue = tempCombo  = 0f;
        isComboFull = false;
    }
    private void Update()
    {
        if (tempCombo < comboValue)
        {
            //_uiDisplay.comboBar.fillAmount = Mathf.Lerp(_uiDisplay.comboBar.fillAmount, comboValue, tempCombo / lerpDuration);
            _uiDisplay.comboBar.fillAmount += Time.deltaTime;
            tempCombo += Time.deltaTime;

        }
    }
    public void AddCombo(float value)
    {
        if (comboValue <= 1)
        {            
            comboValue += value / 100;
                                          
        }
        else
        {
            isComboFull = true;
        }
    }
    private void OnTriggerEnter(Collider obj)
    {
        if(obj.CompareTag(TagHolder.bluePill) || obj.CompareTag(TagHolder.redPill))
        {
            obj.gameObject.SetActive(false);
            AddCombo(obj.GetComponent<ItemManager>().item.comboBooster);           
        }                    
    }

}

