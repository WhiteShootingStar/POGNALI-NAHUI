using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankMovingscript : MonoBehaviour {

public float hor, vert, speed, RotationSpeed,hp,ZZ;
    int counter = 0;
    bool  pule;
Rigidbody rb, rbt,rbtur;
    public GameObject tower, bullet, gun, Pula, bullet1, gunTurret, Scope1;
public GameObject[] steam;
    public AudioClip Shoot,ShootGun;
public Camera[] cam;
float reloadtimer, acseleration, angles=0,reloadtimergun;
   
    AudioSource sour;
  public   Text scoreText;
   public  Image img;
     int score = 0;
    int total;
    float rotationXNorm = 0f;
    // Use this for initialization
    void Start () {
        total = GameObject.FindGameObjectsWithTag("Tom").Length;
        img.enabled =false;
          rb = GetComponent<Rigidbody>();
	rbt = tower.GetComponent<Rigidbody>();
        rbtur = GetComponent<Rigidbody>();
	speed =20;
	RotationSpeed =44;
	hp=1;
	ZZ=2;
		acseleration=1;
        
		for(int i =0; i <2; i++){
			steam[i].SetActive(true);
		}
		pule =false;
        sour = GetComponent<AudioSource>();
        Scope1.SetActive(false);

        Pula.transform.localEulerAngles.Set(0, 0, 0);




       
	}
	
	// Update is called once per frame
	void Update () {
        score =total - GameObject.FindGameObjectsWithTag("Tom").Length;
        reloadtimer -=Time.deltaTime;
        reloadtimergun -= Time.deltaTime;

        if(score == total)
        {
            img.enabled = true;
            print("You win");
            Time.timeScale = 0;
        }
	acseleration=1;
	if(Input.GetMouseButtonDown(0) && reloadtimer <0){
		Instantiate (bullet,gun.transform.position, tower.transform.rotation);
		reloadtimer =3;
            /*Vector3 vec = new Vector3 (gun.transform.position.x,gun.transform.position.y,gun.transform.position.z);
            rb.AddForce(5*vec, ForceMode.Impulse);
            rb.AddRelativeForce(gun.transform.position.x,gun.transform.position.y,750, ForceMode.Impulse);*/
          sour.PlayOneShot(Shoot, 1f);
        }
        if (Input.GetKey(KeyCode.Space) && reloadtimergun < 0)
        { GameObject lox = Instantiate(bullet1, gunTurret.transform.position, gunTurret.transform.rotation);
            
           Destroy( lox,5);
            reloadtimergun = 0.1f;
           sour.PlayOneShot(ShootGun, 1f);

        }
	while(Input.GetKey(KeyCode.W) && acseleration < 5)
        {
	 
	acseleration+= 0.05f;
	
	/*drive=true;
	while(drive){
	for(int i =0; i <2; i++){
	steam[i].SetActive(true);}
		drive =false;
		}
		while(!drive){
		for(int i =0; i <2; i++){
	steam[i].SetActive(false);}
		drive =true;
		
	}*/
	}


        scoreText.text = "Killed tomashevws-pidors   " + score + "  out of  " + total;



        if (pule )
        {
            
            if (Input.GetKeyDown(KeyCode.LeftShift) && counter ==0)
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
    void FixedUpdate() {

        hor = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        rb.transform.Translate(Vector3.forward * Time.fixedDeltaTime * -vert * speed * acseleration);
        rb.transform.Rotate(Vector2.up * Time.fixedDeltaTime * RotationSpeed * hor, Space.World);



        rbt.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * 15);

        /*
                Vector3 angle = Pula.transform.localEulerAngles;
                angle.x = Mathf.Clamp(angle.x + Time.deltaTime * 20, -15.0f, 40.0f);
                Pula.transform.localEulerAngles = angle;*/



        /*  if ((Pula.transform.rotation.x < 0.43)  && (Pula.transform.rotation.x > -0.2))
          {
              // Pula.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), 0, 0) * Time.deltaTime * 15,Space.Self);
              Pula.transform.localEulerAngles = new Vector3(Input.GetAxis("Mouse Y"), 0, 0) * Time.deltaTime * 15;
          }
         if(Pula.transform.rotation.x > 0.43 || Pula.transform.rotation.x < -0.20)
          {
              //  Pula.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), 0, 0) * Time.deltaTime * -15,Space.Self);
              Pula.transform.localEulerAngles = new Vector3(Input.GetAxis("Mouse Y"), 0, 0) * Time.deltaTime * -15;

          }*/

        // Pula.transform.localEulerAngles = new Vector3(Input.GetAxis("Mouse Y")*20, 0, 0) * Time.deltaTime * 15;
        float rotationY = Input.GetAxis("Mouse Y");
        float rotationX = Input.GetAxis("Mouse X");
        rotationXNorm += rotationY * 15*Time.deltaTime;
        rotationXNorm = Mathf.Clamp(rotationXNorm, -15, 45);
        Pula.transform.localEulerAngles = new Vector3(rotationXNorm, Pula.transform.localEulerAngles.y, Pula.transform.localEulerAngles.z);

      //   float kek = Pula.transform.rotation.x;
   
      //  print(Pula.transform.localEulerAngles);
        /*  if (kek > 30)
          {
              kek = 30;
          }
          if (kek < -30)
          {
             kek = -30;
          }
          Pula.transform.Rotate(new Vector3(kek, 0, 0) * Time.deltaTime * 15);*/
        // Pula.transform.rotation.y = Mathf.Clamp(Pula.transform.rotation.y, -30, 30);
        //Pula.transform.eulerAngles = new Vector3(Input.GetAxis("Mouse Y"), 0, 0);






        if (Input.GetKeyDown(KeyCode.V)){
		if(!pule){
		cam[0].enabled=false;
		cam[1].enabled=true;
		pule=true;
		return;
		}
		
		if(pule){
		cam[0].enabled=true;
		cam[1].enabled=false;
		pule=false;
              
                return;
		}
	}
        // Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        //new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z)

        /* Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 diff = mousepos - transform.position;
            diff.Normalize();
            float rot_y = Mathf.Atan2(diff.z, diff.x) * Mathf.Rad2Deg;
           tower.transform.rotation = Quaternion.Lerp(tower.transform.rotation, Quaternion.Euler(0f, rot_y-90, 0f), Time.fixedDeltaTime*2);*/

        // Vector3 mousepos = Input.mousePosition;
        if (Input.GetKey(KeyCode.Keypad6))
        {
            tower.transform.Rotate(Vector2.up * Time.fixedDeltaTime * 15);


        }
        if (Input.GetKey(KeyCode.Keypad4))
        {
            tower.transform.Rotate(Vector2.up * Time.fixedDeltaTime * -15);


        }
       /* if (Input.GetKey(KeyCode.Keypad8) && angles <= 90)
        {
            Pula.transform.Rotate(Vector3.right * Time.fixedDeltaTime * 30);

            angles++;

        }
        if (Input.GetKey(KeyCode.Keypad2) && angles >= -45)
        {
            Pula.transform.Rotate(Vector3.right * Time.fixedDeltaTime * -30);

            angles--;

        }*/
    }


	}

