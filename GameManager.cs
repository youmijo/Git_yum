using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public QuestManager questManager;
    public Animator talkPanel;
    public Image portraitImg;
    public TypeEffect talk;
    public Text questText;
    public GameObject player;
    public GameObject menuSet;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;

    public Image[] HpImage;
    public GameObject GameOverSet;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GameLoad();
        
        questText.text = questManager.CheckQuest();
        Debug.Log(questManager.CheckQuest());
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
                menuSet.SetActive(false);
            else
                menuSet.SetActive(true);
        }
    }

    public void Action(GameObject scanObj)
    {
        //Get Current Object
        scanObject = scanObj;
        ObjectData objData = scanObject.GetComponent<ObjectData>();
        Talk(objData.id, objData.isNpc);

        //Visible Talk for Action    
        talkPanel.SetBool("isShow", isAction);
    }

    void Talk(int id, bool isNpc)
    {
        //Set Talk Data
        int questTalkIndex = 0;
        string talkData = "";

        if (talk.isAnim)
        {
            talk.SetMsg("");
            return;
        }
        else
        {
            questTalkIndex = questManager.GetQuestTalkIndex(id);
            talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex); //QuestTalkIndex + NPC Id = QuestData Id
        }

        //End Talk
        if(talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            questText.text = questManager.CheckQuest(id);
            return; //void함수에서 return은 강제 종료 역할
        }

        //Continue Talk
        if (isNpc)
        {
            talk.SetMsg(talkData.Split(':')[0]);

            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1, 1, 1, 1);
        }
        else
        {
            talk.SetMsg(talkData);

            portraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
    }

    public void UpdateHpImg(int Hp)
    {
        for (int index = 0; index < 5; index++)
        {
            HpImage[index].color = new Color(1, 1, 1, 0);
        }

        for (int index = 0; index < Hp; index++)
        {
            HpImage[index].color = new Color(1, 1, 1, 1);
        }
    }

    public void GameOver()
    {
        audioSource.Play();
        GameOverSet.SetActive(true);
        player.SetActive(false);
    }

    public void GameRetry()
    {
        GameOverSet.SetActive(false);
        player.SetActive(true);
        GameLoad();
    }

    public void GameSave()
    {
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetFloat("QuestId", questManager.questId);
        PlayerPrefs.SetFloat("QuestActionIndex", questManager.questActionIndex);
        PlayerPrefs.Save();

        menuSet.SetActive(false);
    }

    public void GameLoad()
    {
        if (PlayerPrefs.HasKey("PlayerX"))
            return;

        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        int questId = PlayerPrefs.GetInt("QuestId");
        int questActionIndex = PlayerPrefs.GetInt("QuestActionIndex");

        player.transform.position = new Vector3(x-6.8f, y-3, 0);
        questManager.questId = questId;
        questManager.questActionIndex = questActionIndex;
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
