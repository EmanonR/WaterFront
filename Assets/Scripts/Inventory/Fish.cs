using UnityEngine;

public enum Rarity {  Junk, Common, Uncommon, Rare, Legendary }

[CreateAssetMenu(menuName = "Item/Fish", fileName = "New Fish")]
public class Fish : Item
{
    public Rarity rarity;
    public int baseValue = 10;
    public float pullStrength = 1f;
    public float agressiveness = 1f;
}
