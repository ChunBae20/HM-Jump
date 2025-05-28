using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 이거 컴포넌트 넣으면 레이가 닿는 아이템 파괴시킴
/// </summary>
public class useItem : MonoBehaviour
{
    public ItemRaycaster ir;
    void Start()
    {
        
    }

    void Update()
    {
        useE();
    }

    //아이템 파괴
    void useE()
    {
        if (Input.GetKeyDown(KeyCode.E)&& ir.currentTarget !=null)
        {
            Destroy(ir.currentTarget);
        }
    }

}
