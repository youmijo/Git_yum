using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public float distance;
    public LayerMask isLayer;

    void Start()
    {
        Invoke("DestroyBullet", 2);
    }

    void Update()
    {
        RaycastHit2D right = Physics2D.Raycast(transform.position, transform.right, distance, isLayer);
        if (right.collider != null)
        {
            if (right.collider.tag == "Player")
            {
                Debug.Log("attacked!");
            }
            DestroyBullet();
        }

        RaycastHit2D left = Physics2D.Raycast(transform.position, transform.right * -1, distance, isLayer);
        if (left.collider != null)
        {
        
            if (left.collider.tag == "Player")
            {
                Debug.Log("attacked!");
            }
            DestroyBullet();
        }

        if (transform.rotation.y == 0)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);     //오른쪽으로 발사
        }
        else
        {
            transform.Translate(Vector2.right * -1f * speed * Time.deltaTime); //왼쪽으로 발사
        }
    }
    
    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}

