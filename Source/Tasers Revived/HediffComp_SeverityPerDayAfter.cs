
using System;
using System.Text;
using Verse;

namespace TasersRevived {

    class HediffComp_SeverityPerDayAfter : HediffComp_SeverityPerDay {

        private HediffCompProperties_SeverityPerDayAfter Props {
            get {
                return (HediffCompProperties_SeverityPerDayAfter)props;
            }
        }

        private int StartChangeSeverityAfter {
            get {
                return Math.Max(0, Props.startChangeSeverityAfter - parent.ageTicks);
            }
        }

        public override string CompDebugString() {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(base.CompDebugString().TrimEndNewlines());
            if (base.Pawn.Dead == false) {
                stringBuilder.AppendLine("change severity after: " + StartChangeSeverityAfter.ToString());
            }
            return stringBuilder.ToString().TrimEndNewlines();
        }


        public override float SeverityChangePerDay() {
            if (0 < StartChangeSeverityAfter) {
                return 0.0f;
            }
            else {
                return base.SeverityChangePerDay();
            }
        }

    }

}
