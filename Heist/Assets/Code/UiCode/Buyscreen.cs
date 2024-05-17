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
    public GameObject FlashLight;
    // Start is called before the first frame update
    void Start()
    {
        FlashLight.SetActive(false);
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
        FlashLight.SetActive(false);
        infoHolder.text = "Your bus will have more storage";
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
        FlashLight.SetActive(false);
    }
    public void Zaklamp()
    {
        infoHolder.text = "A flashlight so you dont have stumble in the dark";
        car.SetActive(false);
        FlashLight.SetActive(true);
        if (!zaklamp.HasBought && itemInBus.money >= FlashPrice)
        {
            zaklamp.HasBought = true;
            itemInBus.money -= carPrice;
            
        }
    }
    public void InfoZaklamp()
    {
        FlashLight.SetActive(true);
        infoHolder.text = "A flashlight so you dont have stumble in the dark";
        car.SetActive(false); 
    }
}
