using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager
{
    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioName, AudioClip> audioClips =
        new Dictionary<AudioName, AudioClip>();

    /// <summary>
    /// Gets whether or not the audio manager has been initialized
    /// </summary>
    public static bool Initialized
    {
        get { return initialized; }
    }
    /// <summary>
    /// Initializes the audio manager
    /// </summary>
    /// <param name="source">audio source</param>
    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;
        audioClips.Add(AudioName.BallCollision,
            Resources.Load<AudioClip>("BallCollision"));
        audioClips.Add(AudioName.BallLost,
            Resources.Load<AudioClip>("BallLost"));
        audioClips.Add(AudioName.BallSpawn,
            Resources.Load<AudioClip>("BallSpawn"));
        audioClips.Add(AudioName.FreezerEffectActivated,
            Resources.Load<AudioClip>("FreezerEffectActivated"));
        audioClips.Add(AudioName.FreezerEffectDeactivated,
            Resources.Load<AudioClip>("FreezerEffectDeactivated"));
        audioClips.Add(AudioName.GameLost,
            Resources.Load<AudioClip>("GameLost"));
        audioClips.Add(AudioName.MenuButtonClick,
            Resources.Load<AudioClip>("MenuButtonClick"));
        audioClips.Add(AudioName.SpeedupEffectActivated,
            Resources.Load<AudioClip>("SpeedupEffectActivated"));
        audioClips.Add(AudioName.SpeedupEffectDeactivated,
            Resources.Load<AudioClip>("SpeedupEffectDeactivated"));
    }

    /// <summary>
    /// Plays the audio clip with the given name
    /// </summary>
    /// <param name="name">name of the audio clip to play</param>
    public static void Play(AudioName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }
}
