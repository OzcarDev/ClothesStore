using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesManager : MonoBehaviour
{
    [SerializeField] private List<ItemData> clothesData;
    public List<ItemData> ClothesData {  get { return clothesData; } }

    [SerializeField] PlayerClothController playerClothController;
    public PlayerClothController PlayerClothController {  get { return playerClothController; } }
    
    private static ClothesManager instance = null;
    public static ClothesManager Instance {  get { return instance; } }

    [SerializeField] private LockerRoom locker;
    public LockerRoom Locker { get { return locker; } }

    [SerializeField] private LockerRoom sellPanel;
    public LockerRoom SellPanel { get { return sellPanel; } }
    [SerializeField] private GridButtonLayoutCreator buyPanel;
    public GridButtonLayoutCreator BuyPanel { get { return buyPanel; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    public enum ClothesType
    {
        Top, Bottom, Hair, Shoes
    }


}
