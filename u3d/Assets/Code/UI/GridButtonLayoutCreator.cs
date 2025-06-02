using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;
using UnityEngine.UI;
public class GridButtonLayoutCreator : MonoBehaviour
{
    
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Transform grid;
    [SerializeField] private List<ClothesButton> actualButtons = new List<ClothesButton>();

    protected ClothesManager.ClothesType lastClothesType;
    private void OnEnable()
    {
        CreateButtonGrid(ClothesManager.ClothesType.Top);
    }

    // Start is called before the first frame update
    
    public void ReloadGrid()
    {
        CreateButtonGrid(lastClothesType);
    }

    public virtual void CreateButtonGrid(ClothesManager.ClothesType type)
    {
        ResetButtonsList();
        bool playerHaveIt = false;
        lastClothesType = type;
        foreach (ItemData item in ClothesManager.Instance.ClothesData)
        {
            if (item.ClothType == type)
            {
                for (int index = 0; index < ClothesManager.Instance.PlayerClothController.IdClothes.Count; index++)
                {

                    if (item.Id == ClothesManager.Instance.PlayerClothController.IdClothes[index])
                    {
                        Debug.Log(item.Id);
                        Debug.Log(ClothesManager.Instance.PlayerClothController.IdClothes[index]);
                        playerHaveIt = true;
                    }
                }
                if (!playerHaveIt)
                {

                    CreateButton(item);
                }
                playerHaveIt = false;
            }

        }
    }
    protected void ResetButtonsList()
    {
        
        for (int index = 0; index < actualButtons.Count; index++)
        {
            if (actualButtons[index] != null) 
            { 
                Destroy(actualButtons[index].gameObject);
            }
        }
        actualButtons = new List<ClothesButton>();
    }
    protected void CreateButton(ItemData clothesItemData)
    {
        
        ClothesButton button = Instantiate(buttonPrefab).GetComponent<ClothesButton>();
        button.gameObject.transform.SetParent(grid);
        button.gameObject.transform.localScale = Vector3.one;
        button.AssignButtonValues(clothesItemData);
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
