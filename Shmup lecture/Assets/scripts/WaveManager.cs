using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public Wave[] Waves;
    public float WaveInterval = 10f;

    private IEnumerator PlayWaves()
    {
        foreach (Wave wave in Waves) 
        {
            //wavesound
            //visuals
            foreach (var item in wave.Enemies)
            {
                //instantiate 
                yield return new WaitForSeconds(WaveInterval);
            }
        }
    }

}
