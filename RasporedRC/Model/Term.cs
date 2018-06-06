using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RasporedRC.Model
{
    public class Term : INotifyPropertyChanged
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
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public Term(string subjectId, int termId, string courseId)
        {
            this.subjectId = subjectId;
            this.termId = termId;
            this.courseId = courseId;
            displayText = "";

            updateDisplay();

            if (subjectId.Equals(""))
            {
                BgColor = new SolidColorBrush(Colors.LightGray);
                ToolTipText = "15 minuta";
                HeightOfElem = 10;
            }
            else
            {
                BgColor = new SolidColorBrush(Colors.White);
                this.toolTipText = "Smer: " + courseId + "\nPredmet: " + subjectId;
                HeightOfElem = 32;
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
            set
            {
                bgColor = value;
                OnPropertyChanged("BgColor");
            }
            
        }
        public bool IsAllowed
        {
            get { return isAllowed; }
            set
            {
                isAllowed = value;
                OnPropertyChanged("IsAllowed");
                if (isAllowed)
                    BorderColor = new SolidColorBrush(Colors.Green);
            }
        }
        public Brush BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                OnPropertyChanged("BorderColor");
            }
        }
        public int HeightOfElem
        {
            get { return heightOfElem; }
            set
            {
                heightOfElem = value;
                OnPropertyChanged("HeightOfElem");
            }
        }
        public string ToolTipText
        {
            get { return toolTipText; }
            set
            {
                toolTipText = value;
                OnPropertyChanged("ToolTipText");
            }
        }
        public string DisplayText
        {
            get { return displayText; }
            set
            {
                displayText = value;
                OnPropertyChanged("DisplayText");
            }
        }

        private void updateDisplay()
        {
            if(courseId == "")
            {
                DisplayText = "";
                return;
            }
            if (courseId.Length > 14)
            {
                DisplayText = "S: " + courseId.Substring(0, 12) + "..\n";
            }
            else
            {
                DisplayText += "S: " + courseId + "\n";
            }
            if (subjectId.Length > 14)
            {
                DisplayText += "P: " + SubjectId.Substring(0, 12) + "..";
            }
            else
            {
                DisplayText += "P: " + SubjectId;
            }
        }

    }
}
