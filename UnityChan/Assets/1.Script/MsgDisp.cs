using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MsgDisp : MonoBehaviour
{
    public static string msg;
    public static int month;
    public static int day;

    public static bool flagDisplay = false;
    public GUIStyle guiDisplay;
    public static int msgLen;
    public static float waitDelay;

    private float nextTime = 0;
    private Rect rtDisplay = new Rect();

    // OnGUI는 GUI 이벤트를 렌더링 및 처리하기 위해 호출됩니다.
    private void OnGUI()
    {
        // GUI 크기: 16:9의 1280 x 720 해상도 기준
        const float guiScreen = 1280;
        const float guiWidth = 800; // 800x200 픽셀의 메세지창
        const float guiHeight = 200;
        const float guiLeft = (guiScreen - guiWidth) / 2; // 가운데
        const float guiTop = 720 - guiHeight - 20; // 하단
                                                   // 현재 화면과의 비율
        float gui_scale = Screen.width / guiScreen;

        if(flagDisplay)
        {
            GUIStyle msgFont = new GUIStyle
            {
                fontSize = (int)(30 * gui_scale)
            };
           
            rtDisplay.x = guiLeft * gui_scale;
            rtDisplay.y = guiTop * gui_scale;
            rtDisplay.width = guiWidth * gui_scale;
            rtDisplay.height = guiHeight * gui_scale;
            GUI.Box(rtDisplay,msg.Substring(0,msgLen), guiDisplay);

            msgFont.normal.textColor = Color.white;
            rtDisplay.x = (guiLeft + 22) * gui_scale;
            rtDisplay.y = (guiTop + 22) * gui_scale;
            GUI.Label(rtDisplay, msg.Substring(0, msgLen), msgFont);

        }

    }

    //외부에서 메세지 받기
    public static void ShowMessage(string msg)
    {
        MsgDisp.msg = msg;
        flagDisplay = true;
        msgLen = 0;
        waitDelay = 0;
    }
    public static void DateMessage(int month, string msg1,int day, string msg2)
    {
        MsgDisp.msg = msg1;
        MsgDisp.msg = msg2;
        DateCheck.nowMonth = month;
        DateCheck.nowDay = day;
        flagDisplay = true;
        msgLen = 0;
        waitDelay = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(flagDisplay)
        {
            if(msgLen < msg.Length)
            {
                if(Time.time > nextTime)
                {
                    msgLen++;
                    nextTime = Time.time + 0.02f;
                }
               
                
            }
            else
            {
                waitDelay += Time.deltaTime;
                if (waitDelay > 1 + msg.Length / 4)
                {
                    flagDisplay = false;
                }
            }

        }
    }
}
