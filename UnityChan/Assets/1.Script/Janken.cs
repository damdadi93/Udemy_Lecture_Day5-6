using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Janken : MonoBehaviour
{
    bool flagJanken = false;        //묵찌빠 시작 플래그
    int modeJanken = 0;

    public AudioClip voiceStart;
    public AudioClip voicePon;
    public AudioClip voiceGoo;
    public AudioClip voiceChoki;
    public AudioClip voicePar;
    public AudioClip voiceWin;
    public AudioClip voiceLoose;
    public AudioClip voiceDraw;

    const int JANKEN = -1;
    const int GOO = 0;
    const int CHOKI = 1;
    const int PAR = 2;
    const int DRAW = 3;
    const int WIN = 4;
    const int LOOSE = 5;
    

    Animator animator;
    AudioSource univoice;

    int myHand;
    int unityHand;
    int flagResult;
    int[,] tableResult = new int[3, 3];

    float waitDelay;

    public GameObject startBtn;
    public GameObject jankenBtn;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        univoice = GetComponent<AudioSource>();
      

        //결과 테이블 미리 결정 [유니티짱,플레이어]
        tableResult[GOO, GOO] = DRAW;
        tableResult[GOO, CHOKI] = WIN;
        tableResult[GOO, PAR] = LOOSE;
        tableResult[CHOKI, GOO] = LOOSE;
        tableResult[CHOKI, CHOKI] = DRAW;
        tableResult[CHOKI, PAR] = WIN;
        tableResult[PAR, GOO] = WIN;
        tableResult[PAR, CHOKI] = LOOSE;
        tableResult[PAR, PAR] = DRAW;

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(guiBtnGame);
        //묵찌빠 상태이면
        uiActive();

        if (flagJanken)
        {
            //게임 모드에 따라
            switch(modeJanken)
            {
                case 0: //묵찌빠 시작
                      UnityChanAction(JANKEN);
                      modeJanken++;
                    break;

                case 1: //플레이어 입력대기
                    //애니메이션 초기화
                    animator.SetBool("Janken", false);
                    animator.SetBool("Aiko", false);
                    animator.SetBool("Goo", false);
                    animator.SetBool("Choki", false);
                    animator.SetBool("Par", false);
                    animator.SetBool("Win", false);
                    animator.SetBool("Loose", false);


                    break;

                case 2: //판정
                    flagResult = JANKEN;
                    // 유니티짱의 손을 무작위로 선택
                    unityHand = Random.Range(GOO, PAR + 1);
                    // 유니티짱 액션
                    UnityChanAction(unityHand);
                    // 결과
                    flagResult = tableResult[unityHand, myHand];
                    modeJanken++;
                    break;

                case 3: //결과
                    //약간의 시간 간격
                    waitDelay += Time.deltaTime;
                    if(waitDelay > 1.5f)
                    {
                        //유니티짱 결과 액션
                        UnityChanAction(flagResult);

                        waitDelay = 0;
                        modeJanken++;
                    }
                    break;

                default: //게임 끝내고
                    flagJanken = false;
                    modeJanken = 0;
                    //초기화
                    break;
            }
        }
    }

    void UnityChanAction(int act) //이벤트 함수
    {
        switch(act)
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
                univoice.clip = voiceDraw;
                break;

            case WIN:
                animator.SetBool("Win", true);
                univoice.clip = voiceWin;
                break;

            case LOOSE:
                animator.SetBool("Loose", true);
                univoice.clip = voiceLoose;
                break;

        }
        univoice.Play();
    }

    public void OnClick()
    {
        flagJanken = true;        //묵찌빠 시작 플래그
        modeJanken = 0;
       
    }
        
    public void OnGoo()
    {
        myHand = GOO;
        modeJanken++;
    }

    public void OnChoki()
    {
        myHand = CHOKI;
        modeJanken++;
    }

    public void OnPar()
    {
        myHand = PAR;
        modeJanken++;
    }

   public void uiActive()
   {

        //묵찌빠가 아니면
        if (!flagJanken)
        {
            startBtn.gameObject.SetActive(true);
           
        }
        else
            startBtn.gameObject.SetActive(false);

        //묵찌빠 모드
        if (modeJanken == 1)
        {
            startBtn.gameObject.SetActive(false);
            jankenBtn.gameObject.SetActive(true);

        }
        else
            jankenBtn.gameObject.SetActive(false);


    }

}
