using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GetMedicine : MonoBehaviour
{
    public GetItem GetItem;
    public Package Package;
    public void AddNewItem()
    {
        if (!Package.Items.Contains(GetItem))
        {
            Package.Items.Add(GetItem);
        }
        else
        {
            GetItem.Num += 1;
        }
        PackageManager.RefreshItem();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            AddNewItem();
            Destroy(this.gameObject);
            Destroy(this.transform.parent.gameObject);
        }
    }

    private void Start()
    {
        Package.Items.Clear();
    }
}
