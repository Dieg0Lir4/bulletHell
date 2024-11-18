using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab1;
    public GameObject disparador1;
    private float currentAngle1 = 0f;     
    public float fireRate1 = 40f;
    public float patronSpeed1 = 9f;
    public float patronRadio1 = 5f;

    public GameObject bulletPrefab2;
    public GameObject disparador2;
    public GameObject disparador21;
    private float currentAngle2 = 0f;
    public float fireRate2 = 20f;
    public float patronSpeed2 = 5f;

    public GameObject bulletPrefab3;
    public GameObject disparador3;
    public float fireRate3 = 20f;
    public float patronSpeed3 = 5f;


    public bool usePattern1 = false;  // Activar/desactivar patrones
    public bool usePattern2 = false;
    public bool usePattern3 = false;
    
    
    public Vector3 centorDelPatron1 = Vector3.zero;
    public Vector3 centorDelPatron2 = Vector3.zero;

    private float timeSinceLastShot1 = 0f; // Controla el tiempo entre disparos
    private float timeSinceLastShot2 = 0f;
    private float timeSinceLastShot3 = 0f;



    private void Update()
    {
       
        SpawnBullet();

    }

    private void SpawnBullet()
    {
        timeSinceLastShot1 += Time.deltaTime;
        timeSinceLastShot2 += Time.deltaTime;
        timeSinceLastShot3 += Time.deltaTime;


        if (usePattern1 && timeSinceLastShot1 >= 1 / fireRate1)
        {
            Patron1();
            timeSinceLastShot1 = 0;
        }

        if (usePattern2 && timeSinceLastShot2 >= 1 / fireRate2)
        {
            Patron2();
            timeSinceLastShot2 = 0;
        }

        if (usePattern3 && timeSinceLastShot3 >= 1 / fireRate3)
        {
            Patron3();
            timeSinceLastShot3 = 0;
        }

        
    }


    private void Patron1()
    {
        currentAngle1 += patronSpeed1 * Time.deltaTime;
        Vector3 direction = new Vector3(Mathf.Cos(currentAngle1) * patronRadio1, 0, Mathf.Sin(currentAngle1) * patronRadio1);
        disparador1.transform.position = direction + centorDelPatron1;

        GameObject bullet = Instantiate(bulletPrefab1, disparador1.transform.position, Quaternion.identity);
    }

    private void Patron2()
    {
        currentAngle2 += Time.deltaTime * patronSpeed2;
        float posX = Mathf.Sin(currentAngle2) * 6f + centorDelPatron2.x;
        float posZ = posX * -1 + centorDelPatron2.z;

        Vector3 direction = new Vector3(posX, disparador2.transform.position.y, posZ);
       
        disparador2.transform.position = direction;

        GameObject bullet = Instantiate(bulletPrefab2, disparador2.transform.position, disparador2.transform.rotation);

        currentAngle2 += Time.deltaTime * patronSpeed2;
        float posX1 = Mathf.Sin(currentAngle2) * -6f + centorDelPatron2.x * -1;
        float posZ1 = posX1 + centorDelPatron2.z;

        Vector3 direction21 = new Vector3(posX1, disparador21.transform.position.y, posZ1);

        disparador21.transform.position = direction21;

        GameObject bullet21 = Instantiate(bulletPrefab2, disparador21.transform.position, disparador21.transform.rotation);

    }

    private void Patron3()
    {
        GameObject bullet = Instantiate(bulletPrefab3, disparador3.transform.position, disparador3.transform.rotation);
    }
}
