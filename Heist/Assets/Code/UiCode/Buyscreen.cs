using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Mathematics;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Buyscreen : MonoBehaviour
{
    public TMP_Text RobertBuy;
    public TMP_Text FlashBuy;
    public TMP_Text infoHolder;
    public TMP_Text carPriceText;
    public TMP_Text CurrentMoney;
    public ItemInBus itemInBus;
    public Zaklamp zaklamp;
    public float carPrice = 100;
    public float FlashPrice = 100;
    public float RoberticaPrice = 100000;
    public GameObject car;
    public GameObject FlashLight;
    public AudioClip buySound;
    public AudioClip equip;
    public AudioClip deneidSound;
    public bool Owned;
    public GameObject robertSkin;
    public GameObject roberticaSkin;
    public bool RoberticaBought;
    public bool roberticaON;
    public OpenShop pickUpSc;
    public string moneyNumber;
    public RobertticaSpawn equippedBool;
    public int hasRobertica;



    void Start()
    {
        
        LoadInv();
        Boughtrobert();
        carprice();
        BoughtFlash();
        
        FlashLight.SetActive(false);
        car.SetActive(false);
        RoberticaBought = false;
        roberticaSkin.SetActive(false);
        robertSkin.SetActive(false);
        moneyNumber = itemInBus.money.ToString();
        equippedBool = FindObjectOfType<RobertticaSpawn>();
    }

    void Update()
    {
        print(itemInBus.money);
        carPriceText.text = "price: " + carPrice.ToString();
        moneyNumber = itemInBus.money.ToString();
        CurrentMoney.text = "Money: " + itemInBus.money.ToString();
        if (Input.GetKey(KeyCode.L))
        {
            itemInBus.money += 10000;
        }
        SaveInv();
    }

    public void carUpgrade()
    {
        car.SetActive(true);
        FlashLight.SetActive(false);
        roberticaSkin.SetActive(false);
        robertSkin.SetActive(false);
        if (itemInBus.money >= carPrice)
        {
            itemInBus.BusUp();
            Debug.Log("Carbought");
            itemInBus.money -= carPrice;
            carPrice *= 2;
            AudioSource.PlayClipAtPoint(buySound, car.transform.position);
            infoHolder.text = "Your bus will have more storage current storage:" + itemInBus.inventory;
            itemInBus.SaveMoney();
        }
        else
        {
            Debug.Log("NoMoney");
            AudioSource.PlayClipAtPoint(deneidSound, car.transform.position);
        }
    }

    public void Carinfo()
    {
        infoHolder.text = "Your bus will have more storage current storage:" + itemInBus.inventory;
        car.SetActive(true);
        FlashLight.SetActive(false);
        roberticaSkin.SetActive(false);
        robertSkin.SetActive(false);
    }

    public void Zaklamp()
    {
        car.SetActive(false);
        FlashLight.SetActive(true);
        roberticaSkin.SetActive(false);
        robertSkin.SetActive(false);
        if (zaklamp.HasBought == 0)
        {
            if (itemInBus.money >= FlashPrice)
            {
                {
                    zaklamp.HasBought = 1;
                    itemInBus.money -= FlashPrice;
                    infoHolder.text = "A flashlight so you don't have to stumble in the dark.\nOwned: " + (zaklamp.HasBought == 1 ? "Yes" : "No");
                    AudioSource.PlayClipAtPoint(buySound, car.transform.position);
                    itemInBus.SaveMoney();
                    FlashBuy.text = ("Bought");
                    FlashBuy.fontSize = 30;

                }
            }
        }
       
        else
        {
            AudioSource.PlayClipAtPoint(deneidSound, car.transform.position);
        }
    }

    public void InfoZaklamp()
    {
        FlashLight.SetActive(true);
        infoHolder.text = "A flashlight so you don't have to stumble in the dark.\nOwned: " + (zaklamp.HasBought == 1 ? "Yes" : "No");
        car.SetActive(false);
        roberticaSkin.SetActive(false);
        robertSkin.SetActive(false);
    }

    public void robertica()
    {
        FlashLight.SetActive(false);
        car.SetActive(false);
        if (!RoberticaBought && itemInBus.money >= RoberticaPrice)
        {
            itemInBus.money -= RoberticaPrice;
            robertSkin.SetActive(false);
            roberticaSkin.SetActive(true);
            RoberticaBought = true;
            RobertBuy.text = "Equipped";
            RobertBuy.fontSize = 30;
            AudioSource.PlayClipAtPoint(buySound, car.transform.position);
            infoHolder.text = "Robert is a dragqueen in his free time buy him a dress    " + (RoberticaBought ? "Equipped" : "Unequipped");
            itemInBus.SaveMoney();
            equippedBool.equipNum = 1;
            equippedBool.SaveEquipNum();
            hasRobertica = 1;
        }
        if (RoberticaBought)
        {
            AudioSource.PlayClipAtPoint(equip, car.transform.position);
            infoHolder.text = "Robert is a dragqueen in his free time buy him a dress     " + (roberticaON ? "Unequipped" : "Equipped");
            if (roberticaON)
            {
                robertSkin.SetActive(true);
                roberticaSkin.SetActive(false);
                roberticaON = false;
                equippedBool.equipNum = 0;
                RobertBuy.text = "Equip";
                equippedBool.SaveEquipNum();

            }
            else
            {
                robertSkin.SetActive(false);
                roberticaSkin.SetActive(true);
                roberticaON = true;
                equippedBool.equipNum = 1;
                RobertBuy.text = "Unequip";
                equippedBool.SaveEquipNum();

            }
        }
        else
        {
            AudioSource.PlayClipAtPoint(deneidSound, car.transform.position);
        }
    }

    public void roberticaInfo()
    {
        car.SetActive(false);
        FlashLight.SetActive(false);
        roberticaSkin.SetActive(true);
        robertSkin.SetActive(false);
        infoHolder.text = "Robert is a dragqueen in his free time buy him a dress     " + (roberticaON ? "Equipped" : "Unequipped");
    }

    public void ExitShop()
    {
        pickUpSc.SwitchCamera();
        Cursor.lockState = CursorLockMode.Locked;
        pickUpSc.player.SetActive(true);
        pickUpSc.shopscreen.enabled = false;
        pickUpSc.shopOpen = false;
        FlashLight.SetActive(false);
        car.SetActive(false);
        RoberticaBought = false;
        roberticaSkin.SetActive(false);
        robertSkin.SetActive(false);

    }
    public void Boughtrobert()
    {
        if (hasRobertica == 1)
        {
            RoberticaBought = true;
            RoberticaPrice = 0f;
            RobertBuy.fontSize = 30;
            if (roberticaON)
            {
                robertSkin.SetActive(true);
                roberticaSkin.SetActive(false);
                roberticaON = false;
                equippedBool.equipNum = 0;
                RobertBuy.text = "Equip";
                equippedBool.SaveEquipNum();
            }
            else
            {
                robertSkin.SetActive(false);
                roberticaSkin.SetActive(true);
                roberticaON = true;
                equippedBool.equipNum = 1;
                RobertBuy.text = "Unequip";
                equippedBool.SaveEquipNum();
            }
        }
    }
    public void carprice()
    {
        carPriceText.text = (carPrice.ToString());
    }
    public void BoughtFlash()
    {
        if (zaklamp.HasBought == 1)
        {
            FlashBuy.text = ("Bought");
            FlashBuy.fontSize = 30;
        }
    }
    public void SaveInv()
    {
        PlayerPrefs.SetInt("HasRobertica", hasRobertica);
        PlayerPrefs.SetFloat("CarPrice", carPrice);
        PlayerPrefs.Save();
    }
    public void LoadInv()
    {
        if (PlayerPrefs.HasKey("HasRobertica"))
        {
            hasRobertica = PlayerPrefs.GetInt("HasRobertica");
        }
        if (PlayerPrefs.HasKey("CarPrice"))
        {
            carPrice = PlayerPrefs.GetFloat("CarPrice");
        }
    }
}


