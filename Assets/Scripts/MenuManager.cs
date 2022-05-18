using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class MenuManager : MonoBehaviour
{
    int currentMenu = 1;
    // ENCAPSULATION
    [SerializeField]
    private GameObject Mainmenu;
    // ENCAPSULATION
    [SerializeField]
    private GameObject ShopMenu;

    // ABSTRACTION // POLYMORPHISM
    private void Awake()
    {
        MenuAutoChangerByClick();
    }
    // ABSTRACTION
    private void SelectMenu(int menuIndex)
    {
        if(menuIndex == 0)
        {
            Mainmenu.SetActive(true);
            ShopMenu.SetActive(false);
            currentMenu = 0;
        }
        else
        {
            ShopMenu.SetActive(true);
            Mainmenu.SetActive(false);
            currentMenu = 1;
        }
    }
    // ABSTRACTION
    public void MenuAutoChangerByClick()
    {
        if (currentMenu == 0)
        {
            SelectMenu(1);
        }
        else
        {
            SelectMenu(0);
        }
    }
}
