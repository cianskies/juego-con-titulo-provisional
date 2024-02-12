using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DecisionFSM : MonoBehaviour
{
    public abstract bool Decidir(EnemigoFSM enemigo);
}
