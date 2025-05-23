using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

[CreateAssetMenu(fileName = "New Item Data", menuName = "Item Data")]
public class ItemData : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private Sprite icon;
    [SerializeField] private int buyingPrice;
    [SerializeField] private int sellingPrice;
    [SerializeField] private SpriteLibraryAsset spriteLibrary;
    [SerializeField] private ClothesManager.ClothesType clothesType;
    [SerializeField] private int id;

    public string ItemName {  get { return itemName; } }
    public Sprite Icon { get { return icon; } }
    public int BuyingPrice { get { return buyingPrice; } }
    public int SellingPrice {  get { return sellingPrice; } }
    public SpriteLibraryAsset SpriteLibrary { get { return spriteLibrary; } }
    public int Id { get { return id; } }
    public ClothesManager.ClothesType ClothType { get { return clothesType; } }

}
