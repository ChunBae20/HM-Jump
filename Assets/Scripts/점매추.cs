using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 점매추 : MonoBehaviour
{
    void Start()
    {
        Debug.Log("오늘 메뉴는?");
        JumMaeChoo();
        
    }

    void JumMaeChoo()
    {
        string OfferedWords = "밀웜 민트초코케이크 김치 정어리요구르트 마라두유 내장탕밀크티 두리안불닭 고추장카스테라 미역국바닐라라떼 치즈팝콘굴젓 피클딸기요거트 짜장면아이스크림 동태찌개초코바 굴회딸기잼 홍어마시멜로 연어젤리장 초코케익순대국 밥에요구르트 불닭떡볶이푸딩 청국장밀크쉐이크 불곱창딸기시럽 감자튀김된장 휘핑크림카레 껌된장찌개 바나나김 냉면초코시럽 마늘쫑생크림 매운탕블루베리 콩자반와플 육회젤리 피클카레 케찹된장 미숫가루김치 우유쏘야 번데기아포가토 게장커피 밥풀이쨈 해물탕푸딩 젓갈마카롱 간장치즈케익 대창초콜릿소스 족발스무디 사이다김치전 도토리묵누텔라";

	

        string[] SepOfferedWords = OfferedWords.Split(' ', StringSplitOptions.RemoveEmptyEntries); 

        System.Random random = new System.Random();
        int count = random.Next(3, 5);

        string result = "";
        for (int i = 0; i < count; i++)
        {
            int index = random.Next(SepOfferedWords.Length);
            result += SepOfferedWords[index] + " ";
        }

        Debug.Log(result.Trim()+" 이닷!");
    }
}
