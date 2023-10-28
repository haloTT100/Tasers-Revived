
using System;
using System.Linq;
using System.Collections.Generic;
using Verse;
using RimWorld;

namespace TasersRevived {

    public class TaserBullet : Bullet {

        private float GetSeverity(Pawn pawn) {
            var bulletDef = def as TaserBulletDef;
            if (bulletDef == null) {
                Log.Warning("def is not a TaserBulletDef.");
                return 0.0f;
            }
            var hediff = pawn.health.hediffSet.GetFirstHediffOfDef(bulletDef.taserHediff);
            if (hediff == null) {
                return 0.0f;
            }
            return hediff.Severity;
        }
        private void SetSeverity(float severity, Pawn pawn) {
            var bulletDef = def as TaserBulletDef;
            if (bulletDef == null) {
                Log.Warning("def is not a TaserBulletDef.");
                return;
            }
            var hediff = pawn.health.hediffSet.GetFirstHediffOfDef(bulletDef.taserHediff);
            if (hediff == null) {
                hediff = pawn.health.AddHediff(bulletDef.taserHediff);
                if (hediff == null) {
                    Log.Warning("could not add hediff to " + pawn + ".");
                    return;
                }
            }
            hediff.Severity = severity;
        }
        private float NextSeverity(Pawn pawn) {
            var bulletDef = def as TaserBulletDef;
            if (bulletDef == null) {
                Log.Warning("def is not a TaserBulletDef.");
                return 0.999f;
            }
            float increaseSeverity = bulletDef.taserPower / pawn.def.BaseMass; // redefine later
            float pawnSeverity = GetSeverity(pawn);
            float newSeverity = pawnSeverity + increaseSeverity;
            if (0.9f <= pawnSeverity) {
                return newSeverity;
            }
            else {
                return Math.Min(newSeverity, 0.999f);
            }
        }
        private void TryTase(Pawn pawn) {
            var bulletDef = def as TaserBulletDef;
            if (bulletDef == null) {
                Log.Warning("def is not a TaserBulletDef.");
                return;
            }
            if (bulletDef.taserExcludeRaces.Contains(pawn.def)) {
                return;
            }
            if (bulletDef.taserExcludeFleshTypes.Contains(pawn.RaceProps.FleshType)) {
                return;
            }
            var nextSeverity = NextSeverity(pawn);
            SetSeverity(nextSeverity, pawn);
        }
        private float TotalBulletDamage(Pawn pawn) {
            return pawn.health.hediffSet.hediffs
                .Where(hediff => hediff.def == def.projectile.damageDef.hediff)
                .Select(hediff => hediff.Severity)
                .Sum();
        }
        protected override void Impact(Thing thing, bool blockedByShield = false) {
            var pawn = thing as Pawn;
            if (pawn != null) {
                var totalDamageBefore = TotalBulletDamage(pawn);
                base.Impact(thing);
                var totalDamageAfter = TotalBulletDamage(pawn);
                if (totalDamageBefore < totalDamageAfter) {
                    TryTase(pawn);
                }
            }
            else {
                base.Impact(thing);
            }
        }
    }
}