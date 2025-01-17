using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInBus : MonoBehaviour
{
    public float money;
    public PickUp pickupSC;
    public int inventory;
    public int currentInv;
    public bool full = false;
    public AudioClip inInventory;

    void Start()
    {
        LoadMoney();
        LoadInv();
        currentInv = inventory;
    }

    void Update()
    {
        print(inventory);
        if (currentInv <= 0)
        {
            full = true;
        }
        print(inventory);
        print("Current Money: " + money);
        SaveMoney();
        SaveInv();
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
                currentInv -= 1;
                AudioSource.PlayClipAtPoint(inInventory, gameObject.transform.position);
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
    public void SaveInv()
    {
        PlayerPrefs.SetInt("CurrentInv", inventory);
        PlayerPrefs.Save();
    }
    public void LoadInv()
    {
        if (PlayerPrefs.HasKey("CurrentInv"))
        {
            inventory = PlayerPrefs.GetInt("CurrentInv");
        }
    }

}
