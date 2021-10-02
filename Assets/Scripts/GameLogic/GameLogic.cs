using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic 
{
    private SoundEventSystem soundChanel;

    public GameLogic(SoundEventSystem iniSoundChanel)
    {
        soundChanel = iniSoundChanel;
    }
    public void UpdateGameLogic()
    {
        
    }

    public void CollectHuman ()
    {
        // Set ppl count ++
    }

    public void SaveHuman ()
    {
        // Set scorecount += ppl count
        // Set ppl count to 0
    }

    public void SacrificeHuman ()
    {
        // Set time += amount of time * ppl count
        // Set ppl count to 0
    }

    public void Update ()
    {
        // If(time =< 0) -> CallErrorScreen(scorecount)
        //
    }
}
