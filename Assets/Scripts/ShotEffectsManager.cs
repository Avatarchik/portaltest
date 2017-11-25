using UnityEngine;

public class ShotEffectsManager : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] AudioSource gunAudio;
    [SerializeField] GameObject impactPrefab;
    [SerializeField] GameObject portalPrefab;

    ParticleSystem impactEffect;

    //Create the impact effect for our shots
    public void Initialize()
    {
        impactEffect = Instantiate(impactPrefab).GetComponent<ParticleSystem>();
    }

    //Play muzzle flash and audio
    public void PlayShotEffects()
    {
        muzzleFlash.Stop(true);
        muzzleFlash.Play(true);
        gunAudio.Stop();
        gunAudio.Play();
    }

    //Play impact effect and target position
    public void PlayImpactEffect(Vector3 impactPosition)
    {
        var portal = GameObject.Instantiate(portalPrefab);
        portal.transform.position = impactPosition;
        //impactEffect.transform.position = impactPosition;
        //impactEffect.Stop();
        //impactEffect.Play();
    }
}