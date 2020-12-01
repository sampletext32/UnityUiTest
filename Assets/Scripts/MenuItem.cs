using Assets.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuItem : MonoBehaviour
{
    [Header("Text, displaying item name")]
    public TextMeshProUGUI ItemNameText;

    [Header("Text, displaying item amount")]
    public TextMeshProUGUI ItemAmountText;

    [Header("Text, displaying item cost")]
    public TextMeshProUGUI ItemCostText;

    [Header("Text, displaying user name")]
    public TextMeshProUGUI UserNameText;

    [Header("Text, displaying user stars")]
    public TextMeshProUGUI UserStarsText;

    [Header("Image, displaying item")]
    public Image ItemThumbnail;

    [Header("Image, displaying user icon")]
    public Image UserThumbnail;

    public async void Init(SaleItem saleItem, IImageLoader itemImageLoader, IImageLoader userImageLoader)
    {
        ItemNameText.text = saleItem.ItemName;
        ItemAmountText.text = saleItem.ItemAmount.ToString();
        ItemCostText.text = saleItem.ItemCost.ToString();
        UserNameText.text = saleItem.UserName;
        UserStarsText.text = saleItem.UserStars.ToString();
        ItemThumbnail.material.mainTexture = await itemImageLoader.Get();
        UserThumbnail.material.mainTexture = await userImageLoader.Get();
    }
}