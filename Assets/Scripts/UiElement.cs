using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiElement : BaseUi
{
    [SerializeField]
    private string NameOfElement="ElementName";
    [SerializeField]
    private string DescriptionOfElement = "ElementDescription";
    
    protected override void UiSetName(string NameTitle)
    {
        base.UiSetName(NameOfElement);
    }
    protected override void UiSetDescription(string description)
    {
        base.UiSetDescription(DescriptionOfElement);
    }


    private void OnMouseEnter()
    {
        Invoke("ShowUiElement", 1.5f);
    }
    private void OnMouseExit()
    {
        CancelInvoke("ShowUiElement");
    }

    public void ShowUiElement()
    {
        showUi();
    }

}
