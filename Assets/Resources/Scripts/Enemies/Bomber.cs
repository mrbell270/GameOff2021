using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    [SerializeField]
    Transform shootPoint;
    [SerializeField]
    GameObject bombTemplate;
    [SerializeField]
    float shootPower;

    [SerializeField]
    float shootTimer;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = shootTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = shootTimer;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bomb = Instantiate(bombTemplate, shootPoint);
        bomb.SetActive(true);
        bomb.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Sign(shootPoint.localPosition.x) * shootPower, shootPower));
    }
}
