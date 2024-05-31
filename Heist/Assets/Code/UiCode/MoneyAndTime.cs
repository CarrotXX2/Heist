using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class MoneyAndTime : MonoBehaviour
{
    public TMP_Text moneyCountl;
    public ItemInBus moneyScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moneyCountl.text = moneyScript.money.ToString() ;
    }
}
