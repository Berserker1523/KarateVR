using UnityEngine;

public class Position : MonoBehaviour
{
    [SerializeField] private HandTrigger[] handTriggers = new HandTrigger[2];

    public void ChangeActive(bool isActive)
    {
        foreach (HandTrigger handTrigger in handTriggers)
        {
            handTrigger.ChangeStatus(false);
        }

        gameObject.SetActive(isActive);
    }

    public void ChangeColor(bool isWellDone)
    {
        foreach (HandTrigger handTrigger in handTriggers)
            handTrigger.ChangeStatus(isWellDone);
    }

    public bool IsWellDone()
    {
        bool isWellDone = true;
        foreach (HandTrigger handTrigger in handTriggers)
            isWellDone = isWellDone && handTrigger.IsWellDone;
        if (isWellDone)
            EstanEnVerde();
        return isWellDone;
    }

    public void EstanEnVerde() 
    {
        //Debug.Log($"EstanEnVerde {gameObject.name}");
        GameObject.Find("SimulationController").GetComponent<SimulationController>().VerifyUserAction(new SimulationObject.Action(gameObject.name, $"EstanEnVerde{gameObject.name}", ""));
    }

    public void Log()
    {
        Debug.Log($"llegue Log {gameObject.name}");
    }
}
