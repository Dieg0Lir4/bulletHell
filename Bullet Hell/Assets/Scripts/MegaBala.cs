using UnityEngine;

public class MegaBala : MonoBehaviour
{
    public GameObject bala;
    public float fireRated = 5f;
    private float timePassed = 0f;
    public float speedRotation = 5;

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed > 1 / fireRated)
        {
            GameObject bullet = Instantiate(bala, transform.position, transform.rotation);

            timePassed = 0f;
        }

        transform.Rotate(0f, transform.rotation.y + speedRotation, 0f);
        
    }
}
