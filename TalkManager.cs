using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
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
        //default Talk
        talkData.Add(1000, new string[] { "마을을 위한 일이야.:1"});
        talkData.Add(2000, new string[] { "뭔가 허전한 마음이 들어요..:1" });
        talkData.Add(8000, new string[] { "집나가면 고생이랬어요.:1"});
        talkData.Add(3000, new string[] { "항상 열심히 연구하고 있답니다.:1"});
        talkData.Add(4000, new string[] { "빨리 금요일 저녁이 됐으면 좋겠어.:1"});
        talkData.Add(5000, new string[] { "대회가 얼마 안남았는데..:1"});
        talkData.Add(6000, new string[] { "멍멍!:1"});

        //Quest Talk
        talkData.Add(10 + 1000, new string[] { "오, 왔구나!:1", "네, 이상한 몬스터들은 어디있어요?:0", "아 그건 이제 걱정할 것 없다! 몬스터도 같이 살아가면 되는거지 허허!:1", "(..도와달라고 하셨으면서 갑자기 왜이러시지? 아무래도 이상하다. 마을을 살펴보자.):0", "(먼저 마을 가운데 포탈을 이용해서 버스 정류장으로 가 보자.):0" });
        talkData.Add(20 + 100, new string[] { "마을에 정말 몬스터가 돌아다닌다.:0", "위험하니 이 수상해보이는 물건만 주워서 빨리 돌아가자!:0", "마을의 연구원에게 가져가면 뭐라도 알 수 있지 않을까?:0" });
        talkData.Add(21 + 3000, new string[] { "오, 외부에서 오신 분이군요!:1", "들고 있는 물건은 뭐죠?:1", "버스 정류장쪽에 갔다가 몬스터 근처에서 주웠어요.:0", "안 그래도 갑자기 나타난 몬스터들과 이상해진 마을 사람들에 대해서 연구하고 있던 중이었습니다.:1", "들고 있는 건 저에게 주고, 잠시 옆에 있는 강아지 좀 돌봐주세요.:1"});
        talkData.Add(30 + 6000, new string[] {"끼잉..:1", "(강아지가 기운이 없어 보인다. 간식을 주면 좋아하겠지..?):0","멍.....:1", "(....별로 안좋아하는 것 같다.):0" });
        talkData.Add(31 + 3000, new string[] {"오셨군요. 제가 알아 본 것들을 모두 알려드리도록 하죠.:1","이 이상하게 생긴 물건에 '감정'이 들어있는 것 같아요!:1", "아무래도 마을 사람들이 이상해진 것과 큰 연관이 있는 것 같군요.:1", "그러고 보니, 아까 본 몬스터는 근심걱정이 가득한 모습이었어요!:0", "이 감정이 담긴 마음을 마을사람들에게 다시 돌려줘야 할텐데, 도움이 필요한 마을 사람들을 도와주시겠어요?:1", "당연하죠. 일단 강아지한테도 기쁜 감정이 사라진 것 같으니, 먼저 도와줘야겠어요.:0", "기쁨에 가득 찬 몬스터라면 마을 왼쪽 끝 포탈을 타고 산책로1로 가보세요.:1", "참고로 'M'을 누르면 맵을 확인할 수 있답니다.:1" });
        talkData.Add(40 + 200, new string[] {"(아까 주웠던거랑 비슷하게 생긴걸 보니 이게 기쁜 마음인 것 같다.):0", "(..저 앞에 어린아이가 혼자 서성이고 있는 것 같은데..?):0","(도움이 필요할 지도 모르니 한 번 가 보자.):0"});
        talkData.Add(50 + 2000, new string[] { "저기..:0", "누구세요?:1", "왜 여기 혼자 있어?:0", ".....:1","...?:0","집으로 가자! 데려다줄게.:0","됐어요. 가족같은거 없어도 상관없다구요!!:1", "(..사춘긴가..?):0", "(..가 아니라 아마 이 아이도 몬스터에게 어떤 감정을 빼앗긴 것 같다.):0", "(왼쪽 포탈을 타고 산책로2로 이동해서 마음을 찾아보자.):0" });
        talkData.Add(60 + 300, new string[] { "(몬스터들 눈에서 하트가 뿅뿅 나오는 걸 보아하니 이건 사랑하는 마음인 것 같다.):0","(가족을 사랑하는 마음이 사라져서 가출을 했나보다..):0", "(아이한테 전달 해 주고, 다시 연구원에게 돌아가자!):0" });
        talkData.Add(61 + 2000, new string[] { "어..이거 맛있는 젤리인데 한 번 먹어봐!!:0","(꿀꺽):1",".........:1","어..? 부모님이 기다리실텐데 왜 여기 나와있지? 빨리 들어가봐야겠다!!:1" });
        talkData.Add(70 + 3000, new string[] {"오 이게 기쁜 마음이군요!:1", "강아지에게는 제가 전달하도록 하죠. 이장님도 감정을 되찾으셨어요.:1","이렇게 한 명씩 도와주다 보면 마을이 다시 예전의 모습으로 돌아갈 수 있을 것 같네요. :1","미로상사 부장님도 무언가로 굉장히 스트레스 받고 있는 것 같더라고요. 가서 도와주시겠어요?:1", "마을 왼쪽편에 안경을 쓰고 계신 분이에요.:1" });
        talkData.Add(80 + 4000, new string[] { "으.. 이러다가 내 머리가 다 빠지겠어.:1", " 왜그러세요??:0", "사원이 큰 실수를 해서 한 마디 해줬어야 했는데.. 모르겠어 내가 너무 답답해!!:1", "(흠.. 아무래도 화나는 감정을 잃은 것 같다.):0", "(안 가본 시내 쪽으로 한 번 가봐야겠다!):0" });
        talkData.Add(90 + 400, new string[] { "(휴.. 몬스터들 피하기 힘들었다. 몬스터들이 너무 화가 나 있어..!!):0", "(이게 화난마음이구나. 어서 다시 조심히 돌아가자.):0" });
        talkData.Add(91 + 4000, new string[] { "부장님, 이거 드시고 힘내세요.:0", "이게 뭔가...? 젤리같이 생겼네? (꿀꺽):1", "........(긴장):0","이...런 조카신발같은 귀여운 시바스키가 #@4!%!$1#@$..!!!.. :1","(도망가자..!):0", "(근처에 있는 사람에게 말을 걸어보자.):0" });
        talkData.Add(100 + 5000, new string[] { "오 헤드셋 멋진데, 혹시 게임 좋아해?:0", "최근에 팀에 들어가서 프로게이머로 활동하게 됐어.:1","오, 잘됐다!:0", "근데 꼭 이기는게 행복한 걸까? 그냥 팀원들과 함께 게임을 즐겼으면 된 거 아닐까..? :1", "그래도 프로가 대회에서 이기는 걸 목표로 해야지!!:0", "글쎄..난 잘 모르겠다.:1", "(안되겠다.. 또 마음을 찾으러 가야겠어.):0", "(아까 갔던 시내를 지나서 더 들어가보자.):0"});
        talkData.Add(110 + 500, new string[] { "(겨우 왔다 ..다시 돌아갈 생각을 하니 벌써 신이 나는군^^..):0", " (욕심 가득한 마음을 가지고 프로게이머에게 돌아가자.):0" });
        talkData.Add(111 + 5000, new string[] { "(꿀꺽):1", "(기대):0", "..그런데 산으로 가는 길쪽에서 이상한 소리가 나던데:1", "(갑자기?):0", "한 번 가보는게 어때?:1", "그..래 알려줘서 고마워!:0", "(그래. 감정을 되찾아도 꼭 겉으로 티가 나는 건 아니니까..):0", "(찝찝하지만 말해준 대로 산으로 가는 길쪽에 한 번 가 보자.):0"});
        talkData.Add(120 + 7000, new string[] { "(우걱우걱):1", "뭐야..? 귀여운 햄스터잖아:0", "나한테 무슨 볼 일 있어?:1", "(말을 한다...?):0", "나는 사람들의 감정을 나눠먹으면서 사는 햄스터야.:1", "그럼 이 몬스터들도 너 때문에 생긴거야?:0", "마을 사람들이 몬스터한테 감정을 하나씩 빼앗기고 있다고 이 나쁜 햄스터야!:0", "엇..나는 적당히 배만 채우고 가려고 했는데, 요즘 살이 쪘나?:1", "미안.. 이만 다른 마을로 이동 해 볼게.:1", "........?:0", "(뭐야, 뭐이렇게 착해? 아무튼 해결 된 건가.):0" });
        talkData.Add(130 + 3000, new string[] { "덕분에 마을이 예전 모습으로 돌아왔어요!!:1", "아니에요. 별로 한 것도 없는데(머쓱):0", "아무튼 도와주셔서 감사합니다.:1" });
   
        //0:플레이어 초상화, 1:npc초상화
        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(2000 + 0, portraitArr[0]);
        portraitData.Add(2000 + 1, portraitArr[2]);
        portraitData.Add(8000 + 1, portraitArr[2]);
        portraitData.Add(3000 + 0, portraitArr[0]);
        portraitData.Add(3000 + 1, portraitArr[3]);
        portraitData.Add(4000 + 0, portraitArr[0]);
        portraitData.Add(4000 + 1, portraitArr[4]);
        portraitData.Add(5000 + 0, portraitArr[0]);
        portraitData.Add(5000 + 1, portraitArr[5]);
        portraitData.Add(6000 + 0, portraitArr[0]);
        portraitData.Add(6000 + 1, portraitArr[6]);
        portraitData.Add(7000 + 0, portraitArr[0]);
        portraitData.Add(7000 + 1, portraitArr[7]);
        portraitData.Add(100 + 0, portraitArr[0]);
        portraitData.Add(200 + 0, portraitArr[0]);
        portraitData.Add(300 + 0, portraitArr[0]);
        portraitData.Add(400 + 0, portraitArr[0]);
        portraitData.Add(500 + 0, portraitArr[0]);
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10))
                return GetTalk(id - id % 100, talkIndex);  //Get First Talk
            else
                return GetTalk(id - id % 10, talkIndex);   //Get First Quest Talk
        }

        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
