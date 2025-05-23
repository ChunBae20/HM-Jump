using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOvercheck : MonoBehaviour
{
    public Image h;

    public GameObject player;

    [SerializeField]
    private GameObject assginHImage;
    public GameObject AssginHImage { get { return assginHImage; } }

    public int MaxHeart = 3;
    public int CurHeart;
    public Image[] Heart;

    public bool isGameOver = false;

    void Start()
    {

        Heart = assginHImage.GetComponentsInChildren<Image>(true); // 지금 게임실행하면 배열에 인덱스 할당 된 상태임 ㅇㅋ?

    }

    void Update()
    {
        CheckingGameOver();
    }

    void CheckingGameOver()
    {
        if (player.transform.position.y < -16f)
        {
            CurHeart = MaxHeart -= 1;

            
            //CurHeart>0이거만하면 2개까지만 까지고 더이상 안줄어들음
            //그리고 vecto3.zero하니까 첫번째떨어지고 스폰되는 위치는 제대로 되는데 두번째부터는 바닥에 끼여서 안움직임그러면 첫번째 떨어질때부터 껴야하는거아닌가? 왜이럼?
            //일단 이건 나중에 찾아보자 지금당장은 고쳤으니까
            if(CurHeart>=0 &&CurHeart< Heart.Length)
            {

                Heart[CurHeart].gameObject.SetActive(false);

            }
            player.transform.position = new Vector3(0,3,0);

        }
    }


    
}


#region 과정

//단일이미지가져올땐 GetComponentsInChildren 여러개 가져올때 GetComponentsInChildrens

//leftOneH, leftTwoH, leftThreeH 가 각각의 하트이미지이다 이거는 스트링으로 저장해야하나? 아 이럴때 var나 dynamic을 쓰는건가?이거를 하고 나중에 반드시 var에서 어떤타입을 지정해주는지 해보자
//아니 var이거 지역변수밖에 못씀? 레전드네 이딴거 왜씀? 이럴거면 나도 타입 알지 아 진짜 var hear[]해보고 왜안됐나했네

//3칸? 아니 이거 재사용성이 안되는데 내가 이렇게 지정하면나중에 또 바꿔야하잖아 하트늘릴때는 어떡할건데
//resource처럼 끌어오는 방법없나? find키워드 잘쓰면 될거같기도한데

//배열로 각각의  하트 1,2,3저장하고 하나씩 셋액티브 끄는게 구현이 가능할까?
//이거 나지금 이미지 하나를 끌어다쓰는건데 그냥 resource 폴더 하나 만들고 이미지 세개만들고 참조해올까?

/*
for(int i = 0; i < Heart.Length; i++)
            {

                Heart[i].gameObject.SetActive(false);

            }
*/
#endregion