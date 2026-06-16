using UnityEngine;
using UnityEngine.UI;

public class EnemySlider : MonoBehaviour
{
    public Slider healthSlider;
    public CharacterRespawn Boss;

    void Start()
    {
        EnemySlider.maxValue = Boss.maxHealth;
        EnemySlider.value = Boss.BossHealth;
    }

    void Update()
    {
        EnemySlider.value = Boss.BossHealth;
    }
}