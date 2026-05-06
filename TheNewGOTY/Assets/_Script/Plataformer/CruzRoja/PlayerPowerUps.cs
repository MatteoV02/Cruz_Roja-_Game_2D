using UnityEngine;
using System.Collections;

public class PlayerPowerUps : MonoBehaviour
{
    public bool doubleJumpActive = false;
    public bool jumpBoostActive = false;
    public bool doubleScoreActive = false;

    private Vector3 savedPosition;
    private bool hasSavedPosition = false;

    // -------- DOUBLE JUMP --------
    public void ActivateDoubleJump()
    {
        StartCoroutine(DoubleJumpCoroutine());
    }

    IEnumerator DoubleJumpCoroutine()
    {
        doubleJumpActive = true;
        yield return new WaitForSeconds(5f);
        doubleJumpActive = false;
    }

    // -------- JUMP BOOST --------
    public void ActivateJumpBoost()
    {
        StartCoroutine(JumpBoostCoroutine());
    }

    IEnumerator JumpBoostCoroutine()
    {
        jumpBoostActive = true;
        yield return new WaitForSeconds(5f);
        jumpBoostActive = false;
    }

    // -------- DOUBLE SCORE --------
    public void ActivateDoubleScore()
    {
        StartCoroutine(DoubleScoreCoroutine());
    }

    IEnumerator DoubleScoreCoroutine()
    {
        doubleScoreActive = true;
        yield return new WaitForSeconds(5f);
        doubleScoreActive = false;
    }

    // -------- SAVE POSITION --------
    public void SavePosition()
    {
        savedPosition = transform.position;
        hasSavedPosition = true;
        Debug.Log("Posición guardada");
    }

    public void TeleportToSaved()
    {
        if (hasSavedPosition)
        {
            transform.position = savedPosition;
            hasSavedPosition = false;
            Debug.Log("Teletransportado");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TeleportToSaved();
        }
    }
}