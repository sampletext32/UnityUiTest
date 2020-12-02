using System.Collections;
using Assets.Scripts.Models;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class MenuItems : MonoBehaviour
{
    [Header("Menu Item Prefab, that should be instanced")]
    public GameObject MenuItemPrefab;

    [Header("Left column, that contains left elements")]
    public RectTransform LeftColumn;
    
    [Header("Right column, that contains right elements")]
    public RectTransform RightColumn;
    
    [Header("Column Container Element, used for resizing")]
    public RectTransform ContentRoot;

    private SaleItems _saleItems;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(LoadItems());
    }

    private IEnumerator LoadItems()
    {
        string url = "https://gist.githubusercontent.com/sampletext32/e7dfdf2602b59ba798b882be520d9364/raw/1cf374aded0128f8cf2bf7d03b48c960ac9beca9/farm_data.json";

        UnityWebRequest webRequest = UnityWebRequest.Get(url);

        var asyncOperation = webRequest.SendWebRequest();

        yield return asyncOperation;

        if (webRequest.isNetworkError || webRequest.isHttpError)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            Debug.Log("Request successful");
            var jsonData = webRequest.downloadHandler.text;
            Debug.Log(jsonData);
            _saleItems = JsonConvert.DeserializeObject<SaleItems>(jsonData);
            StartCoroutine(SpawnMenuItems());
        }
    }

    private IEnumerator SpawnMenuItems()
    {
        bool isLeft = true;
        foreach (var saleItem in _saleItems.Items)
        {
            var menuItem = Instantiate(MenuItemPrefab, isLeft ? LeftColumn : RightColumn);
            var childCount = LeftColumn.childCount;

            LeftColumn.sizeDelta = new Vector2(308, childCount * 129);
            RightColumn.sizeDelta = new Vector2(308, RightColumn.childCount * 129);
            ContentRoot.sizeDelta = new Vector2(640, childCount * 129);

            isLeft = !isLeft;
            var menuItemUI = menuItem.GetComponent<MenuItemUI>();
            menuItemUI.Init(saleItem);
            yield return null;
        }
    }
}
