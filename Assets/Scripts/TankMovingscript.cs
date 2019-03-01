﻿using UnityEngine;
using UnityEngine.UI;
public class TankMovingscript : MonoBehaviour
{

    public float hor, vert, speed, RotationSpeed, hp, ZZ, timer_repare;
    int counter = 0;
    int ammo = 0;
    bool pule;
    Rigidbody rb, rbt, rbtur;
    public GameObject bullet, gun, Pula, bullet1, gunTurret, Scope1;
    public TowerScript tower;
    public GameObject[] steam;
    public AudioClip Shoot, ShootGun;
    public Camera[] cam;
    float reloadtimer, acseleration, angles = 0, reloadtimergun;

    AudioSource sour;
    public Text scoreText,AdviceText;
    public Image img, reload, Tank_HP, Turret_HP,Healing;
    public TMPro.TextMeshProUGUI bullets;

    int score = 0;
    int total;
    float rotationXNorm = 0f;
    // Use this for initialization
    void Start()
    {
        total = GameObject.FindGameObjectsWithTag("Tom").Length;
        img.enabled = false;
        rb = GetComponent<Rigidbody>();
        rbt = tower.turret_rigidbody;
        rbtur = GetComponent<Rigidbody>();
        speed = 20;
        RotationSpeed = 44;
        hp = 400;
        ZZ = 2;
        acseleration = 1;

        for (int i = 0; i < 2; i++)
        {
            steam[i].SetActive(true);
        }
        pule = false;
        sour = GetComponent<AudioSource>();
        Scope1.SetActive(false);
        AdviceText.enabled = false;
        Pula.transform.localEulerAngles.Set(0, 0, 0);
        ammo = 34;
        Healing.enabled=false;

        timer_repare = 0;
        Healing.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score = total - GameObject.FindGameObjectsWithTag("Tom").Length;
        reloadtimer -= Time.deltaTime;
        reloadtimergun -= Time.deltaTime;
        bullets.text = ammo.ToString();
        reload.fillAmount = 1 - (reloadtimer / 3);
        Tank_HP.fillAmount = hp / 400;
        Turret_HP.fillAmount = tower.hp / 150;
        
        if(tower.hp <= 0)
        {
           if(Input.GetKey(KeyCode.F))
            {
                timer_repare += Time.deltaTime;
            }
            if(timer_repare >= 3f)
            {
                Healing.enabled = true;
                Healing.fillAmount += Time.deltaTime;
            }
            if (Healing.fillAmount >= 1)
            {
                tower.hp += 75;
                timer_repare = 0f;
                Healing.fillAmount = 0;
                Healing.enabled = false;
            }
        }
        if (score == total)
        {
            img.enabled = true;
            print("You win");
            Time.timeScale = 0;
        }
        acseleration = 1;
        if (reload.fillAmount == 1)
        {
            reload.enabled = false;

        }
        if (Input.GetMouseButtonDown(0) && reloadtimer < 0 && ammo > 0 && tower.hp>0)
        {
            Instantiate(bullet, gun.transform.position, tower.transform.rotation);
            reloadtimer = 3;
            ammo--;
            sour.PlayOneShot(Shoot, 1f);
            reload.enabled = true;
            reload.fillAmount = 0;
        }
        if (Input.GetKey(KeyCode.Space) && reloadtimergun < 0 && tower.hp >0)
        {
            GameObject lox = Instantiate(bullet1, gunTurret.transform.position, gunTurret.transform.rotation);

            Destroy(lox, 5);
            reloadtimergun = 0.1f;
            sour.PlayOneShot(ShootGun, 1f);

        }
        while (Input.GetKey(KeyCode.W) && acseleration < 5)
        {

            acseleration += 0.05f;


        }


        scoreText.text = "Killed tomashevws   " + score + "  out of  " + total;


        if (pule)
        {

            if (Input.GetKeyDown(KeyCode.LeftShift) && counter == 0)
            {
                Scope1.SetActive(true);

                cam[1].fieldOfView -= 10f;
                counter++;

            }
            else if (Input.GetKeyDown(KeyCode.LeftShift) && counter == 1)
            {
                Scope1.SetActive(false);
                cam[1].fieldOfView += 10f;
                counter--;

            }
        }


    }
    void FixedUpdate()
    {

        hor = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        rb.transform.Translate(Vector3.forward * Time.fixedDeltaTime * -vert * speed * acseleration);
        rb.transform.Rotate(Vector2.up * Time.fixedDeltaTime * RotationSpeed * hor, Space.World);



        if (tower.hp > 0)
        {
            rbt.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * 15);
            float rotationY = Input.GetAxis("Mouse Y");
            float rotationX = Input.GetAxis("Mouse X");
            rotationXNorm += rotationY * 15 * Time.deltaTime;
            rotationXNorm = Mathf.Clamp(rotationXNorm, -15, 45);
            Pula.transform.localEulerAngles = new Vector3(rotationXNorm, Pula.transform.localEulerAngles.y, Pula.transform.localEulerAngles.z);


        }





        if (Input.GetKeyDown(KeyCode.V))
        {
            if (!pule)
            {
                cam[0].enabled = false;
                cam[1].enabled = true;
                pule = true;
                return;
            }

            if (pule)
            {
                cam[0].enabled = true;
                cam[1].enabled = false;
                pule = false;

                return;
            }
        }

        if (Input.GetKey(KeyCode.Keypad6))
        {
            tower.transform.Rotate(Vector2.up * Time.fixedDeltaTime * 15);


        }
        if (Input.GetKey(KeyCode.Keypad4))
        {
            tower.transform.Rotate(Vector2.up * Time.fixedDeltaTime * -15);


        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Ammo"))
        {
            ammo += 15;
            Destroy(other.gameObject);
        }
    }

}

