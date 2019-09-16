using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    /// <summary>
    /// This is an enum of the various possible weapons types.
    /// It also includes a "shield" type to allow a shield power-up.
    /// Items marked [NI] are Not Implemented in the IGDPD book.
    /// </summary>

    public enum WeaponType
    {
        none, //default, no weapon
        blaster, //simple blaster gun
        spread, //two shots simultaneously
        phaser, //[NI] shots that move in waves
        VenezualanPoodleMoth, //[NI]creepy homing insect
        laser, //[NI] Damage over time
        shield, //raise shieldLevel
    }

    /// <summary>
    /// The WeaponDefinition class allows you to set the properties  
    /// of a specific weapon in the Inspector.  The Main class has
    /// an array of WeaponDefinitions that makes this possible.
    /// </summary>

    [System.Serializable]
    public class WeaponDefinition
    {
        public WeaponType type = WeaponType.none;
        public string letter; //letter to show on the power-up
        public Color color = Color.white;
        public GameObject projectilePrefab;
        public GameObject VPM;
        public Color projectileColor = Color.white;
        public float damageOnHit = 0;
        public float continuousDamage = 0; //damage per second
        public float delayBetweenShots = 0;
        public float velocity = 20; //speed of projectiles
    }

public class Weapon : MonoBehaviour
{
    static public Transform PROJECTILE_ANCHOR;

    [Header("Set Dynamically")]
    [SerializeField]
    private WeaponType _type = WeaponType.none;
    public WeaponDefinition def;
    public GameObject collar;
    public float lastShotTime;
    private Renderer collarRend;

    // Start is called before the first frame update
    void Start()
    {
        collar = transform.Find("Collar").gameObject;
        collarRend = collar.GetComponent<Renderer>();

        //Call SetType() for the default _type of WeaponType.none
        SetType(_type);

        //dynamically create an anchor for all projectiles
        if (PROJECTILE_ANCHOR == null)
        {
            GameObject go = new GameObject("_ProjectileAnchor");
            PROJECTILE_ANCHOR = go.transform;
        }

        //find the firedelegate of the root gameobject
        GameObject rootGO = transform.root.gameObject;
        if (rootGO.GetComponent<Hero>() != null)
        {
            rootGO.GetComponent<Hero>().fireDelegate += Fire;
        }

    }

    public WeaponType type
    {
        get { return (_type); }
        set { SetType(value); }
    }

    public void SetType(WeaponType wt)
    {
        _type = wt;
        if (type == WeaponType.none)
        {
            this.gameObject.SetActive(false);
            return;
        }
        else
        {
            this.gameObject.SetActive(true);
        }
        def = Main.GetWeaponDefinition(_type);
        collarRend.material.color = def.color;
        lastShotTime = 0;
    }

    public void Fire()
    {
        if (!gameObject.activeInHierarchy) return;
        if (Time.time - lastShotTime < def.delayBetweenShots)
        {
            return;
        }

        Projectile p;
        Vector3 vel = Vector3.up * def.velocity;
        if (transform.up.y < 0)
        {
            vel.y = -vel.y;
        }
        switch (type)
        {
            case WeaponType.blaster:
                p = MakeProjectile();
                p.rigid.velocity = vel;
                break;

            case WeaponType.spread:
                p = MakeProjectile();
                p.rigid.velocity = vel;
                p = MakeProjectile();
                p.transform.rotation = Quaternion.AngleAxis(10, Vector3.back);
                p.rigid.velocity = p.transform.rotation * vel;
                p = MakeProjectile();
                p.transform.rotation = Quaternion.AngleAxis(-10, Vector3.back);
                p.rigid.velocity = p.transform.rotation * vel;
                break;

            case WeaponType.VenezualanPoodleMoth:
                p = MakeProjectile();
                p.rigid.velocity = vel;
                break;

        }

    }

    public Projectile MakeProjectile()
    {
        if (type == WeaponType.VenezualanPoodleMoth)
        {
            GameObject go = Instantiate<GameObject>(def.VPM);
            if (transform.parent.gameObject.tag == "Hero")
            {
                go.tag = "ProjectileHero";
                go.layer = LayerMask.NameToLayer("ProjectileHero");
            }
            else
            {
                go.tag = "ProjectileEnemy";
                go.layer = LayerMask.NameToLayer("ProjectileEnemy");
            }
            // go.transform.position = collar.transform.position;
            go.transform.SetParent(PROJECTILE_ANCHOR, true);
            Projectile p = go.GetComponent<Projectile>();
            p.type = type;
            return (p);
        }
        else
        {
            GameObject go = Instantiate<GameObject>(def.projectilePrefab);
            if (transform.parent.gameObject.tag == "Hero")
            {
                go.tag = "ProjectileHero";
                go.layer = LayerMask.NameToLayer("ProjectileHero");
            }
            else
            {
                go.tag = "ProjectileEnemy";
                go.layer = LayerMask.NameToLayer("ProjectileEnemy");
            }
            go.transform.position = collar.transform.position;
            go.transform.SetParent(PROJECTILE_ANCHOR, true);
            Projectile p = go.GetComponent<Projectile>();
            p.type = type;
            lastShotTime = Time.time;
            return (p);
        }
    }
}
    

    

