using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

[CreateAssetMenu(menuName ="Items/Item")]
public class ItemData : ScriptableObject
{
    [Header("ID")]
    public int ID;
    public Sprite Icono;
    public string Nombre;

    public virtual void Recoger()
    {

    }
}
