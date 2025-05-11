using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D.Animation;
using TMPro;

public class ClothesButton : MonoBehaviour
{
    [SerializeField] private Image accesorySprite;
    [SerializeField] private Sprite previewSprite;
    [SerializeField] private TextMeshProUGUI priceTag;
    [SerializeField] private ButtonType buttonType = ButtonType.None;
    private ItemData clothesData;
    private int idClothes;
    

    private enum ButtonType
    {
        None,Buy,Sell
    }
    
    private void SetPriceTag()
    {
        switch (buttonType)
        {
            case ButtonType.Buy:
                priceTag.text = clothesData.BuyingPrice.ToString();
                break;
            case ButtonType.Sell:
                priceTag.text = clothesData.SellingPrice.ToString();
                break;
            case ButtonType.None:
                break;
        }
    }
    public void AssignButtonValues(ItemData newClothesData)
    {
        clothesData = newClothesData;
        previewSprite = clothesData.Icon;
        accesorySprite.sprite = clothesData.Icon;
        idClothes = clothesData.Id;
        SetPriceTag();
    }

    public void ChangeClothes() 
    {
        ClothesManager.Instance.PlayerClothController.ChangeClothes(clothesData);
        ClothesManager.Instance.Locker.ChangePreview(clothesData);
    }

    public void SellClothes()
    {
       
        ClothesManager.Instance.PlayerClothController.IdClothes.Remove(idClothes);
        ClothesManager.Instance.BuyPanel.ReloadGrid();
        Destroy(gameObject);
    }

    public void BuyClothes()
    {
        if (GameManager.Instance.Buy(clothesData.BuyingPrice))
        {

            ClothesManager.Instance.PlayerClothController.IdClothes.Add(idClothes);
            ClothesManager.Instance.SellPanel.ReloadGrid();
            Destroy(gameObject);
        }
    
    }
}
