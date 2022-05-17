using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBlock : MonoBehaviour
{
    protected double MaterialValue =10;
    protected double BuyPrice =0;
    protected double SellPrice =1;
    protected double NowSellPrice;
    protected double SellMultiplier;
    protected double BuyMultiplier;
    protected double ClickMultiplier;
    protected double PriceForClick;



    protected abstract void SetBlockData();
    
    protected virtual double GetAmount()
    {
        double amount =MaterialValue*ClickMultiplier;
        return amount;
    } 
    protected  void IncreasePrice(GameObject block)
    {
        if (block.activeInHierarchy)
        {
            NowSellPrice += GetAmount();
        }
        else 
        {
            BuyBlock(block);
        }
    }
    protected virtual double GetSellPrice()
    {
        return SellMultiplier * NowSellPrice;
    }
    protected  void sellBlock(GameObject block)
    {
        if (block.activeInHierarchy)
        {
            PlayerData.instance.ADDMoney(GetSellPrice());

            DeActiveBlock(block);
        }
        

    }
    protected void BuyBlock(GameObject block)
    {
        if (BuyPrice < PlayerData.instance.PlayerMoneyValue&&!block.activeInHierarchy)
        {
            PlayerData.instance.ADDMoney(-BuyPrice);
            
            block.SetActive(true);
        }
    }
    private void Start()
    {
        SetBlockData();
    }

    protected void ActiveBlock(GameObject block)
    {
        block.SetActive(true);
    }
    protected void DeActiveBlock(GameObject block)
    {
        block.SetActive(false);
    }
}
