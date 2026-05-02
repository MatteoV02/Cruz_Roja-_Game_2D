using UnityEngine;

public class CoinAnimation : MonoBehaviour
{

    public Animator _anim;

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        CoinAnim();
    }
    public void CoinAnim()
    {
        if (Input.GetKeyDown(KeyCode.R))
            _anim.SetTrigger("Anim");
    }
}
