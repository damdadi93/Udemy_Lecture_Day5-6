using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Touch : MonoBehaviour
{
    public AudioClip voice1;
    public AudioClip voice2;
    Animator animator;
    AudioSource univoice;

    public New_MsgDisp _msgDisp;

    //모션 스테이트의 ID 얻기
    int motionIdol = Animator.StringToHash("Base Layer.Idol");

    //public DateCheck dateCheck = new DateCheck();


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
        univoice = GetComponent<AudioSource>();
        //dateCheck = GetComponent<DateCheck>();
        //dateCheck.Date_Check();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Touch", false);
        animator.SetBool("TouchHead", false);

        //재생 중인 동작이 대기 동작인지 검사
        if (animator.GetCurrentAnimatorStateInfo(0).fullPathHash == motionIdol)
        {
            animator.SetBool("Motion_Idle", true);
        }
        else
            animator.SetBool("Motion_Idle", false);

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);

            //if (Physics.Raycast(ray, out hit, 100))
            //{
            //    GameObject hitObj = hit.collider.gameObject;

            //    Debug.Log("hit!");
            //    animator.SetBool("Touch", true);
            //    univoice.clip = voice2;
            //    univoice.Play();
                
            //}

            if(Physics.Raycast(ray,out hit,100))
            {
                

                GameObject hitObj = hit.collider.gameObject;
                if (hitObj.tag == "Head")
                {
                    animator.SetBool("TouchHead", true);
                    animator.SetBool("Face_Happy", true);
                    animator.SetBool("Face_Angry", false);
                    univoice.clip = voice1;
                    univoice.Play();
                    _msgDisp.ShowMessage("안녕! \n오늘도 힘차게 시작해보자!");
                }
                else if (hitObj.tag == "Body")
                {
                    animator.SetBool("Touch", true);
                    animator.SetBool("Face_Happy", false);
                    animator.SetBool("Face_Angry", true);
                    univoice.clip = voice2;
                    univoice.Play();

                    _msgDisp.ShowMessage("깍 변태!!");
                }
                else if(hitObj.tag == "Arm")
                {
                    
                    //string birth;
                    System.DateTime system_Time = System.DateTime.Now;
                    
                    _msgDisp.ShowMessage("오늘은 " + system_Time.Month + "월 " + system_Time.Day + "일 " + system_Time.Hour + " 시" + system_Time.Minute + "분 입니다.");





                }
                                   
            }
        }
    }
}
