using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class UiElement : BaseUi
{
    // ENCAPSULATION
    [SerializeField]
    private string NameOfElement="ElementName";
    // ENCAPSULATION
    [SerializeField]
    private string DescriptionOfElement = "ElementDescription";

    // POLYMORPHISM // ABSTRACTION
    protected override void UiSetName(string NameTitle)
    {
        base.UiSetName(NameOfElement);
    }
    // POLYMORPHISM // ABSTRACTION
    protected override void UiSetDescription(string description)
    {
        base.UiSetDescription(DescriptionOfElement);
    }

    // ABSTRACTION // POLYMORPHISM
    private void OnMouseEnter()
    {
        Invoke("ShowUiElement", 1.5f);
    }
    // ABSTRACTION // POLYMORPHISM
    private void OnMouseExit()
    {
        CancelInvoke("ShowUiElement");
    }
    // ABSTRACTION // POLYMORPHISM
    private void OnMouseDown()
    {
        CancelInvoke("ShowUiElement");
    }

    // ABSTRACTION
    public void ShowUiElement()
    {
        showUi();
    }

}
