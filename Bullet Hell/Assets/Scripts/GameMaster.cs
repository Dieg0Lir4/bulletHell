using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class GameMaster : MonoBehaviour
{

    public TextMeshProUGUI bulletCounterText; // Arrastra aquí el TextMeshPro en el Inspector
    public TextMeshProUGUI enemyCounterText;
    public TextMeshProUGUI playerLifeText;
    public PlayerMovementAndShooting playerLife;
    public BulletSpawner bulletSpawner;
    public Slider bossHealth;
    public float damagePerSecond = 1f;

    public float currentBossLife = 55f;

    public GameObject Boss;

    public GameObject audioSource;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        ContarBalas();
        ContarEnemigos();

        if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            
            Boss.SetActive(true);
            audioSource.SetActive(true);
            
        }

        if (Boss.activeSelf)
        {
            
            QuitarVidaBoss();
        }

        if (currentBossLife < 15f)
        {
            Boss.SetActive(false);
        }

        if (currentBossLife > 40 && currentBossLife < 50)
        {
            bulletSpawner.usePattern3 = true;
            bulletSpawner.usePattern2 = false;
            bulletSpawner.usePattern1 = false;
        }
        else if(currentBossLife > 30 && currentBossLife < 40)
        {
            bulletSpawner.usePattern3 = false;
            bulletSpawner.usePattern2 = false;
            bulletSpawner.usePattern1 = true;
        }
        else if(currentBossLife > 20 && currentBossLife < 30)
        {
            bulletSpawner.usePattern3 = false;
            bulletSpawner.usePattern2 = true;
            bulletSpawner.usePattern1 = false;
        }
        else
        {
            bulletSpawner.usePattern3 = false;
            bulletSpawner.usePattern2 = false;
            bulletSpawner.usePattern1 = false;
        }


    }

    public void ContarBalas()
    {
        int bulletCount = GameObject.FindGameObjectsWithTag("Bullet").Length;
        bulletCount += GameObject.FindGameObjectsWithTag("playerBullet").Length;

        // Actualizar el texto del TextMeshPro
        bulletCounterText.text = $"Bullets: {bulletCount}";


    }

    public void ContarEnemigos()
    {
        int enemyCounter = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemyCounterText.text = $"Enemies: {enemyCounter}";

        playerLifeText.text = $"Players Life: {playerLife.life}";

    }

    public void QuitarVidaBoss()
    {
        currentBossLife -= damagePerSecond * Time.deltaTime;
        bossHealth.value = currentBossLife;

    }
}
