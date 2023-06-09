using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum BottonType
{
    New,
    Continue,
    Exit
}

public class MainUI : MonoBehaviour
{ 
    public void PlayBtn()
    {
        SceneManager.LoadScene("Loading");
    }
}
