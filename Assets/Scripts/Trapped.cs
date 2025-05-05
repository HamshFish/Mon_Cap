using UnityEngine;

public interface Trapped
{
    public bool isBeingTrapped {get; set;}
    public bool CaptureAnim();

    public int Points();
}
