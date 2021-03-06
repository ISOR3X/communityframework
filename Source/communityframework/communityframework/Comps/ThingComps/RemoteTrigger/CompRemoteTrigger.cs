using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
using UnityEngine;

namespace CF
{
    class CompRemoteTrigger : ThingComp
    {
        public CompProperties_RemoteTrigger Props
        {
            get
            {
                return (CompProperties_RemoteTrigger)this.props;
            }
        }

        public override IEnumerable<Gizmo> CompGetGizmosExtra()
        {
            // Check if graphicPath returns an actual texture.
            if (!ContentFinder<Texture2D>.Get(Props.texPath))
            {
                Log.Error("No Gizmo texture found");
            }

            return base.CompGetGizmosExtra().Append(new Command_Action
            {
                defaultLabel = "Trigger",
                defaultDesc = $"Trigger {this.parent.def.defName}",
                icon = ContentFinder<Texture2D>.Get(Props.texPath),
                action = delegate
                {
                    Thing toDetonate = base.parent;
                    CompExplosive cE = toDetonate.TryGetComp<CompExplosive>();
                    if (!(cE?.wickStarted ?? true)) cE.StartWick();
                }
            });          
        }
    }
}
