using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Scores
{
    int Score {get; set;}

    public void Modify(int value)
    {
        Score+= value;
    }
}
