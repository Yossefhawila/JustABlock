using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//INHERITANCE
public class NormalBlock : BaseBlock
{


    // ENCAPSULATION
    [SerializeField]
    private Button Sellbutton;
    // ENCAPSULATION
    [SerializeField]
    private Text BlockPrice;

    public static NormalBlock instacne;

    // ABSTRACTION // POLYMORPHISM
    public override void SetBlockData()
    {
        base.MaterialValue = PlayerData.instance.MaterialValue;
        base.BuyPriceMultiplier = PlayerData.instance.BuyPriceMultiplier;
        base.BuyPrice = PlayerData.instance.BuyPrice;
        base.SellPrice = PlayerData.instance.SellPrice;
        base.SellMultiplier = PlayerData.instance.SellMultiplier;
        base.ClickMultiplier = PlayerData.instance.ClickMultiplier;
        base.NowSellPrice = SellPrice;
        
    }
    // ABSTRACTION 
    public void BlockClicked()
    {
        IncreasePrice(gameObject.transform.GetChild(0).gameObject);
        BlockPrice.text= PlayerData.instance.getMoneyText((SellMultiplier * NowSellPrice) - 1);
    }
    // ABSTRACTION
    public void sellClicked()
    {
        sellBlock(gameObject.transform.GetChild(0).gameObject);
        SetBlockData();
        BlockPrice.text = PlayerData.instance.getMoneyText((SellMultiplier * NowSellPrice)-1);

    }
    // ABSTRACTION // POLYMORPHISM
    private void Start()
    {
        instacne = this;
        SetBlockData();
        Sellbutton.onClick.AddListener(sellClicked);
    }
}
