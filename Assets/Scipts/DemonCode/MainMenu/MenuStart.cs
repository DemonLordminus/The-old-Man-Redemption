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
    [Header("标题界面")]
    public GameObject title;
    public Vector3 titleMoveSpped;
    public float titleMoveFrqunce;
    [Header("火漆")]
    public GameObject StartButton;
    public GameObject StartButtonText;
    [Tooltip("火漆移动到的目标位置")]
    public Transform StartButtonPos;
    public float waitTimeForStartButton;
    [Header("信封打开")]
    public GameObject closeLetter;
    public GameObject openLetter;
    public float waitTimeForLetterOpen;
    [Header("信封移动")]
    public GameObject LetterALL;
    public GameObject LetterPaper;
    public Vector3 LetterMoveSpped;
    public float LetterMoveFrqunce;
    [Header("信纸摊开")]
    public GameObject LetterPaperContent;
    public float waitTimeForPaperContentOpen;
    public GameObject LetterPaperFront1;
    public GameObject LetterPaperFront2;
    public string nextLevel;
    [Header("相机缩小")]
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
        UnityEngine.ScreenCapture.CaptureScreenshot(Application.dataPath + "/fileName01.png");//截图并保存截图文件
        Debug.Log("截取了一张图片}");

#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();//刷新Unity的资产目录
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
