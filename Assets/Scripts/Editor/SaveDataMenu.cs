using UnityEditor;
using UnityEngine;

namespace MicroForest.Editor
{
    public static class SaveDataMenu
    {
        [MenuItem("Micro Forest/Delete Save Data")]
        public static void DeleteSaveData()
        {
            Core.SaveSystem.DeleteSave();
            Debug.Log("Save data eliminado. Detén y vuelve a dar Play para empezar de cero.");
        }
    }
}