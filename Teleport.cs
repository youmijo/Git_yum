using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject targetObj;
    public GameObject toObj;
    public MapName mn;

    AudioSource audioSource;

    public int mapNum;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OntriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            targetObj = collision.gameObject;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartCoroutine(TeleportRoutine());
            audioSource.Play();
            //Debug.Log(mapNum);
            mn.ChangeMapName(mapNum);
        }
    }

    IEnumerator TeleportRoutine()
    {
        yield return null;
        targetObj.transform.position = toObj.transform.position;
        Camera.main.GetComponent<MoveCamera>().ChangeLimit(mapNum);
    }

}
