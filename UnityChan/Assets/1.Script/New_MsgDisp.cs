using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class New_MsgDisp : MonoBehaviour
{
    public string msg;
    public bool flagDisplay = false;
    public GUIStyle guiDisplay;
    public  int msgLen;
    public  float waitDelay;
    public TextMeshProUGUI _text;

    public GameObject obj_Image;

    private float nextTime = 0;
    //private Rect rect_Display = new Rect();


    public void ShowMessage(string _msg)
    {
        obj_Image.SetActive(true);
        _text.text = _msg.ToString();
        flagDisplay = true;
        msgLen = 0;
        waitDelay = 0;
    }

    private void Update()
    {
        if (flagDisplay)
        {
            if (msgLen < msg.Length)
            {
                if (Time.time > nextTime)
                {
                    msgLen++;
                    nextTime = Time.time + 0.02f;
                }
            }
            else
            {
                waitDelay += Time.deltaTime;
                if (waitDelay > 1 + msg.Length / 4)
                    obj_Image.SetActive (false);
            }
        }
    }
}
