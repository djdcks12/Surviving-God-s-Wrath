    using Google.Protobuf;
    using UnityEngine;
    
    public static class Define
    {
        public class Managers
        {
            public class Resource
            {
                public static GameObject Instantiate(string resourcePath, Transform parent)
                {
                    GameObject obj = Resources.Load(resourcePath) as GameObject;
                    return obj;
                }

                public static GameObject Instantiate(string resourcePath)
                {
                    GameObject obj = Resources.Load(resourcePath) as GameObject;
                    return obj;
                }

                public static void Destroy(GameObject obj)
                {
                    
                }
            }
            public class Map
            {
                public static bool CanGo(Vector3 position)
                {
                    return true;
                }
            }

            public class Object
            {
                public static GameObject FindCreature(Vector3 position)
                {
                    GameObject obj = null;
                    return obj;
                }
            }

            public class Network
            {
                public static void Send(IMessage message)
                {
                    
                }
            }
        }

        public class HpBar
        {
            public void SetHpBar(float value)
            {
            }
        }
    }
