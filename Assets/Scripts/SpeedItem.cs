using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : ItemBlueprint
{
    [SerializeField]
    protected GameObject speedParticle;


    protected override void ExecuteFunction()
    {
        PC.moveSpeed = 10f;
        Debug.Log("스피드 빨리짐");
        showParticle();
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
}
