using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System;
using UnityEngine;

public class Hovl_Laser : MonoBehaviour
{
    public int damageOverTime = 30;

    public GameObject HitEffect;
    public float HitOffset = 0;
    public bool useLaserRotation = false;

    public float MaxLength;
    public float Width = 0.5f;
    

    public float MainTextureLength = 1f;
    public float NoiseTextureLength = 1f;

    public bool bPenetrate = false;

    private LineRenderer Laser;
    private Vector4 Length = new Vector4(1,1,1,1);
    //private Vector4 LaserSpeed = new Vector4(0, 0, 0, 0); {DISABLED AFTER UPDATE}
    //private Vector4 LaserStartSpeed; {DISABLED AFTER UPDATE}
    //One activation per shoot
    private bool LaserSaver = false;
    private bool UpdateSaver = false;

    private ParticleSystem[] Effects;
    private ParticleSystem[] Hit;

    void Start ()
    {
        //Get LineRender and ParticleSystem components from current prefab;  
        Laser = GetComponent<LineRenderer>();
        Effects = GetComponentsInChildren<ParticleSystem>();
        Hit = HitEffect.GetComponentsInChildren<ParticleSystem>();

        Laser.startWidth = Width;  // 시작 부분 너비
        Laser.endWidth = Width; 

        if(bPenetrate) PenetrateLaser();
        //if (Laser.material.HasProperty("_SpeedMainTexUVNoiseZW")) LaserStartSpeed = Laser.material.GetVector("_SpeedMainTexUVNoiseZW");
        //Save [1] and [3] textures speed
        //{ DISABLED AFTER UPDATE}
        //LaserSpeed = LaserStartSpeed;
    }

    void Update()
    {
        //if (Laser.material.HasProperty("_SpeedMainTexUVNoiseZW")) Laser.material.SetVector("_SpeedMainTexUVNoiseZW", LaserSpeed);
        //SetVector("_TilingMainTexUVNoiseZW", Length); - old code, _TilingMainTexUVNoiseZW no more exist
        // Laser.material.SetTextureScale("_MainTex", new Vector2(Length[0], Length[1]));                    
        // Laser.material.SetTextureScale("_Noise", new Vector2(Length[2], Length[3]));
        
        if(!bPenetrate) NormalLaser();
        //To set LineRender position
        
    }

    void PenetrateLaser()
    {
        if (Laser == null ) return;
        
        Laser.SetPosition(0, transform.position);
                
        //End laser position if doesn't collide with object
        var EndPos = transform.position + transform.forward * MaxLength;
        Laser.SetPosition(1, EndPos);
        HitEffect.transform.position = EndPos;
        
        foreach (var AllPs in Effects)
        {
            if (!AllPs.isPlaying) AllPs.Play();
        }
    }

    void NormalLaser()
    {
        if (Laser == null || UpdateSaver != false) return;
        
        Laser.SetPosition(0, transform.position);
        RaycastHit hit; //DELETE THIS IF YOU WANT USE LASERS IN 2D
            //ADD THIS IF YOU WANNT TO USE LASERS IN 2D: RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, MaxLength);       
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, MaxLength))//CHANGE THIS IF YOU WANT TO USE LASERRS IN 2D: if (hit.collider != null)
        {
                //End laser position if collides with object
            Laser.SetPosition(1, hit.point);

            HitEffect.transform.position = hit.point + hit.normal * HitOffset;

            if (useLaserRotation)
                HitEffect.transform.rotation = transform.rotation;
            else
                HitEffect.transform.LookAt(hit.point + hit.normal);

            foreach (var AllPs in Effects)
            {
                if (!AllPs.isPlaying) AllPs.Play();
            }
        }
    
        else
        {
            //End laser position if doesn't collide with object
            var EndPos = transform.position + transform.forward * MaxLength;
            Laser.SetPosition(1, EndPos);
            HitEffect.transform.position = EndPos;
            foreach (var AllPs in Hit)
            {
                if (AllPs.isPlaying) AllPs.Stop();
            } 
        }

        if (Laser.enabled == false && LaserSaver == false)
        {
            LaserSaver = true;
            Laser.enabled = true;
        }
        
    }

    public void DisablePrepare()
    {
        if (Laser != null)
        {
            Laser.enabled = false;
        }
        UpdateSaver = true;
        //Effects can = null in multiply shooting
        if (Effects != null)
        {
            foreach (var AllPs in Effects)
            {
                if (AllPs.isPlaying) AllPs.Stop();
            }
        }
    }
}
