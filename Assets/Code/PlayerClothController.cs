using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;


public class PlayerClothController : MonoBehaviour
{
    [SerializeField] private List<SpriteLibrary> clothes;
    [SerializeField] private List<int> idClothes;
    
    public List<int> IdClothes { get { return idClothes; } }

  
    public void ChangeClothes(ClothesManager.ClothesType type,SpriteLibraryAsset newClothes)
    {
        switch (type)
        {
            case ClothesManager.ClothesType.Hair:
                clothes[0].spriteLibraryAsset = newClothes;
                break;
            case ClothesManager.ClothesType.Top:
                clothes[1].spriteLibraryAsset = newClothes;
                break;

            case ClothesManager.ClothesType.Bottom:
                clothes[2].spriteLibraryAsset = newClothes;
                break;

            case ClothesManager.ClothesType.Shoes:
                clothes[3].spriteLibraryAsset = newClothes;
                break;
        }
    }

}
