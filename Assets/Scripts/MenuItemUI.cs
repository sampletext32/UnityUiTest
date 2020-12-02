using DataManagers;
using ImageLoaders;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuItemUI : MonoBehaviour
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
    public GameObject ItemThumbnail;

    [Header("Image, displaying user icon")]
    public GameObject UserThumbnail;

    public void Init(SaleItem saleItem)
    {
        ItemNameText.text = saleItem.ItemData.Name;
        ItemAmountText.text = saleItem.ItemData.Amount.ToString();
        ItemCostText.text = saleItem.ItemData.Cost.ToString();
        UserNameText.text = saleItem.UserData.Nickname;
        UserStarsText.text = saleItem.UserData.Lvl.ToString();

        var itemImageLoader = ItemThumbnail.AddComponent<AddressableImageLoader>();
        itemImageLoader.AddressableName = ItemToAddressable.GetAddressableByItemName(saleItem.ItemData.Name);

        var userImageLoader = UserThumbnail.AddComponent<UrlImageLoader>();
        userImageLoader.Url = saleItem.UserData.ImageUrl;
    }
}