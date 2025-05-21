using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

/// <summary>
/// 아이템기능은 상속받은곳에서만드세요<br/>
/// 이스크립트제공:회전 상하떨림,충돌파괴
/// </summary>
public abstract class ItemBlueprint : MonoBehaviour
{

    protected BoxCollider2D bc;

    public PlayerController PC;

    protected virtual void Start()
    {
        PC = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    //목표 이 클래스를 상속받으면,
    //일정한 속도로 회전을 갖는다.
    //플레이어가 아이템이랑 충돌하면 아이템을 부순다.
    //어차피 자식클래스에서 구현하지않으면 이스크립트는 의미 없긴함


    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("아이템을 획득");
            ExecuteFunction();

            Destroy(gameObject);
        }
    }

    protected virtual void Update()
    {

        Vector3 RotY = new Vector3(0, 30f, 0);
        transform.Rotate(RotY * Time.deltaTime);

        //매스f.핑퐁 사용법
        //Mathf.PingPong(증가하는 값(왕복주기),시작값에서 얼마까지 올릴지)+시작지점
        float moveYPos = Mathf.PingPong(Time.time*0.6f, 0.35f) + 2.5f; //2.5에서 2.85갔다가다시2.5갔다가 2.85 왕복
        transform.position = new Vector3(transform.position.x, moveYPos, transform.position.z);
    }

    protected abstract void ExecuteFunction();

}
