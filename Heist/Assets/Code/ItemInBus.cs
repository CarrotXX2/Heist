using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInBus : MonoBehaviour
{
    public float money;
    public PickUp pickupSC;
    public int inventory;
    public bool full = false;

    void Start()
    {
        LoadMoney();
    }

    void Update()
    {
        if (inventory <= 0)
        {
            full = true;
        }
        print(inventory);
        print("Current Money: " + money);
        SaveMoney();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickable") && !full)
        {
            ObjectVal script = other.gameObject.GetComponent<ObjectVal>();
            if (script != null && pickupSC.dropped)
            {
                money += script.MoneyWorth;
                SaveMoney();
                Debug.Log("Money added: " + script.MoneyWorth);
                Destroy(other.gameObject);
                inventory -= 1;
            }
        }
    }

    public void BusUp()
    {
        inventory += 5;
        SaveMoney();
    }

    public void SaveMoney()
    {
        PlayerPrefs.SetFloat("PlayerMoney", money);
        PlayerPrefs.Save();
    }

    public void LoadMoney()
    {
        if (PlayerPrefs.HasKey("PlayerMoney"))
        {
            money = PlayerPrefs.GetFloat("PlayerMoney");
        }
    }
}
