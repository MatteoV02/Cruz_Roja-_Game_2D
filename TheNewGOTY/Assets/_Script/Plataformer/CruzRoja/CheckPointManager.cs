using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance;

    private Vector3 respawnPosition;

    private void Awake()
    {
        instance = this;
    }

    public void SetCheckpoint(Vector3 pos)
    {
        respawnPosition = pos;
        Debug.Log("Checkpoint guardado: " + pos);
    }

    public Vector3 GetCheckpoint()
    {
        return respawnPosition;
    }
}