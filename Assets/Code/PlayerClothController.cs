using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;


public class PlayerClothController : MonoBehaviour
{
    [SerializeField] private List<SpriteLibrary> clothes;
    [SerializeField] private List<int> idPlayersClothes;
    [SerializeField]private int[] actualClothes = new int[4];

    public int[] ActualClothes { get { return actualClothes; } }

    public List<int> IdClothes { get { return idPlayersClothes; } }

  
    public void ChangeClothes(ItemData clothesData)
    {
        switch (clothesData.ClothType)
        {
            case ClothesManager.ClothesType.Hair:
                clothes[0].spriteLibraryAsset = clothesData.SpriteLibrary;
                actualClothes[0] = clothesData.Id;
                break;
            case ClothesManager.ClothesType.Top:
                clothes[1].spriteLibraryAsset = clothesData.SpriteLibrary;
                actualClothes[1] = clothesData.Id;
                break;

            case ClothesManager.ClothesType.Bottom:
                clothes[2].spriteLibraryAsset = clothesData.SpriteLibrary;
                actualClothes[2] = clothesData.Id;
                break;

            case ClothesManager.ClothesType.Shoes:
                clothes[3].spriteLibraryAsset = clothesData.SpriteLibrary;
                actualClothes[3] = clothesData.Id;
                break;
        }
    }

}
