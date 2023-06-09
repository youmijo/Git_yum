using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BtnType : MonoBehaviour
{
    public BTNType currentType;
    public GameManager manager;

    public void OnBtnClick()
    {
        switch(currentType)
        {
            case BTNType.New:
                SceneLoad.LoadSceneHandle("Play", 0);
                //SceneManager.LoadScene("Loading");
                break;
            case BTNType.Continue:
                SceneLoad.LoadSceneHandle("Play", 1);
                manager.GameLoad();
                break;
            case BTNType.Exit:
                Application.Quit();
                break;
        }
    }

}
