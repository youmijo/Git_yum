using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroGameManager : MonoBehaviour
{
    public IntroTalkManager talkManager;
    public Animator talkPanel;
    public Image portraitImg;
    public TypeEffect talk;

    public int talkIndex;

    void Talk(int id, bool isNpc)
    {
        //Set Talk Data
        string talkData = "";

        if (talk.isAnim)
        {
            talk.SetMsg("");
            return;
        }

        //End Talk
        if (talkData == null)
        {
            talkIndex = 0;
            return; //void함수에서 return은 강제 종료 역할
        }

        //Continue Talk
        talk.SetMsg(talkData.Split(':')[0]);
        portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
        portraitImg.color = new Color(1, 1, 1, 1);
  
        talkIndex++;
    }
}
