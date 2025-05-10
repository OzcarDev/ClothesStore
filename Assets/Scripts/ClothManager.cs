using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class ClothManager : MonoBehaviour
{
    [SerializeField] private List<SpriteLibrary> clothes;
    [SerializeField] private List<int> idClothes;

    public List<int> IdClothes { get { return idClothes; } }

  

    public enum ClothesType{
        Top, Bottom,Hair,Shoes
    }

    public void ChangeClothes(SpriteLibraryAsset newClothes,int indexClothes)
    {
        clothes[indexClothes].spriteLibraryAsset = newClothes;
    }

}
