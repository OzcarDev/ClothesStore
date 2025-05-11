using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;


public class PlayerClothController : MonoBehaviour
{
    [SerializeField] private List<SpriteLibrary> clothes;
    [SerializeField] private List<int> idPlayersClothes;
    private int TopId = 1;
    private int BottomId = 4;
    private int HairId = 7;
    private int ShoesId = 10;

    public List<int> IdClothes { get { return idPlayersClothes; } }

  
    public void ChangeClothes(ItemData clothesData)
    {
        switch (clothesData.ClothType)
        {
            case ClothesManager.ClothesType.Hair:
                clothes[0].spriteLibraryAsset = clothesData.SpriteLibrary;
                break;
            case ClothesManager.ClothesType.Top:
                clothes[1].spriteLibraryAsset = clothesData.SpriteLibrary;
                break;

            case ClothesManager.ClothesType.Bottom:
                clothes[2].spriteLibraryAsset = clothesData.SpriteLibrary;
                break;

            case ClothesManager.ClothesType.Shoes:
                clothes[3].spriteLibraryAsset = clothesData.SpriteLibrary;
                break;
        }
    }

}
