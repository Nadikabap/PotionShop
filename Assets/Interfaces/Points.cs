using UnityEngine;

public interface Points
{
    int Points {get; set;}

    private void Modify(int value)
    {
        Points+= value;
    }

    public void SendScore()
    {
        GameObject.Find("Score").GetComponent<Scores>().Modify(Points);
    }
}
