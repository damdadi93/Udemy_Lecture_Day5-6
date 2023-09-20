using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    
    void Update()
    {
        //왼쪽 드래그로 카메라 이동
        if(Input.GetMouseButton(0))
        {
            //Debug.Log("마우스 왼쪽 클릭" + Input.mousePosition);
            Camera.main.transform.Translate(
                Input.GetAxis("Mouse X") / 10,
                Input.GetAxis("Mouse Y") / 10,
                0);

        }

    }
}
