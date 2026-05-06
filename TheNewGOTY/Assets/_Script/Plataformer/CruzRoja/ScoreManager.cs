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
        int multiplier = 1;

        // Buscar el jugador y ver si tiene doble puntaje activo
        PlayerPowerUps player = FindObjectOfType<PlayerPowerUps>();
        if (player != null && player.doubleScoreActive)
        {
            multiplier = 2;
        }

        switch (type)
        {
            case ItemType.Water:
                water += 1 * multiplier;
                break;

            case ItemType.Bone:
                bones += 1 * multiplier;
                break;

            case ItemType.Supply:
                supplies += 1 * multiplier;
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

