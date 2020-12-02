using System.Collections;
using System.Collections.Generic;
using Models;
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

    private List<SaleItem> _saleItems;

    public void AddItem(SaleItem item)
    {

    }

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(LoadItems());
    }

    private IEnumerator LoadItems()
    {
        string url = "";

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
            _saleItems = JsonUtility.FromJson<List<SaleItem>>(jsonData);
        }
    }
}
