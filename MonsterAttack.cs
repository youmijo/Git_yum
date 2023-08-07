using System.Collections;
using System.Collections.Generic;
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
    }
}
