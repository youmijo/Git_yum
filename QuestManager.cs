using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    public GameObject[] questObject;
    Dictionary<int, QuestData> questList;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        questList.Add(10, new QuestData("이장님과 대화하기"
                                        , new int[] { 1000 }));
        questList.Add(20, new QuestData("버스 정류장으로 가기"
                                        , new int[] { 100, 3000 }));
        questList.Add(30, new QuestData("강아지 살펴보기"
                                        , new int[] { 6000, 3000 }));
        questList.Add(40, new QuestData("기쁜 마음 가지러 가기"
                                         , new int[] { 200 }));
        questList.Add(50, new QuestData("가출 소년 도와주기"
                                       , new int[] { 2000 }));
        questList.Add(60, new QuestData("'사랑하는 마음' 찾아 가출 소년에게 전해주기"
                                      , new int[] { 300, 2000}));
        questList.Add(70, new QuestData("연구원에게 기쁜 마음 전해주기"
                                      , new int[] { 3000 }));
        questList.Add(80, new QuestData("미로 상사 부장님 도와주기"
                                       , new int[] { 4000 }));
        questList.Add(90, new QuestData("부장님에게 화난 마음 가져다 주기"
                                         , new int[] { 400, 4000 }));
        questList.Add(100, new QuestData("프로게이머 도와주기"
                                         , new int[] { 5000 }));
        questList.Add(110, new QuestData("프로게이머에게 욕심 가득한 마음 가져다 주기"
                                      , new int[] { 500, 5000 }));
        questList.Add(120, new QuestData("산으로 가는 길 살펴보기"
                                      , new int[] { 7000 }));
          questList.Add(130, new QuestData("연구원의 감사 인사"
                                      , new int[] { 7000 }));
    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;  //퀘스트 번호 + 퀘스트 대화순서 = 퀘스트 대화 id
    }

    public string CheckQuest(int id)
    {
        if (id == questList[questId].npcId[questActionIndex])
            questActionIndex++;

        ControlObject();

        if (questActionIndex == questList[questId].npcId.Length) //퀘스트 대화 순서가  끝에 도달했을 때 퀘스트 번호 증가
            NextQuest();

        return questList[questId].questName;
    }

    public string CheckQuest()
    {
        //Quest Name
        return questList[questId].questName;
    }

    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    void ControlObject()
    {
        switch(questId) //걱정스러운 마음
        {
            case 10:    //10은 퀘스트번호 (퀘스트1)
                if (questActionIndex == 1)  // 퀘스트1에 연관되어있는 npc 1명하고 대화를 다 나눴을때
                    questObject[0].SetActive(true); //퀘스트 오브젝트를 보이도록
                break;
            case 20:    //다음 퀘스트번호 (퀘스트2)로 넘어가면
                if (questActionIndex == 1) 
                    questObject[0].SetActive(false);    //안보이게
                break;
        }

        switch (questId) //행복한 마음
        {
            case 30:   
                if (questActionIndex == 2)  
                    questObject[1].SetActive(true); 
                break;
            case 40:   
                if (questActionIndex == 1)
                    questObject[1].SetActive(false);
                break;
        }

        switch (questId) //사랑하는 마음 마음
        {
            case 50:
                if (questActionIndex == 1)
                    questObject[2].SetActive(true);
                break;
            case 60:
                if (questActionIndex == 1)
                    questObject[2].SetActive(false);
                break;
        }

        switch (questId) //가출 소년
        {
            //case 0:
            //    if (questActionIndex == 1)
            //        questObject[5].SetActive(true);
            //    break;
            case 60:
                if (questActionIndex == 2)
                {
                    questObject[5].SetActive(false);
                    questObject[6].SetActive(true);
                }
                break;
        }

        //switch (questId) //가출 소년(마을)
        //{
        //    case 60:
        //        if (questActionIndex == 2)
        //            questObject[6].SetActive(true);
        //        break;
        //    //case 70:
        //    //    if (questActionIndex == 1)
        //    //        questObject[5].SetActive(false);
        //    //    break;
        //}

        switch (questId) //화난 마음
        {
            case 80:
                if (questActionIndex == 1)
                    questObject[3].SetActive(true);
                break;
            case 90:
                if (questActionIndex == 1)
                    questObject[3].SetActive(false);
                break;
        }

        switch (questId) //욕심 가득한 마음
        {
            case 100:
                if (questActionIndex == 1)
                    questObject[4].SetActive(true);
                break;
            case 110:
                if (questActionIndex == 1)
                    questObject[4].SetActive(false);
                break;
        }

        switch (questId) //햄스터
        {
            case 120:
                if (questActionIndex == 1)
                    questObject[7].SetActive(false);
                break;
        }
    }
}
