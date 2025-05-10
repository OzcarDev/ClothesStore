using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;
using UnityEngine.UI;
public class LockerRoom : MonoBehaviour
{
    [SerializeField] private List<Image> previewCharacter;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Transform grid;
    [SerializeField] private List<ClothesButton> actualButtons = new List<ClothesButton>();

    private void OnEnable()
    {
        CreateButtonGrid(ClothesManager.ClothesType.Top);
    }

    // Start is called before the first frame update
    public void ChangePreview(ClothesManager.ClothesType type, Sprite spritePreview)
    {
        switch (type)
        {
            case ClothesManager.ClothesType.Hair:
                previewCharacter[0].sprite = spritePreview;
                break;
            case ClothesManager.ClothesType.Top:
                previewCharacter[1].sprite = spritePreview;
                break;

            case ClothesManager.ClothesType.Bottom:
                previewCharacter[2].sprite = spritePreview;
                break;

            case ClothesManager.ClothesType.Shoes:
                previewCharacter[3].sprite = spritePreview;
                break;
        }
    }

    private void CreateButtonGrid(ClothesManager.ClothesType type)
    {
        ResetButtonsList();
        
        foreach (ItemData item in ClothesManager.Instance.ClothesData)
        {
            if(item.ClothType == type)
            {
                for (int index = 0; index < ClothesManager.Instance.PlayerClothController.IdClothes.Count; index++)
                {

                    if (item.Id == ClothesManager.Instance.PlayerClothController.IdClothes[index])
                    {
                        CreateButton(item.Icon, item.SpriteLibrary, item.ClothType);
                    }
                }
            }
            
        }
    }
    private void ResetButtonsList()
    {
        Debug.Log("Lista Reseteada");
        for (int index = 0; index < actualButtons.Count; index++)
        {
            Destroy(actualButtons[index].gameObject);
        }
        actualButtons = new List<ClothesButton>();
    }
    private void CreateButton(Sprite newSprite, SpriteLibraryAsset libraryAsset, ClothesManager.ClothesType newType)
    {
        Debug.Log("BottonCreado");
        ClothesButton button = Instantiate(buttonPrefab).GetComponent<ClothesButton>();
        button.gameObject.transform.SetParent(grid);
        button.gameObject.transform.localScale = Vector3.one;
        button.AssignButtonValues(newSprite,libraryAsset,newType);
        actualButtons.Add(button);
    }

    public void CreateTopGrid()
    {
        CreateButtonGrid(ClothesManager.ClothesType.Top);
    }

    public void CreateBottomGrid()
    {
        CreateButtonGrid(ClothesManager.ClothesType.Bottom);
    }

    public void CreateHairGrid()
    {
        CreateButtonGrid(ClothesManager.ClothesType.Hair);
    }

    public void CreateShoesGrid()
    {
        CreateButtonGrid(ClothesManager.ClothesType.Shoes);
    }

}
