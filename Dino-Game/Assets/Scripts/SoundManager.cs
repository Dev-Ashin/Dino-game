using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance { get; private set; }


    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioSource soundFxObject;
    [SerializeField] private float volume;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        if (Player.Instance)
        {
            Player.Instance.OnJump += Player_OnJump;
        }
        else
        {
            Debug.Log("No Playeeeeeer");
        }
    }

    private void Player_OnJump(object sender, System.EventArgs e)
    {
        PlaySoundEffectsClip(jumpClip, transform, volume);
        Debug.Log("On jump event got");
    }

    public void PlaySoundEffectsClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        // spawn gameobject
        AudioSource audioSource = Instantiate(soundFxObject, spawnTransform.position, Quaternion.identity);
        // assign the audioclip
        audioSource.clip = audioClip;
        // assign volume
        audioSource.volume = volume;
        // play sound
        audioSource.Play();
        // get length of the clip
        float cliplength = audioSource.clip.length;
        //Destroy this game object  
        Destroy(audioSource.gameObject, cliplength);
    }
    public void PlayRandomSoundEffectsClip(AudioClip[] audioClip, Transform spawnTransform, float volume)
    {
        //assign a random index
        int random = Random.Range(0, audioClip.Length);

        // spawn gameobject
        AudioSource audioSource = Instantiate(soundFxObject, spawnTransform.position, Quaternion.identity);
        // assign the audioclip
        audioSource.clip = audioClip[random];
        // assign volume
        audioSource.volume = volume;
        // play sound
        audioSource.Play();
        // get length of the clip
        float cliplength = audioSource.clip.length;
        //Destroy this game object  
        Destroy(audioSource.gameObject, cliplength);
    }
}
