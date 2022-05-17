using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    

public class NormalBlock : BaseBlock
{
   

    [SerializeField]
    private Button Sellbutton;
    [SerializeField]
    private Text BlockPrice;

    protected override void SetBlockData()
    {
        base.MaterialValue = PlayerData.instance.MaterialValue;
        base.BuyPriceMultiplier = PlayerData.instance.BuyPriceMultiplier;
        base.BuyPrice = PlayerData.instance.BuyPrice;
        base.SellPrice = PlayerData.instance.SellPrice;
        base.SellMultiplier = PlayerData.instance.SellMultiplier;
        base.ClickMultiplier = PlayerData.instance.ClickMultiplier;
        base.NowSellPrice = SellPrice;
        
    }
    public void BlockClicked()
    {
        IncreasePrice(gameObject.transform.GetChild(0).gameObject);
        BlockPrice.text= PlayerData.instance.getMoneyText((SellMultiplier * NowSellPrice) - 1);
    }
    public void sellClicked()
    {
        sellBlock(gameObject.transform.GetChild(0).gameObject);
        SetBlockData();
        BlockPrice.text = PlayerData.instance.getMoneyText((SellMultiplier * NowSellPrice)-1);

    }
    private void Start()
    {
        SetBlockData();
        Sellbutton.onClick.AddListener(sellClicked);
    }
}
