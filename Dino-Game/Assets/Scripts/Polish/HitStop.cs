using UnityEngine;
using System.Collections;

public class HitStop : MonoBehaviour
{
    public static HitStop Instance;



    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Player.Instance.OnDeath += Player_OnDeath;
    }

    private void Player_OnDeath(object sender, System.EventArgs e)
    {
        Stop(.7f);
    }

   

    public void Stop(float duration)
    {
        StartCoroutine(DoStop(duration));
    }

    IEnumerator DoStop(float duration)
    {
        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(duration);

        Time.timeScale = 1f;
    }

}
