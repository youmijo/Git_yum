using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public GameManager manager;
    public float maxSpeed;
    public float jumpPower;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    AudioSource audioSource;

    private float curTime;
    public float coolTime = 0.5f;
    public Transform pos;
    public Vector2 boxSize;
    GameObject scanObject;
    Vector3 dirVec;
    float h;

    public int Hp = 5;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Move Value, 상태변수를 사용하여 움직임을 제한
        h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");

        //Check Button Down & Up
        bool hDown = manager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool hUp = manager.isAction ? false : Input.GetButtonUp("Horizontal");

        //Jump
        if (Input.GetKeyDown(KeyCode.LeftAlt) && !anim.GetBool("isJumping"))
        {
            audioSource.Play();
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }

        //stop speed
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        //Direction Sprite
        if (Input.GetButtonDown("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        //Animation
        if (Mathf.Abs(rigid.velocity.x) < 0.3)  //절댓값
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);

        if (curTime <= 0)
        {
            //Z를 공격키로 설정
            if (Input.GetKey(KeyCode.Z))
            {
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
                foreach (Collider2D collider in collider2Ds)
                {
                    if (collider.CompareTag("Monster"))
                        {
                        collider.GetComponent<MonsterMove>().TakeDamage(1);
                    }
                }

                anim.SetTrigger("atk");
                curTime = coolTime;
            }
        }
        else
        {
            curTime -= Time.deltaTime;
        }

        //Direction
        if (hDown && h == 1)    //right
            dirVec = Vector3.right;
        else if (hDown && h == -1) //left
            dirVec = Vector3.left;

        //Scan Object
        if (Input.GetKeyDown(KeyCode.Space) && scanObject != null)
        {
            manager.Action(scanObject);
        }
    }

    void FixedUpdate()
    {
        //Move Speed
        float h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        // Max Speed
        if (rigid.velocity.x > maxSpeed)    //right
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed * (-1)) //left
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);

        //Landing Platform 바닥이 있는지 없는지를 검사
        if (rigid.velocity.y < 0)   //내려가는 속도 일 때만 Ray를 사용
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
            if (rayHit.collider != null) //빔을 쏴서 맞은 사물이 있으면 정보가 있다
            {
                if (rayHit.distance < 0.5f)
                    anim.SetBool("isJumping", false);
            }
        }

        //Scan Object(Ray)
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit2 = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));
        if (rayHit2.collider != null) //빔을 쏴서 맞은 사물이 있으면 정보가 있다
        {
            scanObject = rayHit2.collider.gameObject;
        }
        else
            scanObject = null;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            OnDamaged(collision.transform.position);    //무적상태
            Hp--;
            manager.UpdateHpImg(Hp);
            if(Hp == 0)
                {
                    manager.GameOver();
                Hp = 5;
                manager.UpdateHpImg(Hp);
            }
            
        }
    }

    //무적 상태 해제
    void OffDamaged()
    {
        gameObject.layer = 10;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    void OnDamaged(Vector2 targetPos)
    {
        //Change Layer
        gameObject.layer = 11; //PlayerDamaged layer num

        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        //Reaction
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dirc, 1) * 8, ForceMode2D.Impulse);

        //Animation
        anim.SetTrigger("doDamaged");
        Invoke("OffDamaged", 1.5f);
    }

    //public void TakeDamage(int damage)
    //{
    //    Hp -= damage;

    //}
}