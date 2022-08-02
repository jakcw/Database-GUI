using WpfApp4.Database;
using WpfApp4.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace WpfApp4.Controller
{
    class ClassController
    {
        public List<UnitClass> ClassList { get; set; }
        public ObservableCollection<UnitClass> viewableClasses { get; set; }
        public ObservableCollection<UnitClass> VisibleClasses { get { return viewableClasses; } set { } }

        public ClassController()
        {
            ClassList = DBAdapter.GetClassDetails();
            viewableClasses = new ObservableCollection<UnitClass>(ClassList);
        }

        public ObservableCollection<UnitClass> GetViewableClasses()
        {
            return VisibleClasses;
        }

        public void FilterById(int id)
        {
            var selected = from UnitClass s in ClassList
                           where id == s.Staff
                           select s;

            viewableClasses.Clear();
            selected.ToList().ForEach(viewableClasses.Add);
        }

        
    }
}
