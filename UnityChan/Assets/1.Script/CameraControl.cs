using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    
    void Update()
    {
        //���� �巡�׷� ī�޶� �̵�
        if(Input.GetMouseButton(0))
        {
            //Debug.Log("���콺 ���� Ŭ��" + Input.mousePosition);
            Camera.main.transform.Translate(
                Input.GetAxis("Mouse X") / 10,
                Input.GetAxis("Mouse Y") / 10,
                0);

        }

    }
}
