using Verse;

namespace TasersRevived {
    public class HediffDescChange : HediffWithComps {

        public override string TipStringExtra {
            get {
                // return a different description based on the severity level
                switch (Severity) {
                    case float s when s >= 1.0f:
                        return "Fatal Electrical Overload: This pawn has succumbed to an overwhelming electrical discharge, which has proven fatal. Their body convulsed uncontrollably until their vital systems could no longer sustain life. It's a grim reminder of the devastating consequences of a powerful electrical shock. Rest in peace.";
                    case float s when s >= 0.9f:
                        return "Life-Threatening Electrical Overload: This pawn has been subjected to a catastrophic electrical surge, leaving them on the brink of life and death. Their body convulses violently, and they can barely breathe or move. Immediate medical intervention is required to stabilize them, or they may not survive. This is a critical, life-threatening condition that demands urgent attention.";
                    case float s when s >= 0.7f:
                        return "Critical Electrical Surge: This pawn has suffered an extreme electrical jolt, rendering them nearly incapacitated. Their entire body convulses, and they can barely move or defend themselves. They are in a critical condition and require urgent medical attention and an extended period of recovery.";
                    case float s when s >= 0.5f:
                        return "Electricity Overload: This pawn has endured a severe electrical shock, leaving them in a disoriented and weakened state. Their muscles spasm, movements are slow and uncoordinated, and they are highly vulnerable to threats. Recovery will take some time.";
                    case float s when s >= 0.3f:
                        return "Electrical Stun: This pawn has been moderately tazed, resulting in a state of confusion and sluggishness. Their muscles twitch, coordination falters, and they struggle to act effectively. They require time to recover.";
                    case float s when s >= 0.1f:
                        return "Light Shocked State: This pawn has experienced a mild electrical shock, causing temporary discomfort and muscle twitches. Their movements are slightly impaired, but they can still function to some extent.";
                    default:
                        return "Light Shocked State: This pawn has experienced a mild electrical shock, causing temporary discomfort and muscle twitches. Their movements are slightly impaired, but they can still function to some extent.";
                }
            }
        }
    }
}