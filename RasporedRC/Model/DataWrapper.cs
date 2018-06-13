using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace RasporedRC.Model
{
    class DataWrapper
    {
        ObservableCollection<Subject> subs;
        ObservableCollection<Course> cours;
        ObservableCollection<Software> softs;
        ObservableCollection<Classroom> classrms;
        List<Term> unassigned;
        Dictionary<string, List<ObservableCollection<Term>>> schedule;

        public ObservableCollection<Subject> Subs
        {
            get { return subs; }
            set { subs = value; }
        }
        public ObservableCollection<Course> Cours
        {
            get { return cours; }
            set { cours = value; }
        }
        public ObservableCollection<Software> Softs
        {
            get { return softs; }
            set { softs = value; }
        }
        public ObservableCollection<Classroom> Classrms
        {
            get { return classrms; }
            set { classrms = value; }
        }
        public List<Term> Unassigned
        {
            get { return unassigned; }
            set { unassigned = value; }
        }
        public Dictionary<string,List<ObservableCollection<Term>>> Schedule
        {
            get { return schedule; }
            set { schedule = value; }
        }
    }



}
