using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int water = 0;
    public int bones = 0;
    public int supplies = 0;

    private void Awake()
    {
        instance = this;
    }

    public void AddItem(ItemType type)
    {
        switch (type)
        {
            case ItemType.Water:
                water++;
                break;

            case ItemType.Bone:
                bones++;
                break;

            case ItemType.Supply:
                supplies++;
                break;
        }

        Debug.Log("Agua: " + water +
                  " Huesos: " + bones +
                  " Suministros: " + supplies);
    }

    public void ResetItems()
    {
        water = 0;
        bones = 0;
        supplies = 0;

        Debug.Log("Items reiniciados");
    }
}

