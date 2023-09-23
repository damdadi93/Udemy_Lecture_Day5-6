using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewSystem : MonoBehaviour
{
    public GameObject obj_Janken; 
    public GameObject obj_Goo;
    public GameObject obj_Choki;
    public GameObject obj_Par;

    public AudioClip voiceStart;
    public AudioClip voicePon;
    public AudioClip voiceGoo;
    public AudioClip voiceChoki;
    public AudioClip voicePar;
    public AudioClip voiceWin;
    public AudioClip voiceLoose;
    public AudioClip voiceDraw;

    public Animator animator;
    public AudioSource univoice;

    private bool isWait;
    private float waitDelay;

    private int myHand;
    private int unityHand;
    private int flagResult;
    private int[,] tableResult = new int[3, 3];

    const int JANKEN = -1;
    const int GOO = 0;
    const int CHOKI = 1;
    const int PAR = 2;
    const int DRAW = 3;
    const int WIN = 4;
    const int LOOSE = 5;

    public void Start()
    {
        tableResult[GOO, GOO] = DRAW;
        tableResult[GOO, CHOKI] = WIN;
        tableResult[GOO, PAR] = LOOSE;
        tableResult[CHOKI, GOO] = LOOSE;
        tableResult[CHOKI, CHOKI] = DRAW;
        tableResult[CHOKI, PAR] = WIN;
        tableResult[PAR, GOO] = WIN;
        tableResult[PAR, CHOKI] = LOOSE;
        tableResult[PAR, PAR] = DRAW;

        isWait = false;
        waitDelay = 0;
    }

    public void Update()
    {
        if (isWait)
        {
            waitDelay += Time.deltaTime;
            if (waitDelay > 1.5f)
            {
                WinorLoose();
                waitDelay = 0;
                isWait = false;
            }
        }
    }


    private void U_Action()
    {
        flagResult = JANKEN; //r기본값 세팅
        unityHand = Random.Range(GOO, PAR + 1);
        UnityChanAction(unityHand);

        isWait = true;

        flagResult = tableResult[unityHand, myHand];
    }


    private void UnityChanAction(int action)
    {
        switch (action)
        {
            case JANKEN:
                animator.SetBool("Janken", true);
                univoice.clip = voiceStart;
                break;

            case GOO:
                animator.SetBool("Goo", true);
                univoice.clip = voiceGoo;
                break;

            case CHOKI:
                animator.SetBool("Choki", true);
                univoice.clip = voiceChoki;
                break;

            case PAR:
                animator.SetBool("Par", true);
                univoice.clip = voicePar;
                break;

            case DRAW:
                animator.SetBool("Aiko", true);
                animator.SetBool("Janken", false);
                univoice.clip = voiceDraw;
                break;

            case WIN:
                animator.SetBool("Win", true);
                animator.SetBool("Janken", false);
                univoice.clip = voiceWin;
                break;

            case LOOSE:
                animator.SetBool("Loose", true);
                animator.SetBool("Janken", false);
                univoice.clip = voiceLoose;
                break;
        }
        univoice.Play();
    }

    private void WinorLoose()
    {
        flagResult = tableResult[unityHand, myHand];
        UnityChanAction(flagResult);

        obj_Janken.SetActive(true);
    }


    public void OnClickJanken()
    {
        myHand = JANKEN;
        obj_Janken.SetActive(false);
        obj_Goo.SetActive(true);
        obj_Choki.SetActive(true);
        obj_Par.SetActive(true);
        U_Action();

        animator.SetBool("Janken", false);
        animator.SetBool("Aiko", false);
        animator.SetBool("Goo", false);
        animator.SetBool("Choki", false);
        animator.SetBool("Par", false);
        animator.SetBool("Win", false);
        animator.SetBool("Loose", false);

        UnityChanAction(JANKEN);
    }

    public void OnClickGoo()
    {
        myHand = GOO;
        obj_Goo.SetActive(false);
        obj_Choki.SetActive(false);
        obj_Par.SetActive(false);
        U_Action();
    }

    public void OnClickChoki()
    {
        myHand = CHOKI;
        obj_Goo.SetActive(false);
        obj_Choki.SetActive(false);
        obj_Par.SetActive(false);
        U_Action();
    }

    public void OnClickPar()
    {
        myHand = PAR;
        obj_Goo.SetActive(false);
        obj_Choki.SetActive(false);
        obj_Par.SetActive(false);
        U_Action();
    }
}
