using Cinemachine;
using Dmld;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
//背包中物品的使用，拖拽到主角上生效
public class ItemOnDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //声明起始组类
    public Transform originalParent;
    public GetItem GetItem;

    public int count1 = 0;
    public float kangshengsu = 5;
    public float swyl;//食物饮料的回复量
    public PlayerController playerController;
    public TextMeshProUGUI TextMeshProUGUI;
    public CinemachineVirtualCamera virtualCamera;//这里的对象还需设置
    private void Start()
    {
        TextMeshProUGUI = DataManager.instance.item;
        playerController = DataManager.instance.controller;
        GetItem = this.gameObject.GetComponent<Item>().itemname;
    }
    //鼠标点击触发
    public void OnBeginDrag(PointerEventData eventData)
    {
        TextMeshProUGUI.text = GetItem.infomation;
        //起始所属赋值
        originalParent = transform.parent;
        //跳出所属画布
        //transform.SetParent(transform.parent.parent);
        //跟随鼠标移动
        transform.position = eventData.position;
        //修改这个类的属性，阻止物理射线穿透
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    //鼠标松开拖拽触发
    public void OnEndDrag(PointerEventData eventData)
    {
        TextMeshProUGUI.text = "";
        Vector3 vector = Input.mousePosition - gameObject.transform.parent.transform.position;
        Debug.Log(vector.x);
        int delta = (int)vector.x;
        try
        {
            if (delta<0)//这个代码获取鼠标射线现在碰撞的物体的图层     //citiao调换位置
            {
                //使拖拽对象归到鼠标当前位置的框中
                transform.position = eventData.position;
                //SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent);
                //transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
                //使原有对象返回到拖拽对象的原始位置
                //eventData.pointerCurrentRaycast.gameObject.transform.position = originalParent.position;
                //eventData.pointerCurrentRaycast.gameObject.transform.SetParent(originalParent);
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;//退出
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
    //鼠标拖拽触发
    public void OnDrag(PointerEventData eventData)
    {
        TextMeshProUGUI.text = GetItem.infomation;
        //跟随鼠标
        transform.position = eventData.position;
    }

    public virtual void ItemOnRun()
    {
        
    }
    #region 咕咕的
    /*
    void OnRun()
    {
        
        switch (GetItem.Name)
        {
            case "zhongyao"://中药的功能实现
                foreach (DebuffClass debuff in playerController.debuffs)//减少debuff持续时间
                {
                    if (debuff.keepTime > 0 && debuff.DebuffOrder < 10)
                    {
                        count1 = 1;
                        debuff.keepTime -= 5;
                    }
                }
                if (playerController.CurrentHealthy < playerController.MaxHealthy * 0.75)//加血
                {
                    playerController.ChangeHealth(20); count1 += 1;
                }
                if (playerController.CurrentBp < playerController.MaxBp * 0.75)//加体力
                {
                    playerController.ChangeBP(20); count1 += 1;
                }
                if (playerController.CurrentBp < playerController.MaxBp * 0.75)//加幸福度
                {
                    playerController.debuffs[10].keepTime = 10;
                    playerController.debuffs[10].isEnable = true;
                    count1 += 1;
                }
                playerController.MaxHealthy += (4 - count1) * 5;//加血量上限
                *//*（阻挡病魔效果的语句）*//*
                break;
            case "jieduji"://解毒药的功能实现
                playerController.ChangeHealth(5);
                playerController.debuffs[0].keepTime -= 10;
                break;
            case "yanjiu"://烟酒的功能实现
                playerController.ChangeHealth(-5);
                playerController.ChangeBP(10);
                *//*（获得烟酒成瘾生活习惯的语句）*//*
                break;
            case "tuishaoyao"://退烧药的功能实现
                playerController.ChangeHealth(5);
                playerController.debuffs[1].keepTime -= 3;
                break;
            case "nlyl"://能量饮料的功能实现
                playerController.nlylcot += 1;
                playerController.debuffs[11].isEnable = true;
                playerController.debuffs[11].keepTime = 10;
                break;
            case "weiyao"://胃药的功能实现
                playerController.debuffs[3].keepTime -= 3;
                playerController.ChangeHealth(5);
                break;
            case "shuji"://书籍的功能实现
                playerController.ChangeBP(10);
                *//*（增加识破黑心元素的语句）*//*
                playerController.debuffs[13].isEnable = true;
                break;
            case "kangshengsu"://抗生素的功能实现
                *//*（提升下一次对抗病魔时不被感染的成功率的语句）*//*
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
            case "yanyaoshui"://眼药水的功能实现
                virtualCamera.m_Lens.OrthographicSize = Mathf.Clamp(virtualCamera.m_Lens.OrthographicSize + 1, 2, 5);
                playerController.debuffs[15].isEnable = true;
                playerController.debuffs[15].keepTime = 10;
                playerController.debuffs[9].keepTime -= 5;
                break;
            case "swyl"://食物饮料的功能实现
                playerController.ChangeSp(swyl);
                break;
            case "jsyw"://精神药物的功能实现
                playerController.debuffs[5].keepTime -= 5;
                playerController.debuffs[7].keepTime -= 5;
                playerController.debuffs[8].keepTime -= 5;
                playerController.debuffs[6].keepTime -= 5;
                playerController.ChangeBP(10 * (Random.Range(0, 2)) * 2 - 1);
                break;
            case "yangqiping"://氧气瓶的功能实现
                playerController.debuffs[4].keepTime -= 3;
                playerController.debuffs[12].isEnable = true;
                playerController.debuffs[12].keepTime = 10;
                playerController.ChangeSp(20);
                break;
            case "zhitongyao"://止痛药的功能实现
                playerController.ChangeHealth(20);
                playerController.debuffs[16].isEnable = true;
                playerController.debuffs[16].keepTime = 10;
                break;
            case "baojianpin"://保健品的功能实现
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
        return;//退出
    }*/
    #endregion
}
