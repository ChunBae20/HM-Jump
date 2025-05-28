using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : ItemBlueprint
{
    [SerializeField]
    protected GameObject speedParticle;


    protected override void ExecuteFunction()
    {
        PC.moveSpeed += 8f;
        Debug.Log("5초간 빨리짐 시작 ");
        showParticle();
        StartCoroutine( FiveSec());
        Debug.Log("5초간 빨리짐 종료");

    }

    protected override void Start()
    {
        base.Start();
        // 신기하네 이거 여기서 스타트쓰려니까 자동으로 입력해주네 유니티제공키워드
        //부모클래스의 스타트도 같이 실행
        speedParticle = Resources.Load<GameObject>("SpeedParticle");
    }
    void showParticle()
    {
        GameObject showPref = Instantiate(speedParticle, transform.position, Quaternion.identity);
        showPref.GetComponent<ParticleSystem>().Play();
    }

    IEnumerator FiveSec()
    {
        yield return new WaitForSeconds(5f);
        PC.moveSpeed -= 8f;
    }

}
