using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    public Slider healthSlider;
    public CharacterRespawn player;

    void Start()
    {
        healthSlider.maxValue = player.maxHealth;
        healthSlider.value = player.currentHealth;
    }

    void Update()
    {
        healthSlider.value = player.currentHealth;
    }
}