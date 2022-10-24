using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngineInternal;

public class MenuStart : MonoBehaviour
{
    public Camera camCamera;
    [Header("�������")]
    public GameObject title;
    public Vector3 titleMoveSpped;
    public float titleMoveFrqunce;
    [Header("����")]
    public GameObject StartButton;
    public GameObject StartButtonText;
    [Tooltip("�����ƶ�����Ŀ��λ��")]
    public Transform StartButtonPos;
    public float waitTimeForStartButton;
    [Header("�ŷ��")]
    public GameObject closeLetter;
    public GameObject openLetter;
    public float waitTimeForLetterOpen;
    [Header("�ŷ��ƶ�")]
    public GameObject LetterALL;
    public GameObject LetterPaper;
    public Vector3 LetterMoveSpped;
    public float LetterMoveFrqunce;
    [Header("��ֽ̯��")]
    public GameObject LetterPaperContent;
    public float waitTimeForPaperContentOpen;
    public GameObject LetterPaperFront1;
    public GameObject LetterPaperFront2;
    public string nextLevel;
    [Header("�����С")]
    public float camSizeReduce;
    public float camSizeFrequnce;
    public float camMinSize;
    public Transform camTargetPos;
    public float camMovePower;
    public float camMoveMinDis;
    public Button enterButton;
    public GameObject enterText;
    public void GameStart()
    {
        InvokeRepeating("titleMove",0, titleMoveFrqunce);
        Invoke("StartButtonMove", waitTimeForStartButton);
    }

    private void titleMove()
    {
        title.transform.Translate(titleMoveSpped);
        if(!IsCameraVisible(camCamera,title))
        {
            title.SetActive(false);
            CancelInvoke();
            InvokeRepeating("LetterMove", 0, LetterMoveFrqunce);
        }
    }

    private void StartButtonMove()
    {
        StartButton.transform.position = StartButtonPos.position;
        StartButtonText.SetActive(false);
        StartButton.transform.SetParent(StartButton.transform.parent.parent);
        Invoke("LetterOpen", waitTimeForLetterOpen);
        Destroy(StartButton.GetComponent<Button>());
        Destroy(StartButton.GetComponent<MouseEnterBecomeBigger>());
    }
    private void LetterOpen()
    {
        closeLetter.SetActive(false);
        openLetter.SetActive(true);
        
    }
    private void LetterMove()
    {
        LetterPaper.transform.Translate(-LetterMoveSpped);
        LetterALL.transform.Translate(LetterMoveSpped);
        if (!IsCameraVisible(camCamera, LetterALL))
        {
            LetterPaper.transform.SetParent(LetterPaper.transform.parent.parent);
            CancelInvoke();
            Invoke("LetterPaperOpen1", waitTimeForPaperContentOpen);
        }
    }
    private void LetterPaperOpen1()
    {
        LetterPaperFront1.SetActive(false);
        LetterPaperFront2.SetActive(true);
        Invoke("LetterPaperOpen2", waitTimeForPaperContentOpen);
    }
    private void LetterPaperOpen2()
    {
        LetterPaperContent.SetActive(true);
        LetterPaperContent.transform.SetParent(LetterPaperContent.transform.parent.parent);
        LetterPaper.SetActive(false);
    }
    public void cameraFocusSwitch()
    {
        Destroy(enterButton);
        enterText.SetActive(false);
        InvokeRepeating("camReduce", 0, camSizeFrequnce);
    }
    private void camReduce()
    {
        Vector3 moveDir = camTargetPos.position - camCamera.transform.position;
        if (moveDir.magnitude > camMoveMinDis)
        {
            camCamera.transform.Translate(camMovePower * moveDir.normalized);
        }
        if ((camCamera.orthographicSize -= camSizeReduce)<=camMinSize)
        {
            CancelInvoke();
            Invoke("goTonextLeveL", 0.5f);
            //goTonextLeveL();
        }
          
    }


    [EditorButton]
    public void ScreenShotFile()
    {
        UnityEngine.ScreenCapture.CaptureScreenshot(Application.dataPath + "/fileName01.png");//��ͼ�������ͼ�ļ�
        Debug.Log("��ȡ��һ��ͼƬ}");

#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();//ˢ��Unity���ʲ�Ŀ¼
#endif
    }

    public void goTonextLeveL()
    {
        SceneManager.LoadScene(nextLevel);

    }

    private bool IsCameraVisible(Camera testCamera, GameObject testGo)
    {
        Vector3 viewPos = testCamera.WorldToViewportPoint(testGo.transform.position);
        if (viewPos.x > -0.2 && viewPos.x < 1.2)
        {
            if (viewPos.y > -0.2 && viewPos.y < 1.2)
            {
                if (viewPos.z >= testCamera.nearClipPlane && viewPos.z <= testCamera.farClipPlane)
                {
                    return true;
                }
            }
        }
        return false;
    }

}
