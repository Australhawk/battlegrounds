using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Invector.CharacterController;
public class PlayerStats : MonoBehaviour {

    private Slider hungerSlider;
    private Slider sanitySlider;
    public float maxHunger = 100;
    public float hungerLossRate = 0.1f;
    public float lifeLossByHungerRate = 10f;
    public float maxSanity = 100;
    private vThirdPersonController playerController;
    private vHUDController hud;
    private float currentHunger;
    private float currentSanity;
    private bool startedCoroutines = false;
	// Use this for initialization
	void Start () {
        // SET MAX HUNGER
        currentHunger = maxHunger;
        currentSanity = maxSanity;

        //SET SLIDERS
        hungerSlider = GameObject.Find("hunger").GetComponent<Slider>();
        sanitySlider = GameObject.Find("sanity").GetComponent<Slider>();

        

        // GET CONTROLLER
        playerController = GetComponent<vThirdPersonController>();
        // GET HUD
        hud = GameObject.FindObjectOfType<vHUDController>();

    }
    private void FixedUpdate()
    {
        if (GameManager.instance.gameStarted && !startedCoroutines)
        {
            startedCoroutines = true;
            // Coroutines
            StartCoroutine(HungerLoss());
        }
    }
    private IEnumerator HungerLoss()
    {
        while (currentHunger > 0.0)
        {
            yield return new WaitForSecondsRealtime(1);
            currentHunger -= hungerLossRate;
            SetHunger(currentHunger);

        }
        while (currentHunger <= 0.0 && playerController.currentHealth > 0)
        {
            yield return new WaitForSecondsRealtime(1);
            //IF DURING WAIT HUNGER WAS SATISFIED
            if (currentHunger <= 0.0)
            {
                vDamage damage = new vDamage(Mathf.RoundToInt(lifeLossByHungerRate));
                playerController.TakeDamage(damage);
            }

        }
        Debug.Log("Dead");
    }
    public void SetHunger(float hunger)
    {
        currentHunger = Mathf.Clamp(hunger, 0, maxHunger);
        if (hungerSlider)
        {
            hungerSlider.value = hunger;
        }
    }
    public void AddHunger(int hunger)
    {
        currentHunger += hunger;
        currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);
        SetHunger(Mathf.CeilToInt(currentHunger));
    }
    public void SetSanity(int sanity)
    {
        currentSanity = Mathf.Clamp(sanity, 0, maxSanity);
        if (sanitySlider)
        {
            sanitySlider.value = sanity;
        }
    }
    public void AddSanity(int sanity)
    {
        currentSanity += sanity;
        currentSanity = Mathf.Clamp(currentSanity, 0, maxSanity);
        SetSanity(Mathf.CeilToInt(currentSanity));
    }
}
