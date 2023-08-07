using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapName : MonoBehaviour
{
    public UnityEngine.UI.Text mapName;

   void Start()
    {
        ChangeMapName(0);
    }

    public void ChangeMapName(int x)
    {
        if (x == 0)
            mapName.text = "현재 위치: 미로 마을";

        else if (x == 1)
            mapName.text = "현재 위치: 버스 정류장";

        else if (x == 2)
            mapName.text = "현재 위치: 산으로 가는 길";

        else if (x == 3)
            mapName.text = "현재 위치: 마을 산책로1";

        else if (x == 4)
            mapName.text = "현재 위치: 마을 산책로2";

        else if (x == 5)
            mapName.text = "현재 위치: 시내";

        else if (x == 6)
            mapName.text = "현재 위치: 시장";
    }
}
