using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// INHERITANCE
public class YesNoUi : BaseUi
{
    // ENCAPSULATION
    [SerializeField]
    private GameObject YesNoUiBody;
    // ENCAPSULATION
    [SerializeField]
    private Text YesNoUiTitleName;
    // ENCAPSULATION
    [SerializeField]
    private Text YesNoUiDiscription;
    // ENCAPSULATION
    [SerializeField]
    private Button YesButton;
    // ENCAPSULATION
    [SerializeField]
    private Button NoButton;
    // ENCAPSULATION
    [SerializeField]
    private string PowerUpType;



    // ABSTRACTION // POLYMORPHISM
    protected override void SetUiBody(GameObject Body)
    {
        UiBody = YesNoUiBody;
        NameText = YesNoUiTitleName;
        DescriptionText = YesNoUiDiscription;
        Invoke("HideUi", 0.01f);
    }
    // ABSTRACTION // POLYMORPHISM
    protected override void Awake()
    {
        YesNoUiBody = GameObject.FindGameObjectWithTag("YesNoUi");
        YesNoUiTitleName = GameObject.FindGameObjectWithTag("YesNameText").GetComponent<Text>();
        YesNoUiDiscription = GameObject.FindGameObjectWithTag("YesDiscriptionText").GetComponent<Text>();
        YesButton = GameObject.FindGameObjectWithTag("YesButton").GetComponent<Button>();
        NoButton = GameObject.FindGameObjectWithTag("NoButton").GetComponent<Button>();
        YesButton.onClick.AddListener(onYesButtonClicked);
        NoButton.onClick.AddListener(onNoButtonClicked);


       SetUiBody(YesNoUiBody);

    }
    // ABSTRACTION // POLYMORPHISM
    protected override void showUi()
    {
        UiBody.SetActive(true);
    }
    // ABSTRACTION
    private void OnMouseDown()
    {
        Invoke(PowerUpType + "0", 0);
        showUi();

    }
    // ABSTRACTION
    private void onYesButtonClicked()
    {
        
        Invoke(PowerUpType,0.1f);
    }
    // ABSTRACTION
    private void onNoButtonClicked()
    {
       
        HideUi();
    }
    // ABSTRACTION
    private void MaterialValueUpgrade0()
    {
        YesNoUiTitleName.text = "x" + PlayerData.instance.getMoneyText(PlayerData.instance.MaterialValue * 100);
        YesNoUiDiscription.text = $"Increase Material value from " +
            $"x{PlayerData.instance.getMoneyText(PlayerData.instance.MaterialValue)} " +
            $" to x{PlayerData.instance.getMoneyText(PlayerData.instance.MaterialValue * 100)} " +
            $"With Price of {PlayerData.instance.getMoneyText(PlayerData.instance.MaterialValueUpgrade)}";
    }
    // ABSTRACTION
    private void SellMultiplierUpgrade0()
    {
        YesNoUiTitleName.text = "x" + PlayerData.instance.getMoneyText(PlayerData.instance.SellMultiplier + 1);
        YesNoUiDiscription.text = $"Increase sell price from " +
            $"x{PlayerData.instance.getMoneyText(PlayerData.instance.SellMultiplier)} " +
            $" to x{PlayerData.instance.getMoneyText(PlayerData.instance.SellMultiplier + 2)} " +
            $"With Price of {PlayerData.instance.getMoneyText(PlayerData.instance.SellMultiplierUpgrade)}";
    }
    // ABSTRACTION
    private void BuyPriceMultiplierUpgrade0()
    {
        YesNoUiTitleName.text = "x" + PlayerData.instance.getMoneyText(1/(PlayerData.instance.BuyPriceMultiplier * 0.5f));
        YesNoUiDiscription.text = $"Decrease price Multiplier from " +
            $"x{PlayerData.instance.getMoneyText(1/PlayerData.instance.BuyPriceMultiplier)} " +
            $" to x{PlayerData.instance.getMoneyText(1 / (PlayerData.instance.BuyPriceMultiplier * 0.5f))} " +
            $"With Price of {PlayerData.instance.getMoneyText(PlayerData.instance.BuyPriceMultiplierUpgrade)}";
    }
    // ABSTRACTION
    private void ClickMultiplierUpgrade0()
    {
        YesNoUiTitleName.text = "x" + PlayerData.instance.getMoneyText(PlayerData.instance.ClickMultiplier * 1.1f);
        YesNoUiDiscription.text = $"Increase click Multiplier from " +
            $"x{PlayerData.instance.getMoneyText(PlayerData.instance.ClickMultiplier)} " +
            $" to x{PlayerData.instance.getMoneyText(PlayerData.instance.ClickMultiplier *1.1f)} " +
            $"With Price of {PlayerData.instance.getMoneyText(PlayerData.instance.ClickMultiplierupgrade)}";
    }

    // ABSTRACTION
    private void MaterialValueUpgrade()
    {
        if (PlayerData.instance.PlayerMoneyValue>=PlayerData.instance.MaterialValueUpgrade) 
        {
            PlayerData.instance.MaterialValue *= 100;
            PlayerData.instance.MaterialValueUpgrade *= 100;
            PlayerData.instance.ADDMoney(-PlayerData.instance.BuyPriceMultiplierUpgrade);
            IncreasBuyPrice(20);
            PlayerData.instance.ADDMoney(PlayerData.instance.BuyPrice);
            NormalBlock.instacne.SetBlockData();
            PlayerData.instance.SaveData();
            HideUi();
            

        }
    }
    // ABSTRACTION
    private void IncreasBuyPrice(double IncreaseBy)
    {
        PlayerData.instance.BuyPrice *= IncreaseBy;
    }
    // ABSTRACTION
    private void SellMultiplierUpgrade()
    {
        if (PlayerData.instance.PlayerMoneyValue >= PlayerData.instance.SellMultiplierUpgrade)
        {
            PlayerData.instance.ADDMoney(-PlayerData.instance.SellMultiplierUpgrade);
            PlayerData.instance.SellMultiplier += 1;
            PlayerData.instance.SellMultiplierUpgrade *= 2;
            PlayerData.instance.ADDMoney(PlayerData.instance.BuyPrice);
            HideUi();


        }
    }
    // ABSTRACTION
    private void BuyPriceMultiplierUpgrade()
    {
        if (PlayerData.instance.PlayerMoneyValue >= PlayerData.instance.BuyPriceMultiplierUpgrade)
        {
            PlayerData.instance.ADDMoney(-PlayerData.instance.BuyPriceMultiplierUpgrade);
            PlayerData.instance.BuyPriceMultiplier *= 0.5f;
            PlayerData.instance.BuyPriceMultiplierUpgrade *= 2;
            PlayerData.instance.ADDMoney(PlayerData.instance.BuyPrice);
            HideUi();

        }
    }
    // ABSTRACTION
    private void ClickMultiplierUpgrade()
    {
        if (PlayerData.instance.PlayerMoneyValue >= PlayerData.instance.ClickMultiplierupgrade)
        {
            PlayerData.instance.ADDMoney(-PlayerData.instance.ClickMultiplierupgrade);
            PlayerData.instance.ClickMultiplier *= 1.1f;
            PlayerData.instance.ClickMultiplierupgrade *= 1.1f;
            PlayerData.instance.ADDMoney(PlayerData.instance.BuyPrice);
            HideUi();

        }
    }
    // ABSTRACTION
    private void GetMoney()
    {
        //WatchAD
        //Get Reward
        //GetMoney
    }






}
