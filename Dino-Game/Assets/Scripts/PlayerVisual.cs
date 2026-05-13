using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{

    [ColorUsage(true, true)]
    [SerializeField] private Color flashColor = Color.red;
    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private float flashTime = .25f;

    [SerializeField] private SpriteRenderer spriteRenderer;
    private Material material;
    private Coroutine damageFlashCoroutine;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        material = spriteRenderer.material;
    }
    

    private void Start()
    {
        material.SetColor("_FlashColor", flashColor);
        Player.Instance.OnHit += Player_OnHit;
    }

    private void Player_OnHit(object sender, System.EventArgs e)
    {
        CallDamageFlash();
    }

    public void CallDamageFlash()
    {
        damageFlashCoroutine = StartCoroutine(DamageFlasher());
    }

    private IEnumerator DamageFlasher()
    {
        //set the color
        SetFlashColor();
        // lerp the flash amount
        float currentFlashAmount = 0f;
        float elapsedTime = 0f;
        while (elapsedTime < flashTime)
        {
            //iterate elapsed time
            elapsedTime += Time.deltaTime;
            //lerp the flash amount 
            currentFlashAmount = Mathf.Lerp(1f, 0f, (elapsedTime / flashTime));
            SetFlashAmount(currentFlashAmount);
            yield return null;
        }

    }

    private void SetFlashColor()
    {
        material.SetColor("_FlashColor", flashColor);
    }



    private void SetFlashAmount(float amount)
    {
        // Set flash amount 

        material.SetFloat("_FlashAmount", amount);
    }
}
