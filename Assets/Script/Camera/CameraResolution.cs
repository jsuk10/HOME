using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//카메라의 뷰포트 조절해주는 함수
public class CameraResolution : MonoBehaviour
{
    //카메라의 비율을 조절해주는 함수.
    void Start()
    {
        SetCameraView();
    }

    void SetCameraView()
    {
        Camera camera = GetComponent<Camera>();
        Rect rect = camera.rect;
        //비율 계산
        float scaleheight = ((float)Screen.width / Screen.height) / ((float)16 / 9);
        //얼마나 차이 나는지 계산
        float scalewidth = 1f / scaleheight;
        //스테일에 맞게 조절하기
        if (scaleheight < 1)
        {
            rect.height = scaleheight;
            rect.y = (1f - scaleheight) / 2f;
        }
        else
        {
            rect.width = scalewidth;
            rect.x = (1f - scalewidth) / 2f;
        }
        //변경값 적용
        camera.rect = rect;
    }
}