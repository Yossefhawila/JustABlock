using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

// INHERITANCE
public abstract class BaseUi : MonoBehaviour
{
    protected string NameTitle;
    protected string description;
    protected GameObject UiBody;
    protected Text NameText;
    protected Text DescriptionText;

    // POLYMORPHISM // ABSTRACTION
    protected virtual void SetUiBody(GameObject Body )
    {
        
        UiBody = Body;
        NameText = GameObject.FindGameObjectWithTag("NameText").GetComponent<Text>();
        DescriptionText = GameObject.FindGameObjectWithTag("DescriptionText").GetComponent<Text>();
        Invoke("HideUi",0.01f);
    }
    // POLYMORPHISM // ABSTRACTION
    protected virtual void UiSetName(string NameTitle)
    {
        this.NameTitle = NameTitle;
        NameText.text = NameTitle;
    }
    // POLYMORPHISM // ABSTRACTION
    protected virtual void UiSetDescription(string description)
    {
        this.description = description;
        DescriptionText.text = description;
    }
    // POLYMORPHISM // ABSTRACTION
    protected virtual void showUi()
    {
        UiSetName("Name");
        UiSetDescription("Description");
        UiBody.SetActive(true);
        Invoke("HideUi", 2.1f);

    }

    // POLYMORPHISM // ABSTRACTION
    protected virtual void Awake()
    {
        SetUiBody(GameObject.FindGameObjectWithTag("InfoUi"));
    }
    // ABSTRACTION
    protected void HideUi()
    {
        UiBody.SetActive(false);
    }


}
