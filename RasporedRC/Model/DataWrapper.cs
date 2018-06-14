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
    [Serializable]
    public class DataWrapper
    {
        ObservableCollection<Subject> subs;
        ObservableCollection<Course> cours;
        ObservableCollection<Software> softs;
        ObservableCollection<Classroom> classrms;
        List<Term> unassigned;
        List<List<ObservableCollection<Term>>> schedule_week;
        List<string> classroom_ids;

        public DataWrapper()
        {
            classroom_ids = new List<string>();
            schedule_week = new List<List<ObservableCollection<Term>>>();
        }

        public void loadDictionary(Dictionary<string, List<ObservableCollection<Term>>> schedule)
        {
            foreach(var cr_schedule in schedule)
            {
                classroom_ids.Add(cr_schedule.Key);
                schedule_week.Add(cr_schedule.Value);
            }
        }

        public Dictionary<string,List<ObservableCollection<Term>>> generateScheduleDict()
        {
            Dictionary<string,List<ObservableCollection<Term>>> retVal = new Dictionary<string, List<ObservableCollection<Term>>>();
            for(int i = 0; i < classroom_ids.Count;i++)
            {
                retVal.Add(classroom_ids[i], schedule_week[i]);
            }
            return retVal;
        }

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
        public List<string> Classroom_ids
        {
            get { return classroom_ids; }
            set { classroom_ids = value; }
        }
        public List<List<ObservableCollection<Term>>> Schedule_week
        {
            get { return schedule_week; }
            set { schedule_week = value; }
        }
    }



}
