using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    

public class NormalBlock : BaseBlock
{
    [SerializeField]
    private float _MaterialValue = 10;
    [SerializeField]
    private float _BuyPrice = 0;
    [SerializeField]
    private float _SellPrice = 1;
    [SerializeField]
    private float _SellMultiplier;
    [SerializeField]
    private float _BuyMultiplier;
    [SerializeField]
    private float _ClickMultiplier;
    [SerializeField]
    private float _PriceForClick;

    [SerializeField]
    private Button Sellbutton;
    protected override void SetBlockData()
    {
        base.MaterialValue = _MaterialValue;
        base.BuyPrice = _BuyPrice;
        base.SellPrice = _SellPrice;
        base.SellMultiplier = _SellMultiplier;
        base.ClickMultiplier = _ClickMultiplier;
        base.PriceForClick = _PriceForClick;
        base.BuyMultiplier = _BuyMultiplier;
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
    private void Start()
    {
        Sellbutton.onClick.AddListener(sellClicked);
    }
}
