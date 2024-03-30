using System.Collections.Generic;

namespace Data
{
    [System.Serializable]
    public struct GameData
    {
        public float playerPositionX;
        public float playerPositionY;
        public float playerPositionZ;
        public int healthValue;
        public List<InventoryData> inventoryItems;
    }
}