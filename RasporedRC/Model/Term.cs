using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RasporedRC.Model
{
    class Term : INotifyPropertyChanged
    {
        private string subjectId;
        private int termId;
        private string courseId;
        private string displayText;
        private string toolTipText;
        private int heightOfElem;
        private Brush bgColor;
        private bool isAllowed;
        private Brush borderColor;

        public event PropertyChangedEventHandler PropertyChanged;

        public Term(string subjectId, int termId, string courseId)
        {
            this.subjectId = subjectId;
            this.termId = termId;
            this.courseId = courseId;
            this.toolTipText = "Course: " + courseId + "\nSubject: " + subjectId;
            displayText = "";

            if(subjectId.Length < 18)
            {
                displayText = subjectId.Substring(0, 16) + "..";
            }else
            {
                displayText = subjectId;
            }

            if (subjectId.Equals(""))
            {
                bgColor = new SolidColorBrush(Colors.LightGray);
            }
            else
            {
                bgColor = new SolidColorBrush(Colors.White);
            }
        }

        public string SubjectId
        {
            get { return subjectId; }
            set { subjectId = value; }
        }
        public int TermId
        {
            get { return termId; }
            set { termId = value; }
        }
        public string CourseId
        {
            get { return courseId; }
            set { courseId = value; }
        }
        public Brush BgColor
        {
            get { return bgColor; }
            set { bgColor = value; }
        }
        public bool IsAllowed
        {
            get { return isAllowed; }
            set
            {
                isAllowed = value;
                if (isAllowed)
                    BorderColor = new SolidColorBrush(Colors.Green);
                else
                    BorderColor = new SolidColorBrush(Colors.Red);
            }
        }
        public Brush BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; }
        }
        public int HeightOfElem
        {
            get { return heightOfElem; }
            set { heightOfElem = value; }
        }
        public string ToolTipText
        {
            get { return toolTipText; }
            set { toolTipText = value; }
        }
        public string DisplayText
        {
            get { return displayText; }
            set { displayText = value; }
        }

    }
}
