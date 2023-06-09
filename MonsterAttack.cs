using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform pos; //총알의 생성 위치
    public Vector2 boxSize;

    public float coolTime;
    private float curTime;

    public float distance; //레이로 감지할 거리
    public float atkDistance;
    public LayerMask isLayer; //탐색할 레이어
    public float speed;


    void Start()
    {

    }

    //void Update()
    //{
    //    //if (curTime <= 0)
    //    //{
    //    //    Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
    //    //    foreach (Collider2D collider in collider2Ds)
    //    //    {
    //    //        if (collider.CompareTag("Player"))
    //    //        {
    //    //            Instantiate(bullet, pos.position, transform.rotation);
    //    //            collider.GetComponent<PlayerMove>().TakeDamage(1);
    //    //        }
    //    //        curTime = coolTime;
    //    //    }
    //    //}
    //    //curTime -= Time.deltaTime;
    //}

    void FixedUpdate()
    {
        RaycastHit2D left = Physics2D.Raycast(transform.position, transform.right * -1, distance, isLayer);
        RaycastHit2D right = Physics2D.Raycast(transform.position, transform.right, distance, isLayer);
        if (left.collider != null)
        {
            if (left.collider.tag == "Player")
            {
                if (Vector2.Distance(transform.position, left.collider.transform.position) < atkDistance)
                {
                    if (curTime <= 0)
                    {
                        GameObject bulletcopy = Instantiate(bullet, transform.position, transform.rotation);
                        curTime = coolTime;
                    }
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, left.collider.transform.position, Time.deltaTime * speed);
                }
                curTime -= Time.deltaTime;
            }
        }

        if (right.collider != null)
        {
            if (right.collider.tag == "Player")
            {
                if (Vector2.Distance(transform.position, right.collider.transform.position) < atkDistance)
                {
                    if (curTime <= 0)
                    {
                        GameObject bulletcopy = Instantiate(bullet, transform.position, transform.rotation);
                        bulletcopy.transform.rotation = Quaternion.Euler(0, 0, 180);
                        curTime = coolTime;
                    }
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, right.collider.transform.position, Time.deltaTime * speed);
                }
                curTime -= Time.deltaTime;
            }
        }

        //// 플레이어가 가까이 다가오면 따라가기
        //RaycastHit2D raycast = Physics2D.Raycast(transform.position, transform.right * -1, distance, isLayer);
        ////Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
        //foreach (Collider2D collider in collider2Ds)
        //{
        //    if (Vector2.Distance(transform.position, raycast.collider.transform.position) < atkDistance)
        //    {
        //        if (curTime <= 0)
        //        {
        //            GameObject bulletcopy = Instantiate(bullet, transform.position, transform.rotation);
        //            curTime = coolTime;
        //        }
        //    }
        //    else
        //    {
        //        transform.position = Vector3.MoveTowards(transform.position, raycast.collider.transform.position, Time.deltaTime * speed);
        //    }
        //    curTime -= Time.deltaTime;
        //}

        //    Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
        //    foreach (Collider2D collider in collider2Ds)
        //    {
        //        for (int i = 0; i < collider2Ds.Length; i++)
        //        {
        //            if (collider2Ds[i].tag == "Player")
        //            {
        //                if (curTime <= 0)
        //                {
        //                    Instantiate(bullet, pos.position, transform.rotation);
        //                    collider.GetComponent<PlayerMove>().TakeDamage(1);
        //                    curTime = coolTime;
        //                }
        //                curTime -= Time.deltaTime;
        //            }
        //        }
        //    }
        //}

        //private void OnDrawGizmos()
        //{
        //    Gizmos.color = Color.blue;
        //    Gizmos.DrawWireCube(pos.position, boxSize);
        //}
    }
}
