using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{

    public Image Water;

    //대쉬작용
    public bool isDash = false;
    public float nextDebugTime = 0f;



    void Start()
    {
        Water = GetComponent<Image>();
    }

    void Update()
    {
        UseStamina();
        BasicHealStamina();
        if (Time.time >= nextDebugTime)
        {
            Debug.Log(" 현재 대쉬상태 : " + isDash);
            nextDebugTime = Time.time + 1f;
        }

    }

    //대쉬연동 예정
    void UseStamina()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isDash = true;
            Water.fillAmount -=0.2f*Time.deltaTime;
            
        }
        else
        {
            isDash = false;
        }
    }

    void BasicHealStamina()
    {
        Water.fillAmount += 0.08f * Time.deltaTime;

    }
    

}
