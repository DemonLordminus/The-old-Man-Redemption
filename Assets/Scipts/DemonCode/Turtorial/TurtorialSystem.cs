using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UIElements;
using UnityEngine.UI;

namespace tur
{
    public class TurtorialSystem : MonoBehaviour
    {
        public PlayerControlForTurtorial control;
        public float speedUpRate;
        public GameObject player;
        public GameObject HideBlock;
        public List<Transform> playerStop;
        public GameObject TurtorialText;
        public Vector3 showUpTextPos;
        public GameObject cam;
        public GameObject UIobj;
        public TextIntro[] textIn;
        public Transform playShowSwitch;
        public GameObject barManager;
        public Transform letterGive;
        public GetItem letter;
        public Transform GiveCitao;
        public GameObject tragger;
        public Button sendButton;
        public string nextLevel;
        [Serializable]
        public class TextIntro
        {
            public GameObject introText;
            //public Transform textTrigger;
            public GameObject scenceText;
            public Vector3 pos;
        }
        // Start is called before the first frame update
        void Start()
        {
            barManager.SetActive(false);
            UIobj.SetActive(true);
            InvokeRepeating("blockBecomeSmall", 0.5f, 0.01f);
            //sendButton.onClick.AddListener(endButtonCheck);
        }
        void blockBecomeSmall()
        {
            HideBlock.transform.localScale -= new Vector3(0.02f, 0.02f, 0);
            if (HideBlock.transform.localScale.x < 0.01f)
            {
                Destroy(HideBlock);
                CancelInvoke();
                playerShowUp();
            }
        }
        private bool showUp = false;
        private void playerShowUp()
        {
            control.forcePalse = false;
            showUp = true;
            control.RunSpeed *= 2;
        }
        private bool backgroundintro = false;
        private void backGroundintro()
        {
            backgroundintro = true;
            control.forcePalse = false;
        }
        private void continueMove()
        {
            control.forcePalse = false;
        }
        // Update is called once per frame
        private bool isSpeedUp, isBack;
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            { SceneManager.LoadScene(nextLevel); }
            if (showUp)
            {
                if (player.transform.position.x >= playerStop[0].position.x)
                {
                    showUp = false;
                    control.forcePalse = true;
                    cam.GetComponent<CinemachineBrain>().enabled = true;
                    control.RunSpeed /= 2;
                    Invoke("backGroundintro", 3f);
                    playerStop[0].gameObject.SetActive(false);
                }
                TurtorialText.transform.position = new Vector3(player.transform.position.x, 0, 0) + showUpTextPos;
            }
            else
            if (backgroundintro)
            {
                foreach (Transform tr in playerStop)
                {
                    if (tr.gameObject.activeInHierarchy)
                    {
                        if (player.transform.position.x >= tr.position.x)
                        {
                            control.forcePalse = true;
                            tr.gameObject.SetActive(false);
                            Invoke("continueMove", 3f);
                        }
                    }
                }

                if (player.transform.position.x >= playShowSwitch.position.x)
                {
                    barManager.SetActive(true);
                    control.spEnable = true;
                }
                if (player.transform.position.x >= letterGive.position.x && letterGive.gameObject.activeInHierarchy)
                {
                    control.bagCanUse = true;
                    //control.AddNewItem(letter);
                    letterGive.gameObject.SetActive(false);
                }
                if (player.transform.position.x >= GiveCitao.position.x && GiveCitao.gameObject.activeInHierarchy)
                {
                    GiveCitao.gameObject.SetActive(false);
                    //control.forcePalse=true;
                    foreach(ScrObjcitiao c in citiaos)
                    {
                        CreateNewcitiao(c);
                    }
                }
            }
            #region 左右键
            if (Input.GetKeyDown(KeyCode.LeftShift) && !isSpeedUp)
            {
                control.RunSpeed *= speedUpRate;
                control.WalkSpeed *= speedUpRate;
                isSpeedUp = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift) && isSpeedUp)
            {
                control.WalkSpeed /= speedUpRate;
                control.RunSpeed /= speedUpRate;
                isSpeedUp = false;
            }

            if (Input.GetKeyDown(KeyCode.Space) && !isBack)
            {
                isBack = true;
                control.RunSpeed = -control.RunSpeed;
                control.WalkSpeed = -control.WalkSpeed;
            }
            if (Input.GetKeyUp(KeyCode.Space) && isBack)
            {
                isBack = false;
                control.RunSpeed = -control.RunSpeed;
                control.WalkSpeed = -control.WalkSpeed;
            }
            #endregion
            foreach (TextIntro text in textIn)
            {
                if (text != null && text.introText != null)
                {
                    text.introText.transform.position = Camera.main.WorldToScreenPoint(text.scenceText.transform.position + text.pos);

                }

            }
        }



        public void endButtonCheck()
        {
            //Debug.Log("触发");
            string[] nowCitiao = new string[2];

            for (int i = 0; i < tragger.transform.parent.childCount - 1; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    try
                    {

                        if (tragger.transform.GetChild(i).GetChild(j).GetChild(0)!= null)
                        {
                            var tmp = tragger.transform.GetChild(i).GetChild(j).GetChild(0).GetComponent<citiao>();
                            nowCitiao[i] += tmp.GetComponent<citiao>().citiaoScrObj.Content;
                        }
                    }
                    catch
                    { }
                }
            }
            bool flag = false;
            UnityEngine.Debug.Log(nowCitiao[0]);
            UnityEngine.Debug.Log(nowCitiao[1]);
            if (nowCitiao[0] == "前方是好的" || nowCitiao[1] == "前方是好的")
            {
                if (nowCitiao[1]=="继续前进" || nowCitiao[0] == "继续前进")
                {
                    SceneManager.LoadScene(nextLevel);
                }
            }
        }

        [Header("生成词条用")]
        public Inventory inventory;
        public GameObject Grid;
        public citiao citiaoPrefab;
        public ScrObjcitiao[] citiaos;

        public void CreateNewcitiao(ScrObjcitiao getcitiao)
        {
            //在在网格的位置生成一个词条预制件
            citiao newcitiao = Instantiate(citiaoPrefab, Grid.transform.position, Quaternion.identity);
            newcitiao.gameObject.transform.SetParent(Grid.transform);
            newcitiao.citiaoScrObj = getcitiao;
            newcitiao.textShow.text = getcitiao.Content;
            //int r = UnityEngine.Random.Range(0, getcitiao.Image.Length);
            //newcitiao.image = getcitiao.Image[r];

        }
    }
}