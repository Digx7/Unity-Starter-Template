using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Digx7.Zygote
{
    public class SaveSystem : Singleton<SaveSystem>
    {
        #region Variables ================================
        
        [Header("Variables")]
        public int activeSaveSlot = 0;
        public Save save;

        [Header("Incoming Channels")]
        public Channel requestSaveGameChannel;
        public Channel onGameSavedChannel;
        public Channel requestLoadGameChannel;
        public Channel onGameLoadedChannel;
        public Channel requestDeleteSaveChannel;
        public Channel onDeleteSaveChannel;
        public Channel requestMakeNewSaveChannel;
        public Channel onMakeNewSaveChannel;
        public IntChannel requestChangeActiveSaveSlot;

        // [Header("Outgoing Events")]

        

        #endregion

        #region Setup ================================
        public override void SafeOnEnable()
        {
            requestSaveGameChannel.channelEvent.AddListener(SaveData);
            requestLoadGameChannel.channelEvent.AddListener(LoadData);
            requestDeleteSaveChannel.channelEvent.AddListener(DeleteData);
            requestMakeNewSaveChannel.channelEvent.AddListener(MakeNewSaveData);

            save = new Save();
        }

        public override void SafeOnDisable()
        {
            requestSaveGameChannel.channelEvent.RemoveListener(SaveData);
            requestLoadGameChannel.channelEvent.RemoveListener(LoadData);
            requestDeleteSaveChannel.channelEvent.RemoveListener(DeleteData);
            requestMakeNewSaveChannel.channelEvent.RemoveListener(MakeNewSaveData);
        }
        
        #endregion

        #region Channel Responses ================================

        #endregion

        #region Main Functions ================================

        public void SaveData()
        {
            string destination = Path();
            FileStream file;

            if(File.Exists(destination)) file = File.OpenWrite(destination);
            else file = File.Create(destination);

            DataContractSerializer serializer = new DataContractSerializer(save.GetType());
            serializer.WriteObject(file, save);
            file.Close();

            Debug.Log("SaveSystem: Saving game to slot " + activeSaveSlot);
            // save.PrintAllEntries();

            onGameSavedChannel.Raise();
        }

        public void LoadData()
        {
            string destination = Path();
            FileStream file;

            Debug.Log("SaveSystem: Trying to load save at slot " + activeSaveSlot);

            if(File.Exists(destination)) file = File.OpenRead(destination);
            else
            {
                Debug.Log("SaveSystem: Save Data not found at slot " + activeSaveSlot);
                MakeNewSaveData();
                return;
            }

            DataContractSerializer serializer = new DataContractSerializer(save.GetType());
            save = serializer.ReadObject(file) as Save;
            file.Close();

            Debug.Log("SaveSystem: Loaded save from slot " + activeSaveSlot);

            // save.PrintAllEntries();

            onGameLoadedChannel.Raise();
        }

        [ContextMenu("DeleteData")]
        public void DeleteData()
        {
            string destination = Path();
            
            if(File.Exists(destination)) File.Delete(destination);
            else
            {
                Debug.LogWarning("SaveSystem: tried to delete a file in slot " + activeSaveSlot + ".  But no file exists there");
                return;
            }

            Debug.Log("SaveSystem: deleted save at slot " + activeSaveSlot);

            onDeleteSaveChannel.Raise();
        }

        public void MakeNewSaveData()
        {
            Debug.Log("SaveSystem: Making a new save at slot " + activeSaveSlot);
            save.ClearAllData();
            save.CreateDefaultSaveFile();
            SaveData();
            onMakeNewSaveChannel.Raise();
        }

        private string Path()
        {
            return Application.persistentDataPath + "/save" + activeSaveSlot + ".data";
        }

        #endregion
    }
}
