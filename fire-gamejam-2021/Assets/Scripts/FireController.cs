using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{

    public float fireIntesity = 0.2f;
    public float fireInitialTime = 20;
    public float fireTimeLeft;
    public float burnOutSpeed = 1;

    [Header("Limits")]
    public float fireLimit1 = 20;
    public float fireLimit2 = 50;
    public float fireLimit3 = 120;
    [Header("Intensity")]
    public float intensity1 = 0.2f;
    public float intensity2 = 0.5f;
    public float intensity3 = 1f;
    public float intensity4 = 2f;
    [Header("Speed")]
    public float speed1 = 1.5f;
    public float speed2 = 1f;
    public float speed3 = 0.5f;
    public float speed4 = 0.2f;

    public ParticleSystem fireAdd;
    public ParticleSystem fireAlpha;

    // Start is called before the first frame update
    void Start()
    {
        fireTimeLeft = fireInitialTime;


    }

    // Update is called once per frame
    void Update()
    {
        UpdateFirePower();

        if(fireTimeLeft > 0) {
            fireTimeLeft -= burnOutSpeed * Time.deltaTime;
        }
    }

    void UpdateFirePower() {
            if(fireTimeLeft<=0) 
            {
                fireIntesity = 0;
                Destroy(gameObject);
                
            } else if(fireTimeLeft<fireLimit1) {
                fireIntesity = intensity1;
                burnOutSpeed = speed1;
                UpdateParticles(fireAdd, fireTimeLeft/100);
                UpdateParticles(fireAlpha, fireTimeLeft/100);
            } else if(fireTimeLeft>fireLimit1 && fireTimeLeft<fireLimit2) {
                fireIntesity = intensity2;
                burnOutSpeed = speed2;
                UpdateParticles(fireAdd, fireTimeLeft/100);
                UpdateParticles(fireAlpha, fireTimeLeft/100);
            }   else if(fireTimeLeft>fireLimit2 && fireTimeLeft<fireLimit3) {
                fireIntesity = intensity3;
                burnOutSpeed = speed3;
                UpdateParticles(fireAdd, fireTimeLeft/100);
                UpdateParticles(fireAlpha, fireTimeLeft/100);
            }   else if(fireTimeLeft>fireLimit3) {
                fireIntesity = intensity4;
                burnOutSpeed = speed4;
                UpdateParticles(fireAdd, fireTimeLeft/100);
                UpdateParticles(fireAlpha, fireTimeLeft/100);
            }
    }

    void UpdateParticles(ParticleSystem ps, float size) {
        ParticleSystem.MainModule psMain = ps.main;
        psMain.startSize = size;
        psMain.startSpeed = size;
    }
}
