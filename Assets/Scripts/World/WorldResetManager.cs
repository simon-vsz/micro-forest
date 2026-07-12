

namespace MicroForest.World
{
    public static class WorldResetManager
    {
        public static void ResetWorld()
        {
            foreach (Vegetation vegetation in Vegetation.AllVegetation)
            {
                vegetation.Reset();
            }

            UnityEngine.GameObject[] leftoverInsects = UnityEngine.GameObject.FindGameObjectsWithTag("Insect");
            foreach (UnityEngine.GameObject insect in leftoverInsects)
            {
                UnityEngine.Object.Destroy(insect);
            }
        }
    }
}