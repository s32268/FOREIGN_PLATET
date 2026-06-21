using UnityEngine;
using UnityEngine.UI;

public class HealthSlider2 : MonoBehaviour
{
    public Slider healthSlider;
    public BossHealth boss;

    void Start()
    {
        healthSlider.maxValue = boss.maxHealth;
        healthSlider.value = boss.health;
    }

    void Update()
    {
        healthSlider.value = boss.health;
    }
}