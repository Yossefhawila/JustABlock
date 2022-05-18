using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public abstract class BaseBlock : MonoBehaviour
{
    protected double MaterialValue =10;
    protected double BuyPrice =0;
    protected double BuyPriceMultiplier;
    protected double SellPrice =1;
    protected double NowSellPrice;
    protected double SellMultiplier;
    protected double ClickMultiplier;


    // POLYMORPHISM // ABSTRACTION
    public abstract void SetBlockData();

    // POLYMORPHISM // ABSTRACTION
    protected virtual double GetAmount()
    {
        double amount =MaterialValue*ClickMultiplier;
        return amount;
    }
    // ABSTRACTION
    protected void IncreasePrice(GameObject block)
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
    // POLYMORPHISM // ABSTRACTION
    protected virtual double GetSellPrice()
    {
        return SellMultiplier * NowSellPrice;
    }
    // ABSTRACTION
    protected void sellBlock(GameObject block)
    {
        if (block.activeInHierarchy)
        {
            PlayerData.instance.ADDMoney(GetSellPrice());

            DeActiveBlock(block);
        }
        

    }
    // ABSTRACTION
    protected void BuyBlock(GameObject block)
    {
        if (BuyPrice <= PlayerData.instance.PlayerMoneyValue&&!block.activeInHierarchy)
        {
            PlayerData.instance.ADDMoney(-BuyPrice*BuyPriceMultiplier);
            
            block.SetActive(true);
        }
    }

    // ABSTRACTION
    protected void ActiveBlock(GameObject block)
    {
        block.SetActive(true);
    }
    // ABSTRACTION
    protected void DeActiveBlock(GameObject block)
    {
        block.SetActive(false);
    }
}
