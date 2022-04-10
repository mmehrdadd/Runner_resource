using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private PlayerController player;
    [SerializeField]
    public Animator anim;
    public bool isArmed;
    public bool slowMode;
    [HideInInspector]
    public bool isAk_47 = false,
                isRifle = false;
    private float speedTemp, animTemp;
    private void Start()
    {
        player = GetComponent<PlayerController>();
    }
    private void Update()
    {
        OverrideToArmed();
        if (slowMode)
        {
            if(speedTemp < 20f)
            {
                player.moveSpeed = Mathf.Lerp(player.moveSpeed, 0.08f, speedTemp * Time.deltaTime);
                speedTemp += Time.deltaTime;
            }
            if(animTemp < 50f)
            {
                anim.speed = Mathf.Lerp(anim.speed, 0.03f, animTemp * Time.deltaTime);
                animTemp += Time.deltaTime;
            }
            
            
            
        }
    }
    private void OnTriggerEnter(Collider obj)
    {
        if(obj.CompareTag(TagHolder.ak_47))
        {
            isAk_47 = true;
            isArmed = true;
            obj.gameObject.SetActive(false);           
        }
        if(obj.CompareTag(TagHolder.rifle))
        {
            isRifle = true;
            isArmed = true;
            obj.gameObject.SetActive(false);
        }
        if (obj.CompareTag(TagHolder.cameraTrigger))
        {
            player.sideSpeed = 0.1f;
            slowMode = true;
        }
    }

    public void OverrideToArmed()
    {
        
        if (isArmed)
        {
            anim.SetLayerWeight(1, 100f);
        }
        else
        {
            anim.SetLayerWeight(1, 0f);
        }
    }
}
