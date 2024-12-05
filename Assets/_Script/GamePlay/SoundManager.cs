using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField]
    private AudioSource audioSource1;
    [SerializeField]
    private AudioSource audioSource2;
    [SerializeField]
    private AudioClip bGClip;
    [SerializeField]
    private AudioClip moneyClip;
    [SerializeField]
    private AudioClip openDoorClip;
    [SerializeField]
    private AudioClip closeDoorClip;
    [SerializeField]
    private AudioClip waterMachineClip;
    [SerializeField]
    private AudioClip spawnClip;
    [SerializeField]
    private AudioClip helloClip;
    private void OnEnable()
    {
        instance = this;
    }
    private void OnDisable()
    {
        instance = null;
    }
    private void Awake()
    {
        audioSource1.clip = bGClip;
    }
    public void StartSoundManager()
    {
        StartCoroutine(PlayBGClip());
    }
    IEnumerator PlayBGClip()
    {
        audioSource1.Play();
        while (true)
        {
            yield return new WaitForSeconds(31);
            audioSource1.Play();
        }
    }
    public void SoundSpawnCoffe()
    {
        audioSource2.clip = waterMachineClip;
        audioSource2.Play();
    }
    public void SoundSpawnFood()
    {
        audioSource2.clip = spawnClip;
        audioSource2.Play();
    }
    public void SoundCloseDoor()
    {
        audioSource2.clip = closeDoorClip;
        audioSource2.Play();
    }
    public void SoundOpenDoor()
    {
        audioSource2.clip = openDoorClip;
        audioSource2.Play();
    }
    public void SoundHello()
    {
        audioSource2.clip = helloClip;
        audioSource2.Play();
    }
    public void SoundMoney()
    {
        audioSource2.clip = moneyClip;
        audioSource2.Play();
    }
}
