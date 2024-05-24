using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Mathematics;

public class Buyscreen : MonoBehaviour
{
    public TMP_Text RobertBuy;
    public TMP_Text infoHolder;
    public TMP_Text carPriceText;
    public ItemInBus itemInBus;
    public Zaklamp zaklamp;
    public float carPrice = 100;
    public float FlashPrice = 100;
    public float RoberticaPrice = 100000;
    public GameObject car;
    public GameObject FlashLight;
    public AudioClip buySound;
    public bool Owned;
    public GameObject robertSkin;
    public GameObject roberticaSkin;
    public bool RoberticaBought;
    public bool roberticaON;
    // Start is called before the first frame update
    void Start()
    {
        FlashLight.SetActive(false);
        car.SetActive(false);
        RoberticaBought = false;
        roberticaSkin.SetActive(false);
        robertSkin.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        carPriceText.text = "price: " + carPrice.ToString();
    }
    public void carUpgrade()
    {
        car.SetActive(true);
        FlashLight.SetActive(false);
        roberticaSkin.SetActive(false);
        robertSkin.SetActive(false);
        infoHolder.text = "Your bus will have more storage current sorage:" + itemInBus.inventory;
        if (itemInBus.money >= carPrice)
        {
            itemInBus.BusUp();
            Debug.Log("Carbought");
            itemInBus.money -= carPrice;
            carPrice *= 2;
            AudioSource.PlayClipAtPoint(buySound, car.transform.position);
            infoHolder.text = "Your bus will have more storage current sorage:" + itemInBus.inventory;
        }
        else
        {
            Debug.Log("NoMoney"); 
        }
    }
    public void Carinfo()
    {
        infoHolder.text = "Your bus will have more storage current sorage:" + itemInBus.inventory;
        car.SetActive(true);
        FlashLight.SetActive(false);
        roberticaSkin.SetActive(false);
        robertSkin.SetActive(false);
    }
    public void Zaklamp()
    {
        infoHolder.text = "A flashlight so you don't have to stumble in the dark.\nOwned: " + (zaklamp.HasBought ? "Yes" : "No");
        car.SetActive(false);
        FlashLight.SetActive(true);
        roberticaSkin.SetActive(false);
        robertSkin.SetActive(false);
        if (!zaklamp.HasBought && itemInBus.money >= FlashPrice)
        {
            zaklamp.HasBought = true;
            itemInBus.money -= carPrice;
            infoHolder.text = "A flashlight so you don't have to stumble in the dark.\nOwned: " + (zaklamp.HasBought ? "Yes" : "No");
            AudioSource.PlayClipAtPoint(buySound, car.transform.position);

        }
    }
    public void InfoZaklamp()
    {
        FlashLight.SetActive(true);
        infoHolder.text = "A flashlight so you don't have to stumble in the dark.\nOwned: " + (zaklamp.HasBought ? "Yes" : "No");
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
                roberticaON = true;
                RobertBuy.text = "Equipped";
                RobertBuy.fontSize = 30;
                infoHolder.text = "Robert is a dragqeeun in his free time buy him a dress:" + (RoberticaBought ? "Equipped" : "Unequipped");
            }
            if (RoberticaBought)
            {
                infoHolder.text = "Robert is a dragqeeun in his free time buy him a dress: " + (roberticaON ? "Unequipped" : "Equipped");
                if (roberticaON)
                {
                    robertSkin.SetActive(true);
                    roberticaSkin.SetActive(false);
                    roberticaON = false;
                    RobertBuy.text = "Equip";


                }
                else
                {
                    robertSkin.SetActive(false);
                    roberticaSkin.SetActive(true);
                    roberticaON = true;
                    RobertBuy.text = "Unquip";
                }
            }

        }
    public void roberticaInfo()
    {
        infoHolder.text = "Robert is a dragqeeun in his free time buy him a dress: " + (roberticaON ? "Equipped" : "Unequipped");
    }
}
