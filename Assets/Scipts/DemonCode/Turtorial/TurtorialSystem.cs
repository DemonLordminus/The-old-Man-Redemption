using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements;

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
            UIobj.SetActive(true);
            InvokeRepeating("blockBecomeSmall", 0.5f, 0.01f);
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
            }
            #region ×óÓÒ¼ü
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
    }
}