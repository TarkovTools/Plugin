using EFT.UI;
using System.Collections.Generic;
using UnityEngine;
using Comfort.Common;
using EFT;

namespace TarkovTools.Core
{
    internal class QuestZones
    {
        public static List<Zone> GetZones()
        {
            var request = Utils.Get<List<Zone>>("/quests/zones/getZones");
#if DEBUG
            int loadedZoneCount = 0;
            foreach (var zone in request)
            {
                if (zone.zoneLocation.ToLower() == Singleton<GameWorld>.Instance.MainPlayer.Location.ToLower())
                {
                    ConsoleScreen.Log("-------------------------------------");
                    ConsoleScreen.Log($"Scale Z: {zone.scale.z}");
                    ConsoleScreen.Log($"Scale Y: {zone.scale.y}");
                    ConsoleScreen.Log($"Scale X: {zone.scale.x}");
                    ConsoleScreen.Log($"ZoneScale:");
                    ConsoleScreen.Log($"Position Z: {zone.position.z}");
                    ConsoleScreen.Log($"Position Y: {zone.position.y}");
                    ConsoleScreen.Log($"Position X: {zone.position.x}");
                    ConsoleScreen.Log("ZonePosition:");
                    ConsoleScreen.Log($"ZoneType: {zone.zoneType}");
                    ConsoleScreen.Log($"ZoneLocation: {zone.zoneLocation}");
                    ConsoleScreen.Log($"ZoneId: {zone.zoneId}");
                    ConsoleScreen.Log($"ZoneName: {zone.zoneName}");
                    ConsoleScreen.Log("-------------------------------------");
                    loadedZoneCount++;
                }
            }
            ConsoleScreen.Log("-------------------------------------");
            ConsoleScreen.Log($"Loaded Zone Count: {loadedZoneCount}");
            ConsoleScreen.Log($"Player Map Location: {Singleton<GameWorld>.Instance.MainPlayer.Location}");
#endif   
            return request;
        }

        public static GameObject ZoneCreateItem(Zone zone)
        {
            GameObject newZone = new GameObject();

            BoxCollider boxCollider = newZone.AddComponent<BoxCollider>();
            boxCollider.isTrigger = true;

            Vector3 position = new Vector3(float.Parse(zone.position.x), float.Parse(zone.position.y), float.Parse(zone.position.z));
            Vector3 scale = new Vector3(float.Parse(zone.scale.x), float.Parse(zone.scale.y), float.Parse(zone.scale.z));

            newZone.transform.position = position;
            newZone.transform.localScale = scale;

            EFT.Interactive.PlaceItemTrigger trigger = newZone.AddComponent<EFT.Interactive.PlaceItemTrigger>();
            trigger.SetId(zone.zoneId);

            newZone.layer = LayerMask.NameToLayer("Triggers");
            newZone.name = zone.zoneId;

            return newZone;
        }

        public static GameObject ZoneCreateVisit(Zone zone)
        {
            GameObject newZone = new GameObject();

            BoxCollider boxCollider = newZone.AddComponent<BoxCollider>();
            boxCollider.isTrigger = true;

            Vector3 position = new Vector3(float.Parse(zone.position.x), float.Parse(zone.position.y), float.Parse(zone.position.z));
            Vector3 scale = new Vector3(float.Parse(zone.scale.x), float.Parse(zone.scale.y), float.Parse(zone.scale.z));

            newZone.transform.position = position;
            newZone.transform.localScale = scale;

            EFT.Interactive.ExperienceTrigger trigger = newZone.AddComponent<EFT.Interactive.ExperienceTrigger>();
            trigger.SetId(zone.zoneId);

            newZone.layer = LayerMask.NameToLayer("Triggers");
            newZone.name = zone.zoneId;

            return newZone;
        }

        public static GameObject ZoneCreateBotKillZone(Zone zone)
        {
            GameObject newZone = new GameObject();

            BoxCollider boxCollider = newZone.AddComponent<BoxCollider>();
            boxCollider.isTrigger = true;

            Vector3 position = new Vector3(float.Parse(zone.position.x), float.Parse(zone.position.y), float.Parse(zone.position.z));
            Vector3 scale = new Vector3(float.Parse(zone.scale.x), float.Parse(zone.scale.y), float.Parse(zone.scale.z));

            newZone.transform.position = position;
            newZone.transform.localScale = scale;

            EFT.Interactive.TriggerWithId trigger = newZone.AddComponent<EFT.Interactive.TriggerWithId>();
            trigger.SetId(zone.zoneId);

            newZone.layer = LayerMask.NameToLayer("Triggers");
            newZone.name = zone.zoneId;

            return newZone;
        }

        public static void CreateZones(List<Zone> zones, string Location)
        {
            foreach (Zone zone in zones)
            {
                if (zone.zoneLocation.ToLower() == Location.ToLower())
                {
                    if (zone.zoneType.ToLower() == "placeitem")
                    {
                        ZoneCreateItem(zone);
                    }

                    if (zone.zoneType.ToLower() == "visit")
                    {
                        ZoneCreateVisit(zone);
                    }

                    if (zone.zoneType.ToLower() == "flarezone")
                    {
                        //GameObject flareZone = ZoneCreateFlare(zone);
                    }

                    if (zone.zoneType.ToLower() == "botkillzone")
                    {
                        ZoneCreateBotKillZone(zone);
                    }
                }
            }
        }
    }
}
