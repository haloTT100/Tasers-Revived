
using System;
using System.Collections.Generic;
using Verse;
using RimWorld;

namespace TasersRevived {

    public class TaserBulletDef : ThingDef {

        public HediffDef taserHediff = null;
        public float taserPower = 21.0f;
        public List<ThingDef> taserExcludeRaces = new List<ThingDef>();
        public List<FleshTypeDef> taserExcludeFleshTypes = new List<FleshTypeDef>();

    }

}