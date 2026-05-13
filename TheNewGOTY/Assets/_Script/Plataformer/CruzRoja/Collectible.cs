using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum CollectibleType
    {
        Water,
        Bone,
        Supply,
        DoubleJump,
        JumpBoost,
        SavePoint,
        DoubleScore
    }

    public CollectibleType type;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Funciona");
        Debug.Log(type);
        if (!other.CompareTag("Player")) return;

        PlayerPowerUps powerUps = other.GetComponent<PlayerPowerUps>();

        switch (type)
        {
            // -------- RECURSOS --------
            case CollectibleType.Water:
                ScoreManager.instance.AddItem(ItemType.Water);
                break;

            case CollectibleType.Bone:
                ScoreManager.instance.AddItem(ItemType.Bone);
                break;

            case CollectibleType.Supply:
                ScoreManager.instance.AddItem(ItemType.Supply);
                break;

            // -------- POWER UPS --------
            case CollectibleType.DoubleJump:
                powerUps.ActivateDoubleJump();
                break;

            case CollectibleType.JumpBoost:
                powerUps.ActivateJumpBoost();
                break;

            case CollectibleType.DoubleScore:
                powerUps.ActivateDoubleScore();
                break;

            case CollectibleType.SavePoint:
                powerUps.SavePosition();
                break;
        }
        Destroy(gameObject);
    }
}