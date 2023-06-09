using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapUI : MonoBehaviour
{
    public GameObject MapPanel;
    bool activeMap = false;

    private void Start()
    {
        MapPanel.SetActive(activeMap);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            activeMap = !activeMap;
            MapPanel.SetActive(activeMap);
        }
    }
}
