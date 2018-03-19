using UnityEngine;
using UnityEngine.Networking;

public class Shooting : NetworkBehaviour {

    private const string PLAYER_TAG = "Player"; 

    public PlayerWeapon weapon;    
    [SerializeField]
    private Camera fpsCam;
    public ParticleSystem muzzleFlash;

    [SerializeField]
    private LayerMask mask;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    [Client]
    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, weapon.range, mask))
        {
            if (hit.collider.tag == PLAYER_TAG)
            {
                CmdPlayerShot(hit.collider.name);
            }           
        }
    }
    
    [Command]
    void CmdPlayerShot(string ID)
    {
        Debug.Log(ID + " has been Shot");        
    }
}
