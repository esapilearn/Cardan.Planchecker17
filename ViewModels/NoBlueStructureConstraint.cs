using ESAPIX.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using VMS.TPS.Common.Model.API;

namespace Cardan.PlanChecker18.ViewModels
{
    public class NoBlueStructureConstraint : IConstraint
    {
        public string Name => "No Blue Constraints!";

        public string FullName => "No Blue Constraints!";

        public ConstraintResult CanConstrain(PlanningItem pi)
        {
            var pq = new PQAsserter(pi);
            return pq.HasStructureSet()
                .CumulativeResult;
        }

        public ConstraintResult Constrain(PlanningItem pi)
        {
            var ss = pi.StructureSet;
            var hasBlue = ss.Structures.Any(s =>
            {
                return s.Color == Colors.Blue;
            });

            if (hasBlue) { return new ConstraintResult(this, ResultType.ACTION_LEVEL_3, "Has blue structure! Abort! Abort!!."); }
            else
            {
                return new ConstraintResult(this, ResultType.PASSED, "Whew! No blue structures");
            }
        }
    }
}
