using System;
using UnityEngine;
using Random = UnityEngine.Random;
using Dmld;
using System.Collections;
using Cinemachine;
using System.Collections.Generic;

namespace tur
{
    public class PlayerControlForTurtorial : MonoBehaviour
    {
        [Header("教程用")]
        public bool spEnable;
        public bool forcePalse;
        [Header("正式版需要修改的地方")]
        public float RunReduceSp;
        public float WalkReduceSp;
        public float BreakRecoverSp;
        [Range(0, 100)]
        public float RunSpRange;
        [Range(0, 100)]
        public float WalkSpRange;
        [Range(0, 100)]
        public float BreakSpRange;
        [Range(0, 100)]
        public float RestToSp;//休息恢复到的sp比例
        public float RunSpeed;
        public float WalkSpeed;

        [Header("正常用")]

        #region  移动
        //声明速度变量
        public bool isPalse;
        Animator animator;
        public float maxspeed;
        public float currentspeed;
        public bool isRun;
        public float reSp;
        public int nlylcot;
        //声明刚性对象
        Rigidbody2D Rigidbody2D;
        //声明随机量
        //int x;
        //计时器
        float Timer;
        //声明位置
        private Vector2 Vector2;
        // Start is called before the first frame update
        void Start()
        {
            Initialize();
            animator = GetComponent<Animator>();
            isPalse = false;
            CurrentBp = MaxBp;
            CurrentHealthy = MaxHealthy;
            CurrentSp = MaxSp;
            currentspeed = maxspeed;
            isRun = true;
            reSp = 1;
            nlylcot = 0;
            //分别获取游戏对象

            //获取刚性
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            OpenMyBag();
        }
        //初始化速度
        void NewSpeed()
        {
            if (CurrentSp >= MaxSp / 1.01 && isRun == false)
            {
                isRun = true;
            }
        }
        public float mangmuTime;
        void FixedUpdate()
        {
            if (!isPalse && !forcePalse)
            {
                if (spEnable)
                {
                    //切换速度，使得在体力条小于10%不能奔跑，跑步消耗体力，走路休息恢复体力
                    if (CurrentSp > MaxSp * RunSpRange / 100 && isRun)
                    {
                        currentspeed = RunSpeed;
                        ChangeSp(-RunReduceSp);
                        Move(1);
                    }
                    else if (CurrentSp > MaxSp * WalkSpRange / 100 && isRun)
                    {
                        ChangeSp(-WalkReduceSp);
                        currentspeed = WalkSpeed;
                        Move(1);
                    }
                    else
                    {
                        isRun = false;
                        Move(0);
                        ChangeSp(BreakRecoverSp);
                    }
                }
                else
                {
                    Move(1);
                    currentspeed = RunSpeed;
                }
                #endregion
                //计时器
                //Timer -= Time.fixedDeltaTime;
                //if (Timer <= 0)
                //{
                //    //初始化
                //    x = Random.Range(0, 2);
                //    Timer = 1.5f;
                //    NewSpeed();
                //}
            }
            else
            {
                Move(0);
            }
        }
        //移动
        public void Move(int i)
        {
            if (i == 0)
            {
                currentspeed = 0;
                if (CurrentSp >= RestToSp || CurrentSp == MaxSp)
                {
                    isRun = true;
                }
            }
            //获取当前对象所在位置
            Vector2 position = transform.position;
            position.x = position.x + currentspeed * i * Time.fixedDeltaTime;
            Rigidbody2D.position = position;
            animator.SetFloat("MoveX", currentspeed);
        }

        #region 数值系统
        public float MaxHealthy;
        public float CurrentHealthy;
        public float MaxSp;
        public float CurrentSp;
        public float MaxBp;//幸福值
        public float CurrentBp;
        public float Gold;
        public float CurrentTime;//处理健忘

        public void ChangeHealth(float amount)
        {
            CurrentHealthy = Mathf.Clamp(CurrentHealthy + amount, 0, MaxHealthy);
            HealthyBarManager.Instance.SetValue(CurrentHealthy / (float)MaxHealthy);
            if (CurrentHealthy <= 0)
            {
                Time.timeScale = 0f;
                gameover = true;
                DataManager.instance.EndEvent.SetActive(true);
            }
        }

        public void ChangeSp(float amount)
        {
            CurrentSp = Mathf.Clamp(CurrentSp + amount, 0, MaxSp);
            SpBarManager.Instance.SetValue(CurrentSp / (float)MaxSp);
        }

        public void ChangeBP(float amount)
        {
            CurrentBp = Mathf.Clamp(CurrentBp + amount, 0, MaxBp);
            BlissBarManager.Instance.SetValue(CurrentBp / (float)MaxBp);
        }


        #endregion
        #region debuff
        //0=中毒
        //1=发热
        //2=乏力
        //3=呕吐腹泻
        //4=呼吸困难
        //5=混乱
        //6=健忘
        //7=抑郁
        //8=焦躁
        //9=盲目

        public CinemachineVirtualCamera virtualCamera;
        public DebuffClass[] debuffs;

        [HideInInspector]
        public const int maxDebuffNum = 17;//最大病症数量

        void Initialize()
        {
            debuffs = new DebuffClass[maxDebuffNum];
            for (int order = 0; order < maxDebuffNum; ++order)
            {
                debuffs[order] = new DebuffClass(order);
            }
        }
        void UpdateDebuffTime()
        {
            foreach (DebuffClass debuff in debuffs)
            {
                if (debuff.keepTime > 0)
                {
                    debuff.keepTime -= Time.fixedDeltaTime;
                    if (debuff.keepTime < 0)
                    {
                        debuff.isEnable = false;
                        debuff.keepTime = 0;
                        if (debuff.DebuffOrder == 11)//能量饮料相关检测
                        {
                            nlylcot = 0;
                            if (debuffs[2].keepTime > 0)
                            {
                                debuffs[2].isEnable = true;
                            }
                        }
                    }
                }
            }
        }
        #endregion
        #region 切换UI
        public GameObject myBar;
        public GameObject myBag;
        [HideInInspector]
        public bool bagCanUse = false;
        bool isOpean;
        void OpenMyBag()
        {
            if (!isPalse)
            {
                if ((Input.GetKeyDown(KeyCode.X) || Input.GetMouseButtonDown(1)) && bagCanUse)
                {
                    isOpean = !isOpean;
                    myBar.SetActive(isOpean);
                    myBag.SetActive(!isOpean);
                }
            }
        }
        #endregion

        public bool gameover;
        #region 碰撞
        public bool IsTrue;
        //public bool Isrun;
        public string whatEnemy;
        public List<GetItem> ItemsPackage;
        public int eventCountPerformed;//经过的事件数
        public bool IfHunluan()
        {
            if (debuffs[5].isEnable && Random.Range(1, 7) < 5)
            {
                return false;
            }
            return true;
        }
        public int num;
        void Jianwang()
        {
            DataManager.instance.lawOrActLists.lawlists.RemoveRange(((int)Random.Range(0, DataManager.instance.lawOrActLists.lawlists.Count / 3)) * 3, 3);
        }
        public bool Probability(int amount)
        {
            if (Random.Range(0, 101) < amount)
            {
                return true;
            }
            return false;
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name == "mailbox")
            {
                eventCountPerformed++;
                collision.gameObject.GetComponent<eventElmentFather>().getEventPerform(); return;
            }
            if (IfHunluan())
            {
                eventCountPerformed++;
                OnEvent(collision);
            }
            else
            {
                collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            }

        }
        void OnEvent(Collision2D collision)
        {
            if (collision.gameObject.tag == "EventElement")
            {
                if (debuffs[13].isEnable)
                {
                    collision.gameObject.GetComponent<eventElmentFather>().random += 5;
                }
                if (collision.gameObject.GetComponent<virusEvent>() != null && debuffs[14].isEnable)
                {
                    collision.gameObject.GetComponent<virusEvent>().random += 5;
                }
                collision.gameObject.GetComponent<eventElmentFather>().getEventPerform();
            }
        }
        #endregion

        #region 获取
        public void AddNewItem(GetItem item)
        {
            if (!ItemsPackage.Contains(item))
            {
                item.Num = 1;
                ItemsPackage.Add(item);

            }
            else
            {
                item.Num++;
            }
            PackageManagerForTurtorial.RefreshItem();

        }
        public void AddNewItem(GetItem[] Item)
        {
            foreach (GetItem item in Item)
            {
                if (!ItemsPackage.Contains(item))
                {
                    item.Num = 1;
                    ItemsPackage.Add(item);

                }
                else
                {
                    item.Num++;
                }
            }
            PackageManagerForTurtorial.RefreshItem();

        }
        #endregion
    }
}