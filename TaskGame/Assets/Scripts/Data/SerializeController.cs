using System.Collections.Generic;
using System.IO;
using Items;
using Units;
using UnityEngine;

namespace Data
{
    public class SerializeController:MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private string _saveFileName;
        [SerializeField] private string _pathToSaveFile;
        [SerializeField] private GameData _gameData;
        [Header("Data")]
        [SerializeField] private List<InventoryItem> _inventoryItems;
        [SerializeField] private Player _player;

        private void Awake()
        {
            _pathToSaveFile = Path.Combine(Application.persistentDataPath, _saveFileName);

            if (File.Exists(_pathToSaveFile))
            {
                _gameData = BinarySerializer.Deserialize<GameData>(_pathToSaveFile);
                SetGameData();
            }
        }

        private void OnApplicationQuit()
        {
            GetGameData();
            BinarySerializer.Serialize(this._pathToSaveFile,this._gameData);
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            GetGameData();
            BinarySerializer.Serialize(this._pathToSaveFile,this._gameData);
        }

        private void GetGameData()
        {
            _gameData.healthValue = _player.Health;
            Vector3 _positionUnit = _player.GetPositionUnit();
            _gameData.playerPositionX = _positionUnit.x;
            _gameData.playerPositionY = _positionUnit.y;
            _gameData.playerPositionZ = _positionUnit.z;
            this._gameData.inventoryItems = new List<InventoryData>();
            foreach (var item in _inventoryItems)
            {
                this._gameData.inventoryItems.Add(new InventoryData
                {
                    nameItem = item.Name,
                    countItems = item.CountItems
                });
            }
        }

        private void SetGameData()
        {
            _player.SetGameData(_gameData);
            foreach (var item in _inventoryItems)
            {
                item.SetGameData(_gameData);
            }
        }
        
        public void DeleteSaveData()
        {
            string path = Application.persistentDataPath+$"/{_saveFileName}";
            File.Delete(path);
        }
    }
}