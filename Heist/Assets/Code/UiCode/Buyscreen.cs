using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Mathematics;

public class Buyscreen : MonoBehaviour
{
    public TMP_Text infoHolder;
    public TMP_Text carPriceText;
    public ItemInBus itemInBus;
    public Zaklamp zaklamp;
    public float carPrice = 100;
    public float FlashPrice = 100;
    public GameObject car;
    // Start is called before the first frame update
    void Start()
    {
        car.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        carPriceText.text = "price: " + carPrice.ToString();
    }
    public void carUpgrade()
    {
        car.SetActive(true);
        if (itemInBus.money >= carPrice)
        {
            itemInBus.BusUp();
            Debug.Log("Carbought");
            itemInBus.money -= carPrice;
            carPrice *= 2;
        }
        else
        {
            Debug.Log("NoMoney"); 
        }
    }
    public void Carinfo()
    {
        infoHolder.text = "Your bus will have more storage";
        car.SetActive(true);
    }
    public void Zaklamp()
    {
        if (!zaklamp.HasBought && itemInBus.money >= FlashPrice)
        {
            zaklamp.HasBought = true;
            itemInBus.money -= carPrice;
        }
    }
    public void InfoZaklamp()
    {
        infoHolder.text = "A flashlight so you dont have stumble in the dark";
    }
}
