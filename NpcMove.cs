using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMove : MonoBehaviour
{
    public GameManager manager;

    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer;
    public int nextMove;

    public Transform pos;
    public Vector2 boxSize;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Invoke("Think", 3); //Think()를 1초 뒤에 호출
    }

    void FixedUpdate()
    {
        //Move
        rigid.velocity =  new Vector2(nextMove, rigid.velocity.y);

        //Platform Check
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove * 0.3f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));
        if (rayHit.collider == null)
            Turn();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Object"))
        {
            //Debug.Log("충돌");
            Turn();
        }
    }

    private void OntriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Object"))
        {
            Debug.Log("충돌");
            Turn();
        }
    }

    void Think()
    {
        //Set Next Move
        nextMove = manager.isAction ? 0 : Random.Range(-1, 2);  //대화 중일때는 멈추도록

        //Animation
        anim.SetInteger("walkSpeed", nextMove);

        //Flip Sprite
        if (nextMove != 0) //가만히 서 있을 때는 방향을 바꿀 필요가 없음
            spriteRenderer.flipX = nextMove == -1;

        //Recursive
        float nextThinkTime = Random.Range(1f, 3f);
        Invoke("Think", nextThinkTime);

    }

    void Turn() //턴 할 때 플립X가 바뀌도록
    {
        nextMove *= -1;
        spriteRenderer.flipX = nextMove == -1;

        CancelInvoke();
        Invoke("Think", 2);
        //StartCoroutine(WaitCoroutine());
    }
}
