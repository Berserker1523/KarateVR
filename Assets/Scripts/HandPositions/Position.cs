using UnityEngine;

public class Position : MonoBehaviour
{
    [SerializeField] private HandTrigger[] handTriggers = new HandTrigger[2];

    private bool envioEstanEnVerde = false;

    public void OnEnable()
    {
        foreach (HandTrigger handTrigger in handTriggers)
        {
            handTrigger.ChangeStatus(false);
        }
    }

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
        if(!envioEstanEnVerde)
        {
            GameObject.Find("SimulationController").GetComponent<SimulationController>().VerifyUserAction(new SimulationObject.Action(gameObject.name, $"EstanEnVerde{gameObject.name}", ""));
            envioEstanEnVerde = true;
        }
        
    }

    public void Log()
    {
        Debug.Log($"llegue Log {gameObject.name}");
    }
}
