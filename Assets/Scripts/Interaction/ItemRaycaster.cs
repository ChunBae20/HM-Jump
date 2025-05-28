using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemRaycaster : MonoBehaviour
{
    public Camera cam; // 플레이어 카메라
    public float rayDistance = 5f; // 레이 거리
    public LayerMask itemLayer; // 아이템 전용 레이어

    public GameObject uiPanel; // UI 패널

    public GameObject currentTarget; //현재 레이가 어떤 오브젝트를 감지하는지(아이템 사용)

    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI itemDescText;

    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // 정중앙
        RaycastHit hit;

        // 레이 시각화 (디버그용)
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);

        if (Physics.Raycast(ray, out hit, rayDistance, itemLayer)) //적용안될시 ,itemLayr해보면됨
        {

            //

            Debug.Log("Ray hit: " + hit.collider.name); // 레이 맞은 오브젝트 이름 출력 (디버그용)

            ItemHolder holder = hit.collider.GetComponent<ItemHolder>();
            if (holder != null && holder.itemData != null)
            {
                ShowItemInfo(holder.itemData);
                currentTarget = hit.collider.gameObject; //현재 파괴가능 오브젝트 (아이템 사용)

                return;
            }

        }

        else
        {
            currentTarget = null; //레이 안맞으면 파괴가능 해제 (아이템 사용)
        }

        HideItemInfo();
    }

    void ShowItemInfo(ItemSo data)
    {
        uiPanel.SetActive(true);
        itemNameText.text = data.ItemName;
        itemDescText.text = data.ItemDescription;
    }

    void HideItemInfo()
    {
        uiPanel.SetActive(false);
    }
}
