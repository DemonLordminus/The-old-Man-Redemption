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
        [Header("�̳���")]
        public bool spEnable;
        public bool forcePalse;
        [Header("��ʽ����Ҫ�޸ĵĵط�")]
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
        public float RestToSp;//��Ϣ�ָ�����sp����
        public float RunSpeed;
        public float WalkSpeed;

        [Header("������")]

        #region  �ƶ�
        //�����ٶȱ���
        public bool isPalse;
        Animator animator;
        public float maxspeed;
        public float currentspeed;
        public bool isRun;
        public float reSp;
        public int nlylcot;
        //�������Զ���
        Rigidbody2D Rigidbody2D;
        //���������
        //int x;
        //��ʱ��
        float Timer;
        //����λ��
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
            //�ֱ��ȡ��Ϸ����

            //��ȡ����
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            OpenMyBag();
        }
        //��ʼ���ٶ�
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
                    //�л��ٶȣ�ʹ����������С��10%���ܱ��ܣ��ܲ�������������·��Ϣ�ָ�����
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
                //��ʱ��
                //Timer -= Time.fixedDeltaTime;
                //if (Timer <= 0)
                //{
                //    //��ʼ��
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
        //�ƶ�
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
            //��ȡ��ǰ��������λ��
            Vector2 position = transform.position;
            position.x = position.x + currentspeed * i * Time.fixedDeltaTime;
            Rigidbody2D.position = position;
            animator.SetFloat("MoveX", currentspeed);
        }

        #region ��ֵϵͳ
        public float MaxHealthy;
        public float CurrentHealthy;
        public float MaxSp;
        public float CurrentSp;
        public float MaxBp;//�Ҹ�ֵ
        public float CurrentBp;
        public float Gold;
        public float CurrentTime;//������

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
        //0=�ж�
        //1=����
        //2=����
        //3=Ż�¸�к
        //4=��������
        //5=����
        //6=����
        //7=����
        //8=����
        //9=äĿ

        public CinemachineVirtualCamera virtualCamera;
        public DebuffClass[] debuffs;

        [HideInInspector]
        public const int maxDebuffNum = 17;//���֢����

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
                        if (debuff.DebuffOrder == 11)//����������ؼ��
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
        #region �л�UI
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
        #region ��ײ
        public bool IsTrue;
        //public bool Isrun;
        public string whatEnemy;
        public List<GetItem> ItemsPackage;
        public int eventCountPerformed;//�������¼���
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

        #region ��ȡ
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