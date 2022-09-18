using UnityEngine;

public class Altin : MonoBehaviour
{
    [SerializeField]
    GameObject altin = default;
    
    public void AltinAc()
    {
        altin.SetActive(true);
    }
    
    public void AltinKapat()
    {
        altin.SetActive(false);
    }
}
