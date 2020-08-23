using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPointPresenterController
{
    public class TeamViewModel
    {
        public string Id { get; set; }
        public string TeamName { get; set; }

        public int PointSet { get; set; }
        public int Point { get; set; }
        public TeamViewModel()
        {
            Id = null;
            TeamName = "Not Set";
            Point = -1;
        }
        public TeamViewModel(string id, string teamName, int point)
        {
            Id = id;
            TeamName = teamName;
            Point = point;
            PointSet = point;
        }
    }
}
