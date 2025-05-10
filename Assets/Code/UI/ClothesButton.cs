using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D.Animation;

public class ClothesButton : MonoBehaviour
{
    [SerializeField] private Image accesorySprite;
    [SerializeField] private Sprite previewSprite;
    [SerializeField] private SpriteLibraryAsset spriteLibrary = null;
    private ClothesManager.ClothesType type;
    public void AssignButtonValues(Sprite newSprite, SpriteLibraryAsset libraryAsset, ClothesManager.ClothesType newType)
    {
        previewSprite = newSprite;
        accesorySprite.sprite = newSprite;
        spriteLibrary = libraryAsset;
        type = newType;
    }

    public void ChangeClothes() 
    {
        ClothesManager.Instance.PlayerClothController.ChangeClothes(type,spriteLibrary,previewSprite);
    }
}
