using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockerRoom : GridButtonLayoutCreator
{
    [SerializeField] private List<Image> previewCharacter;
    public void ChangePreview(ItemData clothesData)
    {
        switch (clothesData.ClothType)
        {
            case ClothesManager.ClothesType.Hair:
                previewCharacter[0].sprite = clothesData.Icon;
                break;
            case ClothesManager.ClothesType.Top:
                previewCharacter[1].sprite = clothesData.Icon;
                break;

            case ClothesManager.ClothesType.Bottom:
                previewCharacter[2].sprite = clothesData.Icon;
                break;

            case ClothesManager.ClothesType.Shoes:
                previewCharacter[3].sprite = clothesData.Icon;
                break;
        }
    }

     public override void CreateButtonGrid(ClothesManager.ClothesType type)
    {
        ResetButtonsList();
        lastClothesType = type;
        foreach (ItemData item in ClothesManager.Instance.ClothesData)
        {
            if (item.ClothType == type)
            {
                for (int index = 0; index < ClothesManager.Instance.PlayerClothController.IdClothes.Count; index++)
                {

                    if (item.Id == ClothesManager.Instance.PlayerClothController.IdClothes[index])
                    {
                        CreateButton(item);
                    }
                }
            }

        }
    }

}
