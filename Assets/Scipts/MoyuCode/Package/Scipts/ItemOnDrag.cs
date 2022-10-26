using Cinemachine;
using Dmld;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
//��������Ʒ��ʹ�ã���ק����������Ч
public class ItemOnDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //������ʼ����
    public Transform originalParent;
    public GetItem GetItem;

    public int count1 = 0;
    public float kangshengsu = 5;
    public float swyl;//ʳ�����ϵĻظ���
    public PlayerController playerController;
    public TextMeshProUGUI TextMeshProUGUI;
    public CinemachineVirtualCamera virtualCamera;//����Ķ���������
    private void Start()
    {
        TextMeshProUGUI = DataManager.instance.item;
        playerController = DataManager.instance.controller;
        GetItem = this.gameObject.GetComponent<Item>().itemname;
    }
    //���������
    public void OnBeginDrag(PointerEventData eventData)
    {
        TextMeshProUGUI.text = GetItem.infomation;
        //��ʼ������ֵ
        originalParent = transform.parent;
        //������������
        //transform.SetParent(transform.parent.parent);
        //��������ƶ�
        transform.position = eventData.position;
        //�޸����������ԣ���ֹ�������ߴ�͸
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    //����ɿ���ק����
    public void OnEndDrag(PointerEventData eventData)
    {
        TextMeshProUGUI.text = "";
        Vector3 vector = Input.mousePosition - gameObject.transform.parent.transform.position;
        Debug.Log(vector.x);
        int delta = (int)vector.x;
        try
        {
            if (delta<0)//��������ȡ�������������ײ�������ͼ��     //citiao����λ��
            {
                //ʹ��ק����鵽��굱ǰλ�õĿ���
                transform.position = eventData.position;
                //SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent);
                //transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
                //ʹԭ�ж��󷵻ص���ק�����ԭʼλ��
                //eventData.pointerCurrentRaycast.gameObject.transform.position = originalParent.position;
                //eventData.pointerCurrentRaycast.gameObject.transform.SetParent(originalParent);
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;//�˳�
            }
        }
        catch
        { }
        ItemOnRun();
        GetItem.Num -= 1;
        if (GetItem.Num <= 0)
        {
            DataManager.instance.controller.ItemsPackage.Remove(GetItem);
        }
        PackageManager.RefreshItem();
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        Destroy(this.gameObject);
    }
    //�����ק����
    public void OnDrag(PointerEventData eventData)
    {
        TextMeshProUGUI.text = GetItem.infomation;
        //�������
        transform.position = eventData.position;
    }

    public virtual void ItemOnRun()
    {
        
    }
    #region ������
    /*
    void OnRun()
    {
        
        switch (GetItem.Name)
        {
            case "zhongyao"://��ҩ�Ĺ���ʵ��
                foreach (DebuffClass debuff in playerController.debuffs)//����debuff����ʱ��
                {
                    if (debuff.keepTime > 0 && debuff.DebuffOrder < 10)
                    {
                        count1 = 1;
                        debuff.keepTime -= 5;
                    }
                }
                if (playerController.CurrentHealthy < playerController.MaxHealthy * 0.75)//��Ѫ
                {
                    playerController.ChangeHealth(20); count1 += 1;
                }
                if (playerController.CurrentBp < playerController.MaxBp * 0.75)//������
                {
                    playerController.ChangeBP(20); count1 += 1;
                }
                if (playerController.CurrentBp < playerController.MaxBp * 0.75)//���Ҹ���
                {
                    playerController.debuffs[10].keepTime = 10;
                    playerController.debuffs[10].isEnable = true;
                    count1 += 1;
                }
                playerController.MaxHealthy += (4 - count1) * 5;//��Ѫ������
                *//*���赲��ħЧ������䣩*//*
                break;
            case "jieduji"://�ⶾҩ�Ĺ���ʵ��
                playerController.ChangeHealth(5);
                playerController.debuffs[0].keepTime -= 10;
                break;
            case "yanjiu"://�̾ƵĹ���ʵ��
                playerController.ChangeHealth(-5);
                playerController.ChangeBP(10);
                *//*������̾Ƴ������ϰ�ߵ���䣩*//*
                break;
            case "tuishaoyao"://����ҩ�Ĺ���ʵ��
                playerController.ChangeHealth(5);
                playerController.debuffs[1].keepTime -= 3;
                break;
            case "nlyl"://�������ϵĹ���ʵ��
                playerController.nlylcot += 1;
                playerController.debuffs[11].isEnable = true;
                playerController.debuffs[11].keepTime = 10;
                break;
            case "weiyao"://θҩ�Ĺ���ʵ��
                playerController.debuffs[3].keepTime -= 3;
                playerController.ChangeHealth(5);
                break;
            case "shuji"://�鼮�Ĺ���ʵ��
                playerController.ChangeBP(10);
                *//*������ʶ�ƺ���Ԫ�ص���䣩*//*
                playerController.debuffs[13].isEnable = true;
                break;
            case "kangshengsu"://�����صĹ���ʵ��
                *//*��������һ�ζԿ���ħʱ������Ⱦ�ĳɹ��ʵ���䣩*//*
                playerController.debuffs[14].isEnable = true;
                foreach (DebuffClass debuff in playerController.debuffs)
                {
                    if (debuff.keepTime > 0)
                    {
                        debuff.keepTime -= kangshengsu;
                    }
                }
                kangshengsu *= 0.75f;
                break;
            case "yanyaoshui"://��ҩˮ�Ĺ���ʵ��
                virtualCamera.m_Lens.OrthographicSize = Mathf.Clamp(virtualCamera.m_Lens.OrthographicSize + 1, 2, 5);
                playerController.debuffs[15].isEnable = true;
                playerController.debuffs[15].keepTime = 10;
                playerController.debuffs[9].keepTime -= 5;
                break;
            case "swyl"://ʳ�����ϵĹ���ʵ��
                playerController.ChangeSp(swyl);
                break;
            case "jsyw"://����ҩ��Ĺ���ʵ��
                playerController.debuffs[5].keepTime -= 5;
                playerController.debuffs[7].keepTime -= 5;
                playerController.debuffs[8].keepTime -= 5;
                playerController.debuffs[6].keepTime -= 5;
                playerController.ChangeBP(10 * (Random.Range(0, 2)) * 2 - 1);
                break;
            case "yangqiping"://����ƿ�Ĺ���ʵ��
                playerController.debuffs[4].keepTime -= 3;
                playerController.debuffs[12].isEnable = true;
                playerController.debuffs[12].keepTime = 10;
                playerController.ChangeSp(20);
                break;
            case "zhitongyao"://ֹʹҩ�Ĺ���ʵ��
                playerController.ChangeHealth(20);
                playerController.debuffs[16].isEnable = true;
                playerController.debuffs[16].keepTime = 10;
                break;
            case "baojianpin"://����Ʒ�Ĺ���ʵ��
                playerController.ChangeHealth(10);
                playerController.ChangeSp(10);
                break;
            case "xin":
                if (!traggerManager.GetComponent<TraggerManager>().Open())
                {
                    GetItem.Num += 1;
                }; break;
            default: break;
        }
        GetItem.Num -= 1;
        if (GetItem.Num <= 0)
        {
            DataManager.instance.controller.ItemsPackage.Remove(GetItem);
        }
        PackageManager.RefreshItem();
        Destroy(this.gameObject);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        return;//�˳�
    }*/
    #endregion
}
