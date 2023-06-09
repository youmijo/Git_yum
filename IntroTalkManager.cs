using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;
    
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1, new string[] { "♪♪♪♪♪", "여보세요?:0", "나다. 잘 지내고 있니?:1", "그럼요. 무슨 일 있으세요?:0", "그게, 사실은 며칠 전부처 마을 근처에 이상한 몬스터같은게 나타나서 마을 밖으로 나가지도 못하고 있단다.:1", "엑? 몬스터요? 게임 속 세상도 아니고 그게 무슨..:0", "크흠.. 아무튼 그것들이 나타난 뒤에 마을 사람들도 하나 둘 조금씩 이상해지는 것 같고..:1", "마을 사람들은 왜요??:0", "자세한 건 와서 이야기 하자꾸나. 일단 마을로 좀 와서 도와주렴. 기다리고 있으마.:1", "(... 이장님이 말씀하신 것만 들으면 정말 큰 일이 난 것 같은데.):0", "(이런 일을 왜 나한테...?!):0" });

        //0:플레이어 초상화, 1:이장님 초상화
        portraitData.Add(1, portraitArr[0]);
        portraitData.Add(1, portraitArr[1]);
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[portraitIndex];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
        }
    }

}
