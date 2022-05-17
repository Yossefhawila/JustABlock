using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    

public class NormalBlock : BaseBlock
{
   

    [SerializeField]
    private Button Sellbutton;
    protected override void SetBlockData()
    {
        base.MaterialValue = PlayerData.instance.MaterialValue;
        base.BuyPrice = PlayerData.instance.BuyPrice;
        base.SellPrice = PlayerData.instance.SellPrice;
        base.SellMultiplier = PlayerData.instance.SellMultiplier;
        base.ClickMultiplier = PlayerData.instance.ClickMultiplier;
        base.PriceForClick = PlayerData.instance.PriceForClick;
        base.BuyMultiplier = PlayerData.instance.PriceForClick;
        base.NowSellPrice = SellPrice;
        
    }
    public void BlockClicked()
    {
        IncreasePrice(gameObject.transform.GetChild(0).gameObject);
    }
    public void sellClicked()
    {
        sellBlock(gameObject.transform.GetChild(0).gameObject);
        SetBlockData();
    }
    private void Awake()
    {
        Sellbutton.onClick.AddListener(sellClicked);
    }
}
