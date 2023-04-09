using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class director : MonoBehaviour
{
    public int[] answer = new int[4] { -1, -1, -1, -1 };   //입력받을 비밀번호를 저장할 배열
    int[] realanswer = new int[4] { 2, 1, 3, 0 };   //원래 비밀번호 정답


    public int count = 0;
    int point = 0;
    GameObject iinteraction;
    GameObject interaction1;
    GameObject interaction2;
    GameObject interation3;
    public Camera a;

    // Start is called before the first frame update
    void Start()
    {
        a.enabled = true;
        iinteraction = GameObject.Find("iinteraction");
         interaction1 = GameObject.Find("interaction1");
         interaction2 = GameObject.Find("interaction2");
         interation3 = GameObject.Find("interation3");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(count);
        if (count == 4)   //네개의 비밀번호를 입력받으면 일치하는 비밀번호인지 확인하는 코드
        {
            Debug.Log("full");
            for (int i = 0; i < 4; i++)
            {
                if (answer[i] != realanswer[i])
                {
                    SceneManager.LoadScene("retry");
                    break;
                }
            }
        }
        if (point ==4)
            SceneManager.LoadScene("EndScene");

    }

    
}
