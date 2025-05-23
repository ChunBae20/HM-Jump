using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using static ItemSo;

[CreateAssetMenu(fileName ="ItemInfo",menuName ="ScriptableObject/ItemInfo",order = int.MaxValue)]
public class ItemSo : ScriptableObject
{
    //아이템 이름 정하기
    //[Header("아이템 이름")]
    [Tooltip("이름을 등록하세요")]
    [SerializeField]
    private string itemName;
    public string ItemName { get { return itemName; } }

    //아이템 설명
    //[Header("아이템 설명")]
    [Tooltip("아이템의 설명쓰셈")]
    [SerializeField]
    private string itemDescription;
    public string ItemDescription { get { return itemDescription; } }

    //아이템 등급
    public enum ItemTier { [InspectorName("뒤틀린 황천의")] 튀틀린황천의,일반,레어,레전더리}

    //자동적용
    [SerializeField]
    private ItemTier itemTier;
    public int TierStat
    {
        get
        {
            switch (itemTier )
            {
                case ItemTier.튀틀린황천의: return -100;
                case ItemTier.일반: return 10;
                case ItemTier.레어: return 50;
                case ItemTier.레전더리: return 100;
                default: return 0;
            }
        }
    }

    //먹을수있는가
    [Header("먹을 수 있는지")]
    [Tooltip("먹는템인지 설정")]
    [SerializeField]
    private bool canEdible;
    public bool CanEdible { get { return canEdible; } }

    //먹는 템은 어떤스탯을 조정하는가
    //음식을 고르면체력을 음료수를 고르면 스태미나를
    public enum ThisEdibleType { 음료수, 음식, 무기를드신다고요 }

    [SerializeField]
    private ThisEdibleType edibleType;
    public ThisEdibleType EdibleType { get { return edibleType; } }
    

    //아이템 타입
    //private enum ItemType { 장비 , 음식, 음료수}

}

#region 헤더툴팁양식
/*
[Header("")]
[Tooltip("")]
[SerializeField]
*/
#endregion


#region 더미코드

/*
    [Header("등급별 스탯 테이블")]
    [Tooltip("스탯 상승 테이블임")]
    [SerializeField]
    [Range(0,3)]
    private int selectIndex;
    
    private int[] eidibleStat = { -100, 10, 50, 100 };
    public int EidibleStat { get { return eidibleStat[selectIndex]; } }
    */

#endregion