using Assets.Scripts;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
